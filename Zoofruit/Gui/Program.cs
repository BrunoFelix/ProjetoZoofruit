using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Gui
{
    static class Program
    {
        public static Socket socket;
        public static Thread thread;

        public static NetworkStream networkStream;
        public static BinaryWriter binaryWriter;
        public static BinaryReader binaryReader;

        public static TcpListener tcpListener;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            thread = new Thread(new ThreadStart(RunServer));
            thread.Start();

            Gui.tela_login tela_login = new Gui.tela_login();

            if (tela_login.ShowDialog() == DialogResult.OK)
            {
                Principal principal = new Principal(tela_login.usuario);
                Application.Run(principal);
            }
        }

        public static void RunServer()
        {

            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2001);
                tcpListener = new TcpListener(ipEndPoint);
                tcpListener.Start();

                //AddToListBox("Servidor habilitado e escutando porta..." + "Server App");


                /*socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                if (socket.Connected)
                {
                    Console.WriteLine("Winsock error: " + Convert.ToString(System.Runtime.InteropServices.Marshal.GetLastWin32Error()));
                }*/

                socket = tcpListener.AcceptSocket();
                networkStream = new NetworkStream(socket);
                binaryWriter = new BinaryWriter(networkStream);
                binaryReader = new BinaryReader(networkStream);

                //MessageBox.Show("conexão recebida!" + "Server App");
                //binaryWriter.Write("\nconexão efetuada!");

                string messageReceived = "";
                do
                {
                    messageReceived = binaryReader.ReadString();

                    // AddToListBox("Filtro da pesquisa:" + messageReceived);

                } while (socket.Connected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (binaryReader != null)
                {
                    binaryReader.Close();
                }
                if (binaryWriter != null)
                {
                    binaryWriter.Close();
                }
                if (networkStream != null)
                {
                    networkStream.Close();
                }
                if (socket != null)
                {
                    socket.Close();
                }
                //MessageBox.Show("conexão finalizada", "Server App");

            }
        }

    }
}

using Gui.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui
{
    public partial class Manter_ficha_alimento_ed : Form
    {

        private Socket socket;
        private Thread thread;

        private NetworkStream networkStream;
        private BinaryWriter binaryWriter;
        private BinaryReader binaryReader;

        TcpListener tcpListener;


        int tipoficha;
        Service1 webservice;
        FichaAlimento fichaalimento;
        public List<Alimento> listaalimento = new List<Alimento>();
        private Animal animal;
        private Usuario usuario;
        public Manter_ficha_alimento_ed(int tipoficha, Animal a, Usuario u)
        {
            try { 
                InitializeComponent();
                thread = new Thread(new ThreadStart(RunServer));
                thread.Start();

                this.tipoficha = tipoficha;
                webservice = new Service1();

                if (tipoficha != 1)
                {
                    label3.Visible = false;
                    tb_qtd_max_cal.Visible = false;
                }
                animal = a;
                usuario = u;
                dtp_validade.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RunServer()
        {

            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2001);
                tcpListener = new TcpListener(ipEndPoint);
                tcpListener.Start();

                //AddToListBox("Servidor habilitado e escutando porta..." + "Server App");

                socket = tcpListener.AcceptSocket();
                networkStream = new NetworkStream(socket);
                binaryWriter = new BinaryWriter(networkStream);
                binaryReader = new BinaryReader(networkStream);

                MessageBox.Show("conexão recebida!" + "Server App");
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

        public void atualizarGridALimento()
        {
            try
            {
                lv_alimento.Items.Clear();

                ListViewItem item;

                foreach (Alimento a in listaalimento)
                {
                    item = new ListViewItem();
                    item.Text = a.Codigo.ToString();
                    item.SubItems.Add(a.Nome);
                    item.SubItems.Add(a.ValorCalorico.ToString());
                    item.SubItems.Add(a.Quantidade.ToString());

                    lv_alimento.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_novo_animal_Click(object sender, EventArgs e)
        {
            try
            {
                Manter_ficha_buscar_alimento_ed manter_ficha_buscar_alimento_ed = new Manter_ficha_buscar_alimento_ed();
                manter_ficha_buscar_alimento_ed.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    binaryWriter.Write("Funcionou");
                }
                catch (SocketException socketEx)
                {
                    MessageBox.Show(socketEx.Message, "Erro");
                }
                catch (Exception socketEx)
                {
                    MessageBox.Show(socketEx.Message, "Erro");
                }

                return;


                fichaalimento = new FichaAlimento();
                fichaalimento.Descricao = tb_descricao.Text;
                fichaalimento.DataCriacao = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                fichaalimento.DataValidade = dtp_validade.Value.ToString("yyyy-MM-dd");
                try
                {
                    fichaalimento.Qtd_max_cal = Convert.ToDouble(tb_qtd_max_cal.Text);
                }catch (Exception)
                {
                    MessageBox.Show("Quantida de Máxima de Calórias Inválida!");
                    this.DialogResult = DialogResult.None;
                    tb_qtd_max_cal.Focus();
                    return;
                }
                fichaalimento.Hora_a_ser_executado = tb_hora_a_ser_executada.Text;
                fichaalimento.Usuario = usuario;
                fichaalimento.Animal = animal;
                fichaalimento.ListaAlimento = listaalimento.ToArray();
                webservice.InserirFichaAlimento(fichaalimento);

                this.DialogResult = DialogResult.OK;

                

                ((Manter_ficha_alimento)Application.OpenForms["manter_ficha_alimento"]).lv_animal_SelectedIndexChanged(sender, e);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.None;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_alimento.SelectedIndices.Count > 0)
                {
                    if (MessageBox.Show("Deseja remover o alimento selecionado da ficha?", "Zoofruit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        listaalimento.Remove(listaalimento.ElementAt(lv_alimento.SelectedIndices[0]));
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tb_hora_a_ser_executada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void Manter_ficha_alimento_ed_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*tcpListener.Stop();
            Environment.Exit(0);*/
        }

        private void tb_qtd_max_cal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void Manter_ficha_alimento_ed_Load(object sender, EventArgs e)
        {

        }
    }
}

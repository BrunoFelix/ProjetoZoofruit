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
    public partial class Manter_ficha_execucao : Form
    {
        private NetworkStream networkStream;
        private BinaryWriter binaryWriter;
        private BinaryReader binaryReader;
        private TcpClient tcpClient;

        private Thread thread;

        private int tamanho_panel = 10;
        private int altura_panel = 90;
        private int i = 0;
        private int z = 1;
        private double tamanho_form = 0;
        private static Manter_ficha_execucao manter_ficha_execucao;
        public List<FichaAlimento> listafichaalimento;
        FichaAlimento fichaalimento = new FichaAlimento();
        Service1 webservice;
        Usuario usuario;



        public static Manter_ficha_execucao getInstance(Usuario u)
        {
            if (manter_ficha_execucao == null)
            {
                try
                {
                    manter_ficha_execucao = new Manter_ficha_execucao(u);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return manter_ficha_execucao;
        }
        private Manter_ficha_execucao(Usuario u)
        {
            try
            {
                InitializeComponent();
                usuario = u;
                thread = new Thread(new ThreadStart(RunClient));
                thread.Start();
                webservice = new Service1();
                FichaAlimento fichaalimento = new FichaAlimento();
                fichaalimento.Animal = new Animal();
                fichaalimento.Usuario = new Usuario();
                fichaalimento.ListaAlimento = new List<Alimento>().ToArray();
                fichaalimento.DataValidade = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                fichaalimento.Hora_a_ser_executado = DateTime.Now.Hour.ToString();
                listafichaalimento = webservice.ListarFichaAlimento(fichaalimento).ToList();
                AtualizarTela();           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RunClient()
        {
            try
            {
                tcpClient = new TcpClient();
                //conectando ao servidor
                tcpClient.Connect("127.0.0.1", 2001);

                networkStream = tcpClient.GetStream();
                binaryWriter = new BinaryWriter(networkStream);
                binaryReader = new BinaryReader(networkStream);
                binaryWriter.Write("Conexão requisitada pelo cliente");
                String message = "";

                #region laço para receber mensagem do servidor
                do
                {
                    try
                    {
                        message = binaryReader.ReadString();
                        Invoke(new MethodInvoker(
                          delegate {

                              fichaalimento = new FichaAlimento();
                              fichaalimento.Codigo = Convert.ToInt32(message);
                              fichaalimento.Animal = new Animal();
                              fichaalimento.Usuario = new Usuario();
                              fichaalimento.ListaAlimento = new List<Alimento>().ToArray();
                              foreach(FichaAlimento a in webservice.ListarFichaAlimento(fichaalimento).ToList())
                              {
                                  listafichaalimento.Add(a);
                              }

                              listafichaalimento = listafichaalimento.OrderBy(m => m.Hora_a_ser_executado).ThenBy(m => m.Hora_a_ser_executado).ToList();

                              AtualizarTela();
                          }
                          ));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro");
                        message = "FIM";
                    }
                } while (message != "FIM");
                #endregion

                binaryWriter.Close();
                binaryReader.Close();
                networkStream.Close();
                tcpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        public void AtualizarTela()
        {
            tamanho_form = this.Width;

            for (int ix = this.Controls.Count - 1; ix >= 0; ix--)
                if ((this.Controls[ix] is Panel) && (this.Controls[ix].Tag != "1")) this.Controls[ix].Dispose();

            tamanho_panel = 10;
            altura_panel = 90;
            i = 0;
            z = 1;

            foreach (FichaAlimento fa in listafichaalimento)
            {
                if (tamanho_panel < (tamanho_form - 150))
                {
                    Panel panel1 = new Panel();
                    if (Convert.ToInt32(fa.Hora_a_ser_executado) >= DateTime.Now.Hour)
                    {
                        panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
                        panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                    }else
                    {
                        panel1.BackColor = System.Drawing.Color.Tomato;
                        panel1.ForeColor = System.Drawing.Color.Tomato;
                    }
                    panel1.Location = new System.Drawing.Point(tamanho_panel, altura_panel);
                    panel1.Name = "panel_" + fa.Codigo.ToString();
                    panel1.Size = new System.Drawing.Size(213, 150);
                    panel1.TabIndex = 0;
                    tamanho_panel += 223;

                    Panel panel2 = new Panel();
                    panel2.BackColor = System.Drawing.SystemColors.ControlLight;
                    panel2.ForeColor = System.Drawing.SystemColors.ControlLight;
                    panel2.Location = new System.Drawing.Point(2, 2);
                    panel2.Size = new System.Drawing.Size(209, 25);

                    Button button5 = new Button();
                    button5.Tag = fa.Codigo.ToString();
                    button5.Click += common_Click;
                    button5.Location = new System.Drawing.Point(0, 125);
                    button5.Size = new System.Drawing.Size(213, 25);
                    button5.TabIndex = 0;
                    button5.Text = "Executar";
                    button5.ForeColor = Color.Black;
                    button5.UseVisualStyleBackColor = true;

                    Label c1 = new Label();
                    c1.Text = "Animal: " + fa.Animal.Nome;
                    c1.Top = 5;
                    c1.Height = 15;
                    c1.ForeColor = Color.Black;
                    c1.AutoSize = true;
                    c1.Left = (panel2.Width - c1.Width) / 2;

                    panel2.Controls.Add(c1);

                    Label c2 = new Label();
                    c2.Text = "Ficha: " + fa.Descricao;
                    c2.Left = 10;
                    c2.Top = 40;
                    c2.Height = 15;
                    c2.AutoSize = true;
                    c2.ForeColor = Color.Black;

                    Label c3 = new Label();
                    if (Convert.ToInt32(fa.Hora_a_ser_executado) > DateTime.Now.Hour)
                    {
                        c3.Text = "Qtd. Máx. Cal.: " + fa.Qtd_max_cal.ToString();
                    }
                    else
                    {
                        c3.Text = "Qtd. Máx. Cal.: " + fa.Qtd_max_cal.ToString() + "        Hora: " + fa.Hora_a_ser_executado;
                    }
                    c3.Left = 10;
                    c3.Top = 70;
                    c3.Height = 15;
                    c3.AutoSize = true;
                    c3.ForeColor = Color.Black;

                    Label c4 = new Label();
                    c4.Text = "De/Até: " + fa.DataCriacao + " - " + fa.DataValidade;
                    c4.Left = 10;
                    c4.Top = 100;
                    c4.Height = 15;
                    c4.AutoSize = true;
                    c4.ForeColor = Color.Black;
 
                    panel1.Controls.Add(panel2);

                    panel1.Controls.Add(c2);

                    panel1.Controls.Add(c3);

                    panel1.Controls.Add(c4);

                    panel1.Controls.Add(button5);

                    this.Controls.Add(panel1);

                    i++;
                }
                else
                {
                    tamanho_panel = 10;
                    altura_panel = altura_panel + 160;
                }
            }
        }

        private void ExecutarFicha(int codigo)
        {
            FichaAlimento fichaalimento = new FichaAlimento();
            fichaalimento.Codigo = codigo;
            fichaalimento.Animal = new Animal();
            fichaalimento.Usuario = new Usuario();
            fichaalimento.ListaAlimento = new List<Alimento>().ToArray();
            fichaalimento = webservice.ListarFichaAlimento(fichaalimento)[0];
            Manter_ficha_execucao_ed manter_ficha_execucao_ed = new Manter_ficha_execucao_ed(fichaalimento, usuario);
            manter_ficha_execucao_ed.ShowDialog();
        }


        private void common_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;        
            ExecutarFicha(Convert.ToInt32(btn.Tag));
        }

        private void Manter_ficha_execucao_FormClosed(object sender, FormClosedEventArgs e)
        {
            manter_ficha_execucao = null;
        }

        /*private void button_Click()
        {
            //MessageBox.Show(fa.Codigo.ToString());
        }*/


        private void Manter_ficha_execucao_Resize(object sender, EventArgs e)
        {
            AtualizarTela();
        }

        private void Manter_ficha_execucao_Load(object sender, EventArgs e)
        {
            lb_data.Text = "Data: " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            lb_hora.Text = "Hora: " + DateTime.Now.Hour.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_hora.Text = "Hora: " + DateTime.Now.ToString();
        }
    }
}

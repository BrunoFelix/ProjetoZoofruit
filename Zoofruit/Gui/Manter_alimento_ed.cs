using Gui.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace Gui
{
    public partial class Manter_alimento_ed : Form
    {
        private string nomeDoArquivo = "Alimentos.xml";
        private XElement doc;

        Service1 webservice;
        Alimento alimento;
        public Manter_alimento_ed()
        {
            InitializeComponent();
            webservice = new Service1();
            exibirxml();
        }

        public Manter_alimento_ed(Alimento a)
        {
            InitializeComponent();
            webservice = new Service1();
            alimento = a;

            tb_codigo.Text = alimento.Codigo.ToString();
            tb_nome.Text = alimento.Nome;
            tb_quantidade.Text = alimento.Quantidade.ToString();
            tb_valorcalorico.Text = alimento.ValorCalorico.ToString();
        }

        private void btnconfirmar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.alimento == null)
                {
                    Alimento alimento = new Alimento();
                    alimento.Nome = tb_nome.Text;
                    try
                    {
                        alimento.ValorCalorico = double.Parse(tb_valorcalorico.Text);
                    }
                    catch (Exception)
                    {
                        alimento.ValorCalorico = null;
                    }

                    try
                    {
                        alimento.Quantidade = double.Parse(tb_quantidade.Text);
                    }
                    catch (Exception)
                    {
                        alimento.Quantidade = null;
                    }
                    webservice.InserirAlimento(alimento);
                    ((Manter_alimento)Application.OpenForms["manter_alimento"]).btn_pesquisar_Click(sender, e);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    Alimento alimento = new Alimento();
                    alimento.Codigo = this.alimento.Codigo;
                    alimento.Nome = tb_nome.Text;
                    try
                    {
                        alimento.ValorCalorico = double.Parse(tb_valorcalorico.Text);
                    }
                    catch (Exception)
                    {
                        alimento.ValorCalorico = null;
                    }

                    try
                    {
                        alimento.Quantidade = double.Parse(tb_quantidade.Text);
                    }
                    catch (Exception)
                    {
                        alimento.Quantidade = null;
                    }
                    webservice.AlterarAlimento(alimento);
                    ((Manter_alimento)Application.OpenForms["manter_alimento"]).btn_pesquisar_Click(sender, e);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.None;
            }
        }
        private void Manter_alimento_ed_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.gravarxml();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.gravarxml();
           
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.gravarxml();
        }

        private void Manter_alimento_ed_Load(object sender, EventArgs e)
        {

        }
        /*Metodo Gravar XML*/
        public void gravarxml()
        {
            if (File.Exists(nomeDoArquivo))
            {
                doc = new XElement("Alimentos");
                XElement alimento = new XElement("Alimento");
                alimento.Add(new XElement("Nome", tb_nome.Text));
                alimento.Add(new XElement("ValorCalorico", tb_valorcalorico.Text));
                alimento.Add(new XElement("Quantidade", tb_quantidade.Text));
                doc.Add(alimento);
                doc.Save(nomeDoArquivo);

            }
            else
            {
                doc = XElement.Load(nomeDoArquivo);
            }

        }
        public void exibirxml()
        {
            XmlTextReader x = new XmlTextReader(@".\\Alimentos.xml");

            while (x.Read())
            {
                if (x.NodeType == XmlNodeType.Element && x.Name == "Nome")
                    tb_nome.Text = (x.ReadString());
                if (x.NodeType == XmlNodeType.Element && x.Name == "ValorCalorico")
                    tb_valorcalorico.Text = (x.ReadString());
                if (x.NodeType == XmlNodeType.Element && x.Name == "Quantidade")
                    tb_quantidade.Text = (x.ReadString());

            }

            x.Close();
            return;
        }
    }
}

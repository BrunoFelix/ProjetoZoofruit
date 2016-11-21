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

namespace Gui
{
    public partial class Manter_alimento_ed : Form
    {
        const int MF_BYPOSITION = 0x400;
        public string aviso = string.Empty;
        private string nomeDoArquivo = "Alimentos.xml";
        private XElement doc;

        Service1 webservice;
        Alimento alimento;
        public Manter_alimento_ed()
        {
            if (File.Exists(nomeDoArquivo))
            {
                doc = XElement.Load(nomeDoArquivo);
            }
            else
            {
                doc = new XElement("Alimentos");
            }
            InitializeComponent();
            webservice = new Service1();

           
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
            if (this.alimento == null)
            {
                Alimento alimento = new Alimento();
                alimento.Nome = tb_nome.Text;
                alimento.ValorCalorico = double.Parse(tb_valorcalorico.Text);
                alimento.Quantidade = double.Parse(tb_quantidade.Text);
                webservice.InserirAlimento(alimento);
                ((Manter_alimento)Application.OpenForms["manter_alimento"]).btn_pesquisar_Click(sender, e);
            }
            else
            {
                Alimento alimento = new Alimento();
                alimento.Codigo = this.alimento.Codigo;
                alimento.Nome = tb_nome.Text;
                alimento.ValorCalorico = double.Parse(tb_valorcalorico.Text);
                alimento.Quantidade = double.Parse(tb_quantidade.Text);
                webservice.AlterarAlimento(alimento);
                ((Manter_alimento)Application.OpenForms["manter_alimento"]).btn_pesquisar_Click(sender, e);
            }
        }

        private void Manter_alimento_ed_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XElement alimento = new XElement("Alimento");
            alimento.Add(new XElement("Nome", tb_nome.Text));
            alimento.Add(new XElement("ValorCalorico", tb_valorcalorico.Text));
            alimento.Add(new XElement("Quantidade", tb_quantidade.Text));
            doc.Add(alimento);
            doc.Save(nomeDoArquivo);
        }
    }
}

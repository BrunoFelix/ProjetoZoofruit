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
using System.Xml;
using System.Xml.Linq;

namespace Gui
{
    public partial class Manter_tipo_animal_ed : Form
    {
        private string nomeDoArquivo = "TipoAnimal.xml";
        private XElement doc;
        TipoAnimal tipoanimal;
        Service1 webservice;
        public Manter_tipo_animal_ed()
        {
            InitializeComponent();
            try
            {
                this.exibirxml();
                tipoanimal = new TipoAnimal();
                webservice = new Service1();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public Manter_tipo_animal_ed(TipoAnimal ta)
        {
            try
            {
                InitializeComponent();
                webservice = new Service1();

                tipoanimal = ta;

                tb_codigo.Text = tipoanimal.Codigo.ToString();
                tb_descricao.Text = tipoanimal.Descricao;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void gravarxml()
        {
            try
            {
                doc = new XElement("TipoAnimal");
                XElement tipoanimal = new XElement("TipoAnimal");
                tipoanimal.Add(new XElement("Descricao", tb_descricao.Text));
                doc.Add(tipoanimal);
                doc.Save(nomeDoArquivo);
            }
            catch (Exception e)
            {

            }

        }

        public void exibirxml()
        {
            try
            {
                XmlTextReader x = new XmlTextReader(@".\\TipoAnimal.xml");

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "Descricao")
                        tb_descricao.Text = (x.ReadString());
                }
                x.Close();
                return;
            }
            catch (Exception)
            {
                //
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tipoanimal.Codigo == 0)
                {
                    tipoanimal.Descricao = tb_descricao.Text;
                    webservice.InserirTipoAnimal(tipoanimal);
                    destruirxml();
                    ((Manter_tipo_animal)Application.OpenForms["manter_tipo_animal"]).btn_pesquisar_tipo_animal_Click(sender, e);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    TipoAnimal tipoanimal = new TipoAnimal();
                    tipoanimal.Codigo = this.tipoanimal.Codigo;
                    tipoanimal.Descricao = tb_descricao.Text;
                    webservice.AlterarTipoAnimal(tipoanimal);
                    destruirxml();
                    ((Manter_tipo_animal)Application.OpenForms["manter_tipo_animal"]).btn_pesquisar_tipo_animal_Click(sender, e);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.None;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Todos os dados serão perdidos e não poderão ser recuperados, deseja realmente cancelar a operação?", "Zoofruit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                destruirxml();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        public void destruirxml()
        {
            try
            {
                if (System.IO.File.Exists(Application.StartupPath + "\\TipoAnimal.xml"))
                {
                    System.IO.File.Delete(Application.StartupPath + "\\TipoAnimal.xml");
                }
            }
            catch (Exception)
            {
                //
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.gravarxml();
        }

        private void Manter_tipo_animal_ed_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Manter_tipo_animal_ed_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}

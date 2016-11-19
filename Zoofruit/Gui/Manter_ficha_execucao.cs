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

namespace Gui
{
    public partial class Manter_ficha_execucao : Form
    {
        private int tamanho_panel = 10;
        private int altura_panel = 10;
        private int i = 0;
        private int z = 1;
        private double tamanho_form = 0;
        private static Manter_ficha_execucao manter_ficha_execucao;
        List<FichaAlimento> listafichaalimento;
        FichaAlimento fichaalimento = new FichaAlimento();
        Service1 webservice;

        public static Manter_ficha_execucao getInstance()
        {
            if (manter_ficha_execucao == null)
            {
                try
                {
                    manter_ficha_execucao = new Manter_ficha_execucao();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return manter_ficha_execucao;
        }
        private Manter_ficha_execucao()
        {
            InitializeComponent();
            try
            {
                InitializeComponent();
                webservice = new Service1();
                FichaAlimento fichaalimento = new FichaAlimento();
                fichaalimento.Animal = new Animal();
                fichaalimento.Usuario = new Usuario();
                fichaalimento.ListaAlimento = new List<Alimento>().ToArray();
                listafichaalimento = webservice.ListarFichaAlimento(fichaalimento).ToList();
                AtualizarTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AtualizarTela()
        {
            tamanho_form = this.Width;

            /*foreach (Control item in this.Controls.OfType<Panel>())
            {
                this.Controls.Remove(item);

            }*/

            for (int ix = this.Controls.Count - 1; ix >= 0; ix--)
                if ((this.Controls[ix] is Panel) && (this.Controls[ix].Tag != "1")) this.Controls[ix].Dispose();

            tamanho_panel = 10;
            altura_panel = 10;
            i = 0;
            z = 1;



            foreach (FichaAlimento fa in listafichaalimento)
            {
                if (tamanho_panel < (tamanho_form - 150))
                {

                    Button button5 = new Button();
                    //button5.Click += button_Click(fa);
                    button5.Location = new System.Drawing.Point(70, 125);
                    button5.Size = new System.Drawing.Size(80, 20);
                    button5.TabIndex = 0;
                    button5.Text = "Executar";
                    button5.ForeColor = Color.Black;
                    button5.UseVisualStyleBackColor = true;

                    Label c1 = new Label();
                    c1.Text = fa.Animal.Nome;
                    c1.Left = 10;
                    c1.Top = 10;
                    c1.ForeColor = Color.Black;

                    Panel panel1 = new Panel();
                    panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                    panel1.Location = new System.Drawing.Point(tamanho_panel, altura_panel);
                    panel1.Name = "panel_" + fa.Codigo.ToString();
                    panel1.Size = new System.Drawing.Size(213, 150);
                    panel1.TabIndex = 0;
                    tamanho_panel += 223;

                    panel1.Controls.Add(button5);


                    /* panel1.BackgroundImage = Image.FromFile
                           (System.Environment.GetFolderPath
                           (System.Environment.SpecialFolder.Personal)
                           + @"\macaco.JPG");*/
                    panel1.Controls.Add(c1);

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

        private void Manter_ficha_execucao_FormClosed(object sender, FormClosedEventArgs e)
        {
            manter_ficha_execucao = null;
        }

        private void button_Click(FichaAlimento fa)
        {
            MessageBox.Show(fa.Codigo.ToString());
        }

        private void Manter_ficha_execucao_Resize(object sender, EventArgs e)
        {
            AtualizarTela();
        }
    }
}

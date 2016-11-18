using Gui.localhost;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Teste
{
    public class Manter_ficha_execucao : Form
    {
        private int tamanho_panel = 10;
        private int altura_panel = 10;
        private int i = 0;
        private int z = 1;
        private double tamanho_form = 0;
        Service1 webservice;
        public List<FichaAlimento> listafichaanimal;

        public Manter_ficha_execucao()
        {
            InitializeComponent();
            webservice = new Service1();
            Animal animal = new Animal();
            animal.TipoAnimal = new TipoAnimal();
            FichaAlimento fichaalimento = new FichaAlimento();
            fichaalimento.Animal = new Animal();
            fichaalimento.Usuario = new Usuario();
            listafichaanimal = webservice.ListarFichaAlimento(fichaalimento).ToList();
        }

        private void atualizarTela()
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

            

            while (i < 30)
            {
                if (tamanho_panel < (tamanho_form - 150))
                {
                    Label c1 = new Label();
                    c1.Text = z++.ToString();
                    c1.Left = 10;
                    c1.Top = 10;
                    c1.Width = 20;
                    c1.ForeColor = Color.Black;

                    Panel panel1 = new Panel();
                    panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    panel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
                    panel1.Location = new System.Drawing.Point(tamanho_panel, altura_panel);
                    panel1.Name = "panel" + tamanho_panel;
                    panel1.Size = new System.Drawing.Size(213, 150);
                    panel1.TabIndex = 0;
                    tamanho_panel += 223;
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

        private void button1_Click(object sender, EventArgs e)
        {
            atualizarTela();

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void Manter_ficha_execucao_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //this.Location = new Point(100, 100);
            DateTime data2 = DateTime.Now;
            lb_data.Text = DateTime.Now.Day.ToString();
            lb_data.Text = lb_data.Text + "/" + DateTime.Now.Month.ToString();
            lb_data.Text = lb_data.Text + "/" + DateTime.Now.Year.ToString();
            lb_hora.Text = data2.Hour.ToString();
        }

        private void Manter_ficha_execucao_Resize(object sender, EventArgs e)
        {
            atualizarTela();
            panel1.Width = this.Width;
        }
    }

}

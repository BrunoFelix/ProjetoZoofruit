using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Teste
{
    public partial class Form1 : Form
    {
        private int tamanho_panel = 10;
        private int altura_panel = 10;
        private int i = 0;
        private int z = 1;
        private double tamanho_form = 0;

        public Form1()
        {
            InitializeComponent();
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
                    panel1.BackgroundImage = Image.FromFile
                           (System.Environment.GetFolderPath
                           (System.Environment.SpecialFolder.Personal)
                           + @"\macaco.JPG");
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            /*FormWindowState LastWindowState = FormWindowState.Minimized;
            // When window state changes
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;


                if (WindowState == FormWindowState.Maximized)
                {

                    atualizarTela();
                }
                /*if (WindowState == FormWindowState.Normal)
                {

                    atualizarTela();
                }*/
            //}

            //atualizarTela();
            panel1.Width = this.Width;
        }


        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            atualizarTela();
        }

        private void Form1_MaximumSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //this.Location = new Point(100, 100);
            DateTime data2 = DateTime.Now;
            lb_data.Text = DateTime.Now.Day.ToString();
            lb_data.Text = lb_data.Text + "/" + DateTime.Now.Month.ToString();
            lb_data.Text = lb_data.Text + "/" + DateTime.Now.Year.ToString();
            lb_hora.Text = data2.Hour.ToString();
        }

        private void Form1_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            
        }
    }

}

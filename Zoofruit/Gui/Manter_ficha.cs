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
    public partial class Manter_ficha : Form
    {
        public List<Animal> listaanimal;
        private static Manter_ficha manter_ficha;
        Service1 webservice;

        public static Manter_ficha getInstance()
        {
            if (manter_ficha == null)
            {
                try
                {
                    manter_ficha = new Manter_ficha();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return manter_ficha;
        }
        private Manter_ficha()
        {
            InitializeComponent();
            webservice = new Service1();
            listaanimal = new List<Animal>();
        }

        public void AtualizarGrid()
        {
            lv_animal.Items.Clear();

            ListViewItem item;

            foreach (Animal a in listaanimal)
            {
                item = new ListViewItem();
                item.Text = a.Codigo.ToString();
                item.SubItems.Add(a.Nome);
                item.SubItems.Add(a.Cor);
                item.SubItems.Add(a.Porte);
                item.SubItems.Add(Convert.ToString(a.Peso));
                item.SubItems.Add(a.TipoAnimal.Descricao);

                lv_animal.Items.Add(item);
            }
        }


        private void Manter_ficha_Resize(object sender, EventArgs e)
        {
            label3.Left = (this.ClientSize.Width - label3.Width) / 2;
            label1.Left = (this.ClientSize.Width - label3.Width) / 2;
            label2.Left = (this.ClientSize.Width - label3.Width) / 2;
        }

        private void button11_Click(object sender, EventArgs e)
        {
                    }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void btn_pesquisar_animal_Click(object sender, EventArgs e)
        {

        }

        private void btn_novo_animal_Click(object sender, EventArgs e)
        {
            Manter_animal_ed manter_animal_ed = new Manter_animal_ed();
            manter_animal_ed.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lv_animal.SelectedIndices.Count > 0)
            {
                Animal animal = new Animal();
                animal = listaanimal.ElementAt(lv_animal.SelectedIndices[0]);
                Manter_animal_ed manter_animal_ed = new Manter_animal_ed(animal);
                manter_animal_ed.ShowDialog();
            }
        }

        private void Manter_ficha_Load(object sender, EventArgs e)
        {
            comboBox_pesquisar_animal.SelectedIndex = 1;
            Animal animal = new Animal();
            TipoAnimal tipoanimal = new TipoAnimal();
            animal.TipoAnimal = tipoanimal;
            listaanimal = webservice.ListarAnimal(animal).ToList();
            AtualizarGrid();
        }

        private void Manter_ficha_Deactivate(object sender, EventArgs e)
        {
            
        }

        private void Manter_ficha_FormClosed(object sender, FormClosedEventArgs e)
        {
            manter_ficha = null;
        }
    }
}

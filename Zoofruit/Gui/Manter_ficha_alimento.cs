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
    public partial class Manter_ficha_alimento : Form
    {
        public List<Animal> listaanimal;
        public List<FichaAlimento> listafichaanimal;
        private static Manter_ficha_alimento manter_ficha;
        Service1 webservice;
        public Animal animal;

        public static Manter_ficha_alimento getInstance()
        {
            if (manter_ficha == null)
            {
                try
                {
                    manter_ficha = new Manter_ficha_alimento();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return manter_ficha;
        }
        private Manter_ficha_alimento()
        {
            InitializeComponent();
            webservice = new Service1();
            listaanimal = new List<Animal>();
            listafichaanimal = new List<FichaAlimento>();
            animal = new Animal();
            animal.TipoAnimal = new TipoAnimal();
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
            if (comboBox_pesquisar_animal.SelectedIndex == 0)
            {
                try
                {
                    animal.Codigo = Int32.Parse(tb_pesquisar.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }
            else if (comboBox_pesquisar_animal.SelectedIndex == 1)
            {
                try
                {
                    animal.Nome = tb_pesquisar.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }
            else if (comboBox_pesquisar_animal.SelectedIndex == 2)
            {
                try
                {
                    animal.Cor = tb_pesquisar.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }
            else if (comboBox_pesquisar_animal.SelectedIndex == 3)
            {
                try
                {
                    animal.Porte = tb_pesquisar.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }

            }
            else if (comboBox_pesquisar_animal.SelectedIndex == 4)
            {
                try
                {
                    animal.Peso = double.Parse(tb_pesquisar.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }
            else if (comboBox_pesquisar_animal.SelectedIndex == 5)
            {
                try
                {
                    animal.TipoAnimal.Descricao = tb_pesquisar.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }

            listaanimal = webservice.ListarAnimal(animal).ToList();
            AtualizarGrid();
        }

        private void btn_novo_animal_Click(object sender, EventArgs e)
        {
    
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void Manter_ficha_Load(object sender, EventArgs e)
        {
            comboBox_pesquisar_animal.SelectedIndex = 1;
            Animal animal = new Animal();
            animal.TipoAnimal = new TipoAnimal();
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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manter_ficha_alimento_ed manter_ficha_alimento_ed = new Manter_ficha_alimento_ed(1);
            manter_ficha_alimento_ed.ShowDialog();
        }

        public void lv_animal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_animal.SelectedIndices.Count > 0)
            {
                FichaAlimento fichaalimento = new FichaAlimento();
                fichaalimento.Animal = listaanimal.ElementAt(lv_animal.SelectedIndices[0]);
                fichaalimento.Usuario = new Usuario();
                listafichaanimal = webservice.ListarFichaAlimento(fichaalimento).ToList();
                AtualizarGridFicha();

                //AtualizarGridAlimento(listafichaanimal[0]);
            }
        }

        public void AtualizarGridFicha()
        {
            lv_ficha.Items.Clear();

            ListViewItem item;

            foreach (FichaAlimento fa in listafichaanimal)
            {
                item = new ListViewItem();
                item.Text = fa.Codigo.ToString();
                item.SubItems.Add(fa.Descricao);
                item.SubItems.Add(fa.DataCriacao);
                item.SubItems.Add(fa.DataValidade);
                item.SubItems.Add(fa.Usuario.Nome);

                lv_ficha.Items.Add(item);
            }
        }

        public void AtualizarGridAlimento(FichaAlimento fa)
        {
            lv_alimento.Items.Clear();

            ListViewItem item;
            foreach (Alimento a in fa.ListaAlimento)
            {
                item = new ListViewItem();
                item.Text = a.Codigo.ToString();
                item.SubItems.Add(a.Nome);

                lv_alimento.Items.Add(item);
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void lv_ficha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_ficha.SelectedIndices.Count > 0)
            {
                AtualizarGridAlimento(listafichaanimal.ElementAt(lv_ficha.SelectedIndices[0]));
            }
        }
    }
}

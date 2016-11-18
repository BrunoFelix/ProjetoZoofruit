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
    public partial class Manter_animal : Form
    {
        public List<Animal> listaanimal;
        private static Manter_animal manter_animal;
        Service1 webservice;
        public Animal animal;

        public static Manter_animal getInstance()
        {
            if (manter_animal == null)
            {
                try
                {
                    manter_animal = new Manter_animal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return manter_animal;
        }
        private Manter_animal()
        {
            try
            {
                InitializeComponent();
                webservice = new Service1();
                listaanimal = webservice.ListarAnimal(animal).ToList();
                animal = new Animal();
                animal.TipoAnimal = new TipoAnimal();
                AtualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AtualizarGrid()
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_novo_animal_Click(object sender, EventArgs e)
        {
            try
            {
                Manter_animal_ed manter_animal_ed = new Manter_animal_ed();
                manter_animal_ed.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_alterar_animal_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_animal.SelectedIndices.Count > 0)
                {
                    animal = listaanimal.ElementAt(lv_animal.SelectedIndices[0]);
                    Manter_animal_ed manter_animal_ed = new Manter_animal_ed(animal);
                    manter_animal_ed.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_animal.SelectedIndices.Count > 0)
                {
                    if (MessageBox.Show("Deseja remover o registro selecionado?", "Zoofruit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        animal = listaanimal.ElementAt(lv_animal.SelectedIndices[0]);
                        webservice.ExcluirAnimal(animal);
                        AtualizarGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void btn_pesquisar_animal_Click(object sender, EventArgs e)
        {
            if (comboBox_pesquisar_animal.SelectedIndex == 0)
            {
                try
                {
                    animal.Codigo = Int32.Parse(tb_pesquisar.Text);
                }
                catch (Exception)
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
                catch (Exception)
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
                catch (Exception)
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
                catch (Exception)
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
                catch (Exception)
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
                catch (Exception)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }

            try
            {

                listaanimal = webservice.ListarAnimal(animal).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            AtualizarGrid();
        }

        private void Manter_animal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Manter_animal_FormClosed(object sender, FormClosedEventArgs e)
        {
            manter_animal = null;
        }
    }
}

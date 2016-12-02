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
    public partial class Manter_tipo_animal : Form
    {
        public List<TipoAnimal> listatipoanimal;
        private static Manter_tipo_animal manter_tipo_animal;
        Service1 webservice;
        public TipoAnimal tipoAnimal;
        public static Manter_tipo_animal getInstance()
        {
            if (manter_tipo_animal == null)
            {
                try
                {
                    manter_tipo_animal = new Manter_tipo_animal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return manter_tipo_animal;
        }

        private Manter_tipo_animal()
        {
            try
            {
                InitializeComponent();
                webservice = new Service1();
                tipoAnimal = new TipoAnimal();
                listatipoanimal = webservice.ListarTipoAnimal(tipoAnimal).ToList();
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
                lv_tipo_animal.Items.Clear();

                ListViewItem item;

                foreach (TipoAnimal a in listatipoanimal)
                {
                    item = new ListViewItem();
                    item.Text = a.Codigo.ToString();
                    item.SubItems.Add(a.Descricao);

                    lv_tipo_animal.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_tipo_animal.SelectedIndices.Count > 0)
                {
                    if (MessageBox.Show("Deseja remover o registro selecionado?", "Zoofruit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tipoAnimal = listatipoanimal.ElementAt(lv_tipo_animal.SelectedIndices[0]);
                        webservice.ExcluirTipoAnimal(tipoAnimal);
                        listatipoanimal.Remove(tipoAnimal);
                        AtualizarGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void btn_pesquisar_tipo_animal_Click(object sender, EventArgs e)
        {
            TipoAnimal tipoanimal = new TipoAnimal();
            if (comboBox_pesquisar_animal.SelectedIndex == 0)
            {
                try
                {
                    tipoanimal.Codigo = Int32.Parse(tb_pesquisar.Text);
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
                    tipoanimal.Descricao = tb_pesquisar.Text;
                }
                catch (Exception)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }
           
            try
            {

                listatipoanimal = webservice.ListarTipoAnimal(tipoanimal).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            AtualizarGrid();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void btn_novo_animal_Click(object sender, EventArgs e)
        {
            try
            {
                Manter_tipo_animal_ed manter_tipo_animal_ed = new Manter_tipo_animal_ed();
                manter_tipo_animal_ed.ShowDialog();
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
                if (lv_tipo_animal.SelectedIndices.Count > 0)
                {
                    tipoAnimal = listatipoanimal.ElementAt(lv_tipo_animal.SelectedIndices[0]);
                    Manter_tipo_animal_ed manter_tipo_animal_ed = new Manter_tipo_animal_ed(tipoAnimal);
                    manter_tipo_animal_ed.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Manter_tipo_animal_Load(object sender, EventArgs e)
        {

        }

        private void Manter_tipo_animal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Manter_tipo_animal_FormClosed(object sender, FormClosedEventArgs e)
        {
            manter_tipo_animal = null;
        }
    }
}

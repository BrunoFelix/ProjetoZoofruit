
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
    public partial class Manter_alimento : Form
    {
        public List<Alimento> listalimento = new List<Alimento>();
        private static Manter_alimento manter_alimento;
        Service1 webservice;
        public Manter_alimento()
        {
            InitializeComponent();
            webservice = new Service1();
            Alimento alimento = new Alimento();
            listalimento = webservice.ListarAlimento(alimento).ToList();
            AtualizarGrid();
        }
     
        public static Manter_alimento getInstance()
        {
            if (manter_alimento == null)
            {
                try
                {
                    manter_alimento = new Manter_alimento();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return manter_alimento;
        }

        public void AtualizarGrid()
        {
            lv_alimento.Items.Clear();

            ListViewItem item;

            foreach (Alimento a in listalimento)
            {
                item = new ListViewItem();
                item.Text = a.Codigo.ToString();
                item.SubItems.Add(a.Nome);
                item.SubItems.Add(a.ValorCalorico.ToString());
                item.SubItems.Add(a.Quantidade.ToString());

                lv_alimento.Items.Add(item);
            }
        }

        private void Manter_alimento_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Manter_alimento_KeyDown);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Manter_alimento_ed manter_alimento_ed = new Manter_alimento_ed();
            manter_alimento_ed.ShowDialog();
        }

        private void Manter_alimento_FormClosed(object sender, FormClosedEventArgs e)
        {
            manter_alimento = null;
        }

        public void btn_pesquisar_Click(object sender, EventArgs e)
        {
            Alimento alimento = new Alimento();
            if (comboBoxPesquisar.SelectedIndex == 0)
            {
                try
                {
                    alimento.Codigo = Int32.Parse(tb_pesquisar.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }
            else if (comboBoxPesquisar.SelectedIndex == 1)
            {
                try
                {
                    alimento.Nome = tb_pesquisar.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }
            else if (comboBoxPesquisar.SelectedIndex == 2)
            {
                try
                {
                    alimento.ValorCalorico = Convert.ToDouble(tb_pesquisar.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }

            }
            else if (comboBoxPesquisar.SelectedIndex == 3)
            {
                try
                {
                    alimento.Quantidade = Convert.ToDouble(tb_pesquisar.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }

            listalimento = webservice.ListarAlimento(alimento).ToList();
            AtualizarGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Alimento alimento = new Alimento();
            listalimento = webservice.ListarAlimento(alimento).ToList();
            AtualizarGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lv_alimento.SelectedIndices.Count > 0)
            {
                if (MessageBox.Show("Deseja remover o registro selecionado?", "Zoofruit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    webservice.ExcluirAlimento(listalimento.ElementAt(lv_alimento.SelectedIndices[0]));
                    listalimento.Remove(listalimento.ElementAt(lv_alimento.SelectedIndices[0]));
                    MessageBox.Show("Removido com sucesso!");
                    AtualizarGrid();
                }
            }
        }

        private void Manter_alimento_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Manter_alimento_KeyDown(object sender, KeyEventArgs e)
        {       
            if (e.KeyCode.ToString() == "F2")
            {
                button1_Click_1(sender, e);
            }
            else if (e.KeyCode.ToString() == "F3")
            {
                button2_Click(sender, e);
            }
            else if (e.KeyCode.ToString() == "F4")
            {
                button3_Click(sender, e);
            }
            else if (e.KeyCode.ToString() == "F5")
            {
                btn_pesquisar_Click(sender, e);
            }
            else if (e.KeyCode.ToString() == "F6")
            {
                button4_Click(sender, e);
            }
        }
    }
}

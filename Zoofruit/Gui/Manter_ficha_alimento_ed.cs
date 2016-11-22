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
    public partial class Manter_ficha_alimento_ed : Form
    {

        int tipoficha;
        Service1 webservice;
        FichaAlimento fichaalimento;
        public List<Alimento> listaalimento = new List<Alimento>();
        private Animal animal;
        private Usuario usuario;
        public Manter_ficha_alimento_ed(int tipoficha, Animal a, Usuario u)
        {
            try { 
                InitializeComponent();
                this.tipoficha = tipoficha;
                webservice = new Service1();

                if (tipoficha != 1)
                {
                    label3.Visible = false;
                    tb_qtd_max_cal.Visible = false;
                }
                animal = a;
                usuario = u;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void atualizarGridALimento()
        {
            try
            {
                lv_alimento.Items.Clear();

                ListViewItem item;

                foreach (Alimento a in listaalimento)
                {
                    item = new ListViewItem();
                    item.Text = a.Codigo.ToString();
                    item.SubItems.Add(a.Nome);
                    item.SubItems.Add(a.ValorCalorico.ToString());
                    item.SubItems.Add(a.Quantidade.ToString());

                    lv_alimento.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_novo_animal_Click(object sender, EventArgs e)
        {
            try
            {
                Manter_ficha_buscar_alimento_ed manter_ficha_buscar_alimento_ed = new Manter_ficha_buscar_alimento_ed();
                manter_ficha_buscar_alimento_ed.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                fichaalimento = new FichaAlimento();
                fichaalimento.Descricao = tb_descricao.Text;
                fichaalimento.DataCriacao = dtp_validade.Text;
                fichaalimento.DataValidade = dtp_validade.Text;
                fichaalimento.Qtd_max_cal = Convert.ToDouble(tb_qtd_max_cal.Text);
                fichaalimento.Hora_a_ser_executado = tb_hora_a_ser_executada.Text;
                fichaalimento.Usuario = usuario;
                fichaalimento.Animal = animal;
                fichaalimento.ListaAlimento = listaalimento.ToArray();
                webservice.InserirFichaAlimento(fichaalimento);

                ((Manter_ficha_alimento)Application.OpenForms["manter_ficha_alimento"]).lv_animal_SelectedIndexChanged(sender, e);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_alimento.SelectedIndices.Count > 0)
                {
                    if (MessageBox.Show("Deseja remover o alimento selecionado da ficha?", "Zoofruit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        listaalimento.Remove(listaalimento.ElementAt(lv_alimento.SelectedIndices[0]));
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tb_hora_a_ser_executada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }
    }
}

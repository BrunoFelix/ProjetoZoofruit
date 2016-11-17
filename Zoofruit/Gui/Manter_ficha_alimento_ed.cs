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
        public Manter_ficha_alimento_ed(int tipoficha, Animal a)
        {
            InitializeComponent();
            this.tipoficha = tipoficha;
            webservice = new Service1();

            if (tipoficha != 1)
            {
                label3.Visible = false;
                tb_qtd_max_cal.Visible = false;
            }
            animal = a;
        }

        public void atualizarGridALimento()
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

        private void btn_novo_animal_Click(object sender, EventArgs e)
        {
            Manter_ficha_buscar_alimento_ed manter_ficha_buscar_alimento_ed = new Manter_ficha_buscar_alimento_ed();
            manter_ficha_buscar_alimento_ed.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fichaalimento = new FichaAlimento();
            fichaalimento.Descricao = tb_descricao.Text;
            fichaalimento.DataCriacao = dtp_validade.Text;
            fichaalimento.DataValidade = dtp_validade.Text;
            try
            {
                fichaalimento.Qtd_max_cal = Convert.ToDouble(tb_qtd_max_cal.Text);
            }catch (Exception ex)
            {
                MessageBox.Show("Quantidade máxima de calórias inválida!");
            }
            fichaalimento.Usuario = new Usuario();
            fichaalimento.Usuario.Codigo = 1;
            fichaalimento.Animal = new Animal();
            fichaalimento.Animal.Codigo = 1;
            fichaalimento.ListaAlimento = listaalimento.ToArray();
            webservice.InserirFichaAlimento(fichaalimento);

            ((Manter_ficha_alimento)Application.OpenForms["manter_ficha_alimento"]).lv_animal_SelectedIndexChanged(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lv_alimento.SelectedIndices.Count > 0)
            {
                if (MessageBox.Show("Deseja remover o alimento selecionado da ficha?", "Zoofruit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listaalimento.Remove(listaalimento.ElementAt(lv_alimento.SelectedIndices[0]));                
                }
            }
        }
    }
}

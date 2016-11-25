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
    public partial class Manter_ficha_execucao_ed : Form
    {
        public List<Alimento> listalimento = new List<Alimento>();
        public List<Alimento> listacardapio = new List<Alimento>();
        double qtd_max_cal = 0;
        FichaAlimento fichaalimento;
        Service1 webservice;
        Usuario usuario;
        public Manter_ficha_execucao_ed(FichaAlimento fa, Usuario u)
        {
            try
            {
                InitializeComponent();
                fichaalimento = fa;
                usuario = u;
                webservice = new Service1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Manter_ficha_execucao_ed_Load(object sender, EventArgs e)
        {
            try
            {
                lb_codigo_ficha.Text = "Código: " + fichaalimento.Codigo.ToString();
                lb_animal_ficha.Text = "Animal: " + fichaalimento.Animal.Codigo.ToString() + " - " + fichaalimento.Animal.Nome;
                lb_usuario_ficha.Text = "Usuário Resp.: " + fichaalimento.Usuario.Nome + " (" + fichaalimento.Usuario.Login + ")";
                lb_qtd_max_cal_ficha.Text = "Qtd. Máx. Cal.: " + fichaalimento.Qtd_max_cal.ToString();
                lb_dt_criacao_ficha.Text = "Data Criação: " + fichaalimento.DataCriacao;
                lb_data_validade_ficha.Text = "Data Validade: " + fichaalimento.DataValidade;

                listalimento = webservice.PesquisarAlimentoFichaExecucaoAlimento(fichaalimento.Codigo, true).ToList();
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
                lv_alimento.Items.Clear();

                ListViewItem item;

                foreach (Alimento a in listalimento)
                {
                    item = new ListViewItem();
                    item.Text = a.Codigo.ToString();
                    item.SubItems.Add(a.Nome);
                    item.SubItems.Add(a.ValorCalorico.ToString());

                    lv_alimento.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AtualizarGridCardápio()
        {
            try
            {
                lv_cardapio.Items.Clear();

                qtd_max_cal = 0;

                ListViewItem item;

                foreach (Alimento a in listacardapio)
                {
                    item = new ListViewItem();
                    item.Text = a.Codigo.ToString();
                    item.SubItems.Add(a.Nome);
                    item.SubItems.Add(a.ValorCalorico.ToString());
                    item.SubItems.Add(a.Quantidade.ToString());

                    qtd_max_cal += (double) (a.ValorCalorico * a.Quantidade);

                    lv_cardapio.Items.Add(item);
                }

                lb_total_calorias.Text = "Quantidade de calórias do cardápio: " + qtd_max_cal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Manter_ficha_execucao_ed_Resize(object sender, EventArgs e)
        {
            lb_montar_cardapio.Left = (this.ClientSize.Width - lb_montar_cardapio.Width) / 2;
            lb_alimentos_permitidos.Left = (this.ClientSize.Width - lb_montar_cardapio.Width) / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_alimento.SelectedIndices.Count > 0)
                {
                    if (tb_quantidade.Text == "")
                    {
                        MessageBox.Show("Informe a quantidade!");
                        tb_quantidade.Focus();
                    }
                    Alimento alimento = listalimento.ElementAt(lv_alimento.SelectedIndices[0]);
                    alimento.Quantidade = Convert.ToInt32(tb_quantidade.Text);
                    listacardapio.Add(alimento);
                    AtualizarGridCardápio();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tb_quantidade.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_cardapio.SelectedIndices.Count > 0)
                {
                    if (MessageBox.Show("Deseja remover o registro selecionado?", "Zoofruit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        qtd_max_cal -= (double)(listacardapio.ElementAt(lv_alimento.SelectedIndices[0]).ValorCalorico * listacardapio.ElementAt(lv_alimento.SelectedIndices[0]).Quantidade);
                        listacardapio.Remove(listacardapio.ElementAt(lv_cardapio.SelectedIndices[0]));
                        AtualizarGridCardápio();
                    }
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
                FichaExecucaoAlimento fea = new FichaExecucaoAlimento();
                fea.ListaAlimento = listacardapio.ToArray();
                fea.Usuario = usuario;
                fea.Observacao = rtb_obs.Text;
                fea.FichaAlimento = fichaalimento;
                fea.DataExecucao = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " +
                    DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                webservice.Salvar(fea, qtd_max_cal, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tb_quantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }
    }
}

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
using System.Xml;
using System.Xml.Linq;

namespace Gui
{
    public partial class Manter_ficha_execucao_ed : Form
    {
        private string nomeDoArquivo = "FichaAlimentosExecucao.xml";
        private XElement doc;
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
                this.exibirxml();
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
                timer1.Enabled = true;
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


        public void gravarxml()
        {
            try
            {
                doc = new XElement("FichaAlimentoExecucao");
                XElement fichaAlimentoExecucao = new XElement("FichaAlimentoExecucao");

                fichaAlimentoExecucao.Add(new XElement("Observacao", rtb_obs.Text));
                fichaAlimentoExecucao.Add(new XElement("qtx_max_cal_cardapio", qtd_max_cal));

                IList<Alimento> alimento = new List<Alimento>();

                foreach (ListViewItem listViewItem in this.lv_cardapio.Items)
                {

                    alimento.Add(new Alimento { Codigo = Convert.ToInt32(listViewItem.SubItems[0].Text), Nome = listViewItem.SubItems[1].Text, Quantidade = Convert.ToDouble(listViewItem.SubItems[2].Text), ValorCalorico = Convert.ToDouble(listViewItem.SubItems[3].Text) });
                }

                fichaAlimentoExecucao.Add(new XElement("Alimentos",
                    from na in alimento
                    select new XElement("Alimento",
                            new XElement("Codigo", na.Codigo),
                            new XElement("Nome", na.Nome),
                            new XElement("Quantidade", na.Quantidade),
                            new XElement("ValorCalorico", na.ValorCalorico))));

                doc.Add(fichaAlimentoExecucao);
                doc.Save(nomeDoArquivo);
            }
            catch (Exception e)
            {

            }

        }

        /*Metodo Exibir XML*/
        public void exibirxml()
        {
            try
            {
                XmlTextReader x = new XmlTextReader(@".\\" + nomeDoArquivo);

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "Observacao")
                        rtb_obs.Text = (x.ReadString());
                    if (x.NodeType == XmlNodeType.Element && x.Name == "qtx_max_cal_cardapio")
                        qtd_max_cal = Convert.ToDouble(x.ReadString());
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(@".\\" + nomeDoArquivo); //Carregando o arquivo

                //Pegando elemento pelo nome da TAG
                XmlNodeList xnList = xmlDoc.GetElementsByTagName("Alimento");

                //Usando for para imprimir na tela
                for (int i = 0; i < xnList.Count; i++)
                {
                    Alimento alimento = new Alimento();
                    alimento.Codigo = Convert.ToInt32(xnList[i]["Codigo"].InnerText);
                    alimento.Nome = xnList[i]["Nome"].InnerText;
                    alimento.Quantidade = Convert.ToInt32(xnList[i]["Quantidade"].InnerText);
                    alimento.ValorCalorico = Convert.ToInt32(xnList[i]["ValorCalorico"].InnerText);
                    listacardapio.Add(alimento);
                }

                AtualizarGridCardápio();
                return;
            }
            catch (Exception e)
            {
                //
            }
        }

        public void destruirxml()
        {
            try
            {
                if (System.IO.File.Exists(Application.StartupPath + "\\" + nomeDoArquivo))
                {
                    System.IO.File.Delete(Application.StartupPath + "\\" + nomeDoArquivo);
                }
            }
            catch (Exception ex)
            {
                //
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

                FichaAlimento fichaalimento2 = new FichaAlimento();
                fichaalimento2.Animal = new Animal();
                fichaalimento2.Usuario = new Usuario();
                fichaalimento2.ListaAlimento = new List<Alimento>().ToArray();
                fichaalimento2.DataValidade = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                fichaalimento2.Hora_a_ser_executado = DateTime.Now.Hour.ToString();

                destruirxml();

                ((Manter_ficha_execucao)Application.OpenForms["manter_ficha_execucao"]).listafichaalimento = webservice.ListarFichaAlimento(fichaalimento2).ToList();
                ((Manter_ficha_execucao)Application.OpenForms["manter_ficha_execucao"]).AtualizarTela();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.None;
            }
        }

        private void tb_quantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.gravarxml();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Todos os dados serão perdidos e não poderão ser recuperados, deseja realmente cancelar a operação?", "Zoofruit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                destruirxml();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void Manter_ficha_execucao_ed_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}

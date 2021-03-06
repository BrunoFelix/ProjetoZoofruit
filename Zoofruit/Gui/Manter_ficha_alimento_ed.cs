﻿using Gui.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Gui
{
    public partial class Manter_ficha_alimento_ed : Form
    {

        private string nomeDoArquivo = "FichaAlimentos.xml";
        private XElement doc;
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
                this.exibirxml();
                this.tipoficha = tipoficha;
                webservice = new Service1();

                if (tipoficha != 1)
                {
                    label3.Visible = false;
                    tb_qtd_max_cal.Visible = false;
                }
                animal = a;
                usuario = u;
                dtp_validade.Value = Convert.ToDateTime(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
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
            string codigo;
            try
            {            
                fichaalimento = new FichaAlimento();
                fichaalimento.Descricao = tb_descricao.Text;
                fichaalimento.DataCriacao = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                fichaalimento.DataValidade = dtp_validade.Value.ToString("yyyy-MM-dd");
                try
                {
                    fichaalimento.Qtd_max_cal = Convert.ToDouble(tb_qtd_max_cal.Text);
                }catch (Exception)
                {
                    MessageBox.Show("Quantida de Máxima de Calórias Inválida!");
                    this.DialogResult = DialogResult.None;
                    tb_qtd_max_cal.Focus();
                    return;
                }
                fichaalimento.Hora_a_ser_executado = tb_hora_a_ser_executada.Text;
                fichaalimento.Usuario = usuario;
                fichaalimento.Animal = animal;
                fichaalimento.ListaAlimento = listaalimento.ToArray();
                codigo = webservice.InserirFichaAlimento(fichaalimento).Codigo.ToString();

                try
                {
                    Program.binaryWriter.Write(codigo);
                }
                catch (Exception)
                {
                    //
                }

                destruirxml();
                this.DialogResult = DialogResult.OK;

                ((Manter_ficha_alimento)Application.OpenForms["manter_ficha_alimento"]).lv_animal_SelectedIndexChanged(sender, e);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.None;
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

        private void Manter_ficha_alimento_ed_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*tcpListener.Stop();
            Environment.Exit(0);*/
            timer1.Enabled = false;
        }

        private void tb_qtd_max_cal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void Manter_ficha_alimento_ed_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        /*Metodo Gravar XML*/
        public void gravarxml()
        {
            try
            {
                doc = new XElement("FichaAlimentos");
                XElement fichaAlimento = new XElement("FichaAlimento");
                fichaAlimento.Add(new XElement("Descricao", tb_descricao.Text));
                fichaAlimento.Add(new XElement("DataValidade", dtp_validade.Text));
                fichaAlimento.Add(new XElement("HoraExecusao", tb_hora_a_ser_executada.Text));
                fichaAlimento.Add(new XElement("QuantidadeMaximaCaloria", tb_qtd_max_cal.Text));

                //Alimento alimento = listaalimento.ElementAt(lv_alimento.SelectedIndices[0]);

                IList<Alimento> alimento = new List<Alimento>();

                foreach (ListViewItem listViewItem in this.lv_alimento.Items)
                {
                    
                    alimento.Add(new Alimento { Codigo = Convert.ToInt32(listViewItem.SubItems[0].Text), Nome = listViewItem.SubItems[1].Text, ValorCalorico = Convert.ToDouble(listViewItem.SubItems[2].Text) });
                }

                fichaAlimento.Add(new XElement("Alimentos",    
                    from na in alimento
                    select new XElement("Alimento",
                            new XElement("Codigo", na.Codigo),
                            new XElement("Nome", na.Nome),
                            new XElement("ValorCalorico", na.ValorCalorico))));

                doc.Add(fichaAlimento);
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
                    if (x.NodeType == XmlNodeType.Element && x.Name == "Descricao")
                        tb_descricao.Text = (x.ReadString());
                    if (x.NodeType == XmlNodeType.Element && x.Name == "DataValidade")
                        dtp_validade.Text = (x.ReadString());
                    if (x.NodeType == XmlNodeType.Element && x.Name == "HoraExecusao")
                        tb_hora_a_ser_executada.Text = (x.ReadString());
                    if (x.NodeType == XmlNodeType.Element && x.Name == "QuantidadeMaximaCaloria")
                        tb_qtd_max_cal.Text = (x.ReadString());
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
                    alimento.ValorCalorico = Convert.ToInt32(xnList[i]["ValorCalorico"].InnerText);
                    listaalimento.Add(alimento);
                }

                    x.Close();
                atualizarGridALimento();
                return;
            }
            catch (Exception e)
            {

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
            catch (Exception)
            {
                //
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
    }
}

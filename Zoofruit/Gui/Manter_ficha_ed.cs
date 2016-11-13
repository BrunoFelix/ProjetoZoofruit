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
    public partial class Manter_ficha_ed : Form
    {

        int tipoficha;
        Service1 webservice;
        FichaAlimento fichaalimento;
        public Manter_ficha_ed(int tipoficha)
        {
            InitializeComponent();
            this.tipoficha = tipoficha;
            webservice = new Service1();

            if (tipoficha != 1)
            {
                label3.Visible = false;
                tb_qtd_max_cal.Visible = false;
            }
        }

        private void btn_novo_animal_Click(object sender, EventArgs e)
        {
            Manter_ficha_alimento_ed manter_ficha_alimento_ed = new Manter_ficha_alimento_ed();
            manter_ficha_alimento_ed.ShowDialog();
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
            }catch (ArithmeticException ex)
            {
                MessageBox.Show("Quantidade máxima de calórias inválida!");
            }
            fichaalimento.usuario = new Usuario();
            fichaalimento.usuario.Codigo = 1;
            fichaalimento.animal = new Animal();
            fichaalimento.animal.Codigo = 1;
            fichaalimento.listaAlimento = new List<Alimento>().ToArray();
            webservice.InserirFichaAlimento(fichaalimento);

            ((Manter_ficha)Application.OpenForms["manter_ficha"]).lv_animal_SelectedIndexChanged(sender, e);
        }
    }
}

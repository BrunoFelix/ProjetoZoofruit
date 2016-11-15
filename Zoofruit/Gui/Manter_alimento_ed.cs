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
    public partial class Manter_alimento_ed : Form
    {
      
        Service1 webservice;
        Alimento alimento;
        public Manter_alimento_ed()
        {
            InitializeComponent();
            webservice = new Service1();
           
        }

        private void btnconfirmar_Click_1(object sender, EventArgs e)
        {
            if (this.alimento == null)
            {
                Alimento alimento = new Alimento();
                alimento.Nome = tb_nome.Text;
                alimento.ValorCalorico = double.Parse(tb_valorcalorico.Text);
                alimento.Quantidade = double.Parse(tb_quantidade.Text);
                webservice.InserirAlimento(alimento);
                ((Manter_alimento)Application.OpenForms["manter_alimento"]).btn_pesquisar_Click(sender, e);
            }
            else
            {
                Alimento alimento = new Alimento();
                alimento.Nome = tb_nome.Text;
                alimento.ValorCalorico = double.Parse(tb_valorcalorico.Text);
                alimento.Quantidade = double.Parse(tb_quantidade.Text);
                webservice.AlterarAlimento(alimento);
                ((Manter_alimento)Application.OpenForms["manter_alimento"]).btn_pesquisar_Click(sender, e);
            }
        }
    }
}

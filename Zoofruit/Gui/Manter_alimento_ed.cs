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
       // Alimento alimento;
        public Manter_alimento_ed()
        {
            InitializeComponent();
           
        }

 

        private void btnconfirmar_Click(object sender, EventArgs e)
        {
            if (this.alimento == null)
            {
                Alimento alimento = new Alimento();
                alimento.Nome = tb_nome.Text;
                alimento.ValorCalorico = double.Parse(tb_valorcalorico.Text);
                alimento.Quantidade = double.Parse(tb_quantidade.Text);
                alimento.DataReposicao = tb_dataultimareposicao.Text;
                webservice.InserirAlimento(alimento);             
            }
            else
            {
                Alimento alimento = new Alimento();
                alimento.Nome = tb_nome.Text;
                alimento.ValorCalorico = double.Parse(tb_valorcalorico.Text);
                alimento.Quantidade = double.Parse(tb_quantidade.Text);
                alimento.DataReposicao = tb_dataultimareposicao.Text;
                webservice.AlterarAlimento(alimento);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.alimento == null)
            {
                Alimento alimento = new Alimento();
                alimento.Nome = tb_nome.Text;
                alimento.ValorCalorico = double.Parse(tb_valorcalorico.Text);
                alimento.Quantidade = double.Parse(tb_quantidade.Text);
                alimento.DataReposicao = tb_dataultimareposicao.Text;
                webservice.InserirAlimento(alimento);
            }
            else
            {
                Alimento alimento = new Alimento();
                alimento.Nome = tb_nome.Text;
                alimento.ValorCalorico = double.Parse(tb_valorcalorico.Text);
                alimento.Quantidade = double.Parse(tb_quantidade.Text);
                alimento.DataReposicao = tb_dataultimareposicao.Text;
                webservice.AlterarAlimento(alimento);
            }

        }
    }
}

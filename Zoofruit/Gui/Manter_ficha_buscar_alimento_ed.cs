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
    public partial class Manter_ficha_buscar_alimento_ed : Form
    {
        public List<Alimento> listalimento = new List<Alimento>();
        Service1 webservice;
        public Manter_ficha_buscar_alimento_ed()
        {
            InitializeComponent();
            webservice = new Service1();
            Alimento alimento = new Alimento();
            listalimento = webservice.ListarAlimento(alimento).ToList();
            AtualizarGrid();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Alimento alimento = new Alimento();

            if (lv_alimento.SelectedIndices.Count > 0)
            {
                alimento = listalimento.ElementAt(lv_alimento.SelectedIndices[0]);

                bool achou = false;
        
                foreach(Alimento a in ((Manter_ficha_alimento_ed)Application.OpenForms["manter_ficha_alimento_ed"]).listaalimento)
                {
                    if (a.Codigo == alimento.Codigo)
                    {
                        achou = true;
                    }
                }

                if (!achou) {

                    ((Manter_ficha_alimento_ed)Application.OpenForms["manter_ficha_alimento_ed"]).listaalimento.Add(alimento);
                    ((Manter_ficha_alimento_ed)Application.OpenForms["manter_ficha_alimento_ed"]).atualizarGridALimento();  
                }
                else
                {
                    MessageBox.Show("Alimento já adicionado anteriormente!");
                    this.DialogResult = DialogResult.None;
                }
            }
        }

        private void btn_pesquisar_animal_Click(object sender, EventArgs e)
        {
            Alimento alimento = new Alimento();
            alimento.Nome = tb_pesquisar.Text;
            listalimento = webservice.ListarAlimento(alimento).ToList();
            AtualizarGrid();
        }
    }
}

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
        public List<Alimento> listalimento = new List<Alimento>();
        Service1 webservice;
        public Manter_ficha_alimento_ed()
        {
            InitializeComponent();
            webservice = new Service1();
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
    }
}

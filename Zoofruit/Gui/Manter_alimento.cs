
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
    public partial class Manter_alimento : Form
    {
        //public List<Alimento> listalimento = new List<Alimento>();
        private static Manter_alimento manter_alimento;
        public Manter_alimento()
        {
            InitializeComponent();
        }
     
        public static Manter_alimento getInstance()
        {
            if (manter_alimento == null)
            {
                try
                {
                    manter_alimento = new Manter_alimento();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return manter_alimento;
        }

        public void AtualizarGrid()
        {
            /*lv_alimento.Items.Clear();

            ListViewItem item;

            foreach (Alimento a in listalimento)
            {
                item = new ListViewItem();
                item.Text = a.Codigo.ToString();
                item.SubItems.Add(a.Nome);
                item.SubItems.Add(a.ValorCalorico.ToString());
                item.SubItems.Add(a.Quantidade.ToString());
                item.SubItems.Add(a.DataReposicao.ToString());
            
               // listalimento.Items.Add(item);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manter_alimento_ed manter_alimento_ed = new Manter_alimento_ed();
            manter_alimento_ed.ShowDialog();
        }

        private void Manter_alimento_Load(object sender, EventArgs e)
        {

        }
    }
}

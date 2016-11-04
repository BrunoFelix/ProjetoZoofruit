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
        public Manter_alimento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manter_alimento_ed manter_alimento_ed = new Manter_alimento_ed();
            manter_alimento_ed.ShowDialog();
        }
    }
}

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
        public Manter_ficha_ed(int tipoficha)
        {
            InitializeComponent();
            this.tipoficha = tipoficha;

            if (tipoficha != 1)
            {
                label3.Visible = false;
                tb_qtd_max_cal.Visible = false;
            }
        }
    }
}

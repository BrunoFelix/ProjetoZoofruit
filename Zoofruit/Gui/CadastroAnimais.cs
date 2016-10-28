using Biblioteca.basica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui
{
    public partial class CadastroAnimais : Form
    {
        Animal a = new Animal();

        public CadastroAnimais()
        {
            InitializeComponent();
            
        }

        private void CadastroAnimais_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivo = openFileDialog1.FileName;
                Bitmap bmp = new Bitmap(nomeArquivo);
                ptbAnimal.Image = bmp;

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Bmp);
                a.Foto = ms.ToArray();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

        }
    }
}

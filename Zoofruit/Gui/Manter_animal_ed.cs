using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gui.localhost;

namespace Gui
{
    public partial class Manter_animal_ed : Form
    {
        List<TipoAnimal> listatipoanimal;
        TipoAnimal tipoanimal;
        Service1 webservice;
        Animal animal;
        public Manter_animal_ed()
        {
            try
            {
                InitializeComponent();
                listatipoanimal = new List<TipoAnimal>();
                tipoanimal = new TipoAnimal();
                webservice = new Service1();
                animal = new Animal();

                listatipoanimal = webservice.ListarTipoAnimal(tipoanimal).ToList();
                foreach (TipoAnimal a in listatipoanimal)
                {
                    comboBox1.Items.Add(a.Descricao);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Manter_animal_ed(Animal a)
        {
            try
            {
                InitializeComponent();
                listatipoanimal = new List<TipoAnimal>();
                tipoanimal = new TipoAnimal();
                webservice = new Service1();
                animal = new Animal();

                listatipoanimal = webservice.ListarTipoAnimal(tipoanimal).ToList();
                //listatipoanimal = webservice.ListarTipoUsuario(tipoanimal).ToList();
                foreach (TipoAnimal ta in listatipoanimal)
                {
                    comboBox1.Items.Add(ta.Descricao);
                }
                animal = a;

                tb_codigo.Text = animal.Codigo.ToString();
                tb_nome.Text = animal.Nome;
                tb_cor.Text = animal.Cor;
                tb_peso.Text = animal.Peso.ToString();
                tb_porte.Text = animal.Porte;

                int index = comboBox1.FindString(animal.TipoAnimal.Descricao);
                comboBox1.SelectedIndex = index;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddFoto_Click(object sender, EventArgs e)
        {
            /*if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivo = openFileDialog1.FileName;
                Bitmap bmp = new Bitmap(nomeArquivo);
                ptbAnimal.Image = bmp;

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Bmp);
                animal.Foto = ms.ToArray();
            }*/
        }

        private void tb_peso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8) && (e.KeyChar != 188))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.animal.Codigo == 0)
                {
                    animal.Nome = tb_nome.Text;
                    animal.Cor = tb_cor.Text;
                    animal.Porte = tb_porte.Text;
                    try
                    {
                        animal.Peso = Int32.Parse(tb_peso.Text);
                    }catch (Exception)
                    {
                        animal.Peso = null;
                    }
                    //animal.Foto = tb_senha.Text;
                    try
                    {
                        tipoanimal = listatipoanimal.ElementAt(comboBox1.SelectedIndex);
                    }
                    catch (Exception)
                    {
                        tipoanimal = null;
                    }
                        animal.TipoAnimal = tipoanimal;
                    webservice.InserirAnimal(animal);
                    ((Manter_animal)Application.OpenForms["manter_animal"]).btn_pesquisar_animal_Click(sender, e);
                }
                else
                {
                    Animal animal = new Animal();
                    animal.Codigo = this.animal.Codigo;
                    animal.Nome = tb_nome.Text;
                    animal.Cor = tb_cor.Text;
                    animal.Porte = tb_porte.Text;
                    try
                    {
                        animal.Peso = Int32.Parse(tb_peso.Text);
                    }
                    catch (Exception)
                    {
                        animal.Peso = null;
                    }
                    //animal.Foto = tb_senha.Text;
                    try
                    {
                        tipoanimal = listatipoanimal.ElementAt(comboBox1.SelectedIndex);
                    }
                    catch (Exception)
                    {
                        tipoanimal = null;
                    }
                    animal.TipoAnimal = tipoanimal;
                    webservice.AlterarAnimal(animal);
                    ((Manter_animal)Application.OpenForms["manter_animal"]).btn_pesquisar_animal_Click(sender, e);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}

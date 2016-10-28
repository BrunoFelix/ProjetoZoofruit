using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Gui.tela_login tela_login = new Gui.tela_login();

            if (tela_login.ShowDialog() == DialogResult.OK)
            {
                Principal principal = new Principal();
                Application.Run(principal);
            }
        }
    }
}

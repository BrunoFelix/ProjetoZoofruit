using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    public class Usuario
    {
        private int codigo;
        private string cpf;
        private string login;
        private string senha;
        private string crmv;
        public TipoUsuario tipousuario;

        public Usuario()
        {
            tipousuario = new TipoUsuario();
            
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }

        public string Crmv
        {
            get
            {
                return crmv;
            }

            set
            {
                crmv = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    [Serializable]
    [DataContract()]
    public class Usuario
    {
        private int codigo;
        private string nome;
        private string cpf;
        private string login;
        private string senha;
        private string crmv;
        private TipoUsuario tipousuario;

        public Usuario()
        {
            Tipousuario = new TipoUsuario();
        }

        [DataMember(IsRequired = true)]
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
        [DataMember(IsRequired = true)]
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
        [DataMember(IsRequired = true)]
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
        [DataMember(IsRequired = true)]
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
        [DataMember(IsRequired = true)]
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
        [DataMember(IsRequired = true)]
        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }
        [DataMember(IsRequired = true)]
        public TipoUsuario Tipousuario
        {
            get
            {
                return tipousuario;
            }

            set
            {
                tipousuario = value;
            }
        }
    }
}

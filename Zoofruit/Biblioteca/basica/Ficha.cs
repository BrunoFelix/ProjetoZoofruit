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
    public abstract class Ficha
    {
        private int codigo;
        private string descricao;
        private string dataCriacao;
        private string dataValidade;
        private Usuario usuario;
        private Animal animal;

        public Ficha()
        {
            Animal = new Animal();
            Usuario = new Usuario();
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
        public string DataCriacao
        {
            get
            {
                return dataCriacao;
            }

            set
            {
                dataCriacao = value;
            }
        }
        [DataMember(IsRequired = true)]
        public string DataValidade
        {
            get
            {
                return dataValidade;
            }

            set
            {
                dataValidade = value;
            }
        }
        [DataMember(IsRequired = true)]
        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }
        [DataMember(IsRequired = true)]
        public Usuario Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }
        [DataMember(IsRequired = true)]
        public Animal Animal
        {
            get
            {
                return animal;
            }

            set
            {
                animal = value;
            }
        }
    }
}

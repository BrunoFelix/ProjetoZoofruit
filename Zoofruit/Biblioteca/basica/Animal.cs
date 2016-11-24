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
    public class Animal
    {
        private int codigo;
        private string nome;
        private byte[] foto;
        private string cor;
        private string porte;
        private Nullable<double> peso;
        private TipoAnimal tipoAnimal;

        public Animal()
        {
            tipoAnimal = new TipoAnimal();
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

        public byte[] Foto
        {
            get
            {
                return foto;
            }

            set
            {
                foto = value;
            }
        }

        [DataMember(IsRequired = true)]
        public string Cor
        {
            get
            {
                return cor;
            }

            set
            {
                cor = value;
            }
        }

        [DataMember(IsRequired = true)]
        public string Porte
        {
            get
            {
                return porte;
            }

            set
            {
                porte = value;
            }
        }



        [DataMember(IsRequired = true)]
        public TipoAnimal TipoAnimal
        {
            get
            {
                return tipoAnimal;
            }

            set
            {
                tipoAnimal = value;
            }
        }

        [DataMember(IsRequired = true)]
        public double? Peso
        {
            get
            {
                return peso;
            }

            set
            {
                peso = value;
            }
        }
    }
}

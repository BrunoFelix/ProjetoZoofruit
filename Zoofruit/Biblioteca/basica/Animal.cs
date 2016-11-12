using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    public class Animal
    {
        private int codigo;
        private string nome;
        private byte[] foto;
        private string cor;
        private string porte;
        private double peso;
        public TipoAnimal tipoAnimal;

        public Animal()
        {
            tipoAnimal = new TipoAnimal();
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

        public double Peso
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

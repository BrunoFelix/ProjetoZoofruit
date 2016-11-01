using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    public abstract class Ficha
    {
        private int codigo;
        private string dataCriacao;
        private string horaCriacao;
        private string dataValidade;
        private Usuario usuario;
        private Animal animal;

        public Ficha()
        {
            animal = new Animal();
            usuario = new Usuario();
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

        public string HoraCriacao
        {
            get
            {
                return horaCriacao;
            }

            set
            {
                horaCriacao = value;
            }
        }

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

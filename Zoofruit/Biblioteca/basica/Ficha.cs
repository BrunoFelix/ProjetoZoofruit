using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    public class Ficha
    {
        private int codigo;
        private string DataCriacao;
        private int horaCriacao;
        private string dataValidade;
        private TipoFicha tipoFicha;
        private Usuario usuario;
        private Animal animal;

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

        public string DataCriacao1
        {
            get
            {
                return DataCriacao;
            }

            set
            {
                DataCriacao = value;
            }
        }

        public int HoraCriacao
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

        public TipoFicha TipoFicha
        {
            get
            {
                return tipoFicha;
            }

            set
            {
                tipoFicha = value;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    public class Medicamento
    {
        private int codigo;
        private string nome;
        private int quantidade;
        private string dataValidade;
        private string dataReposicao;

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

        public int Quantidade
        {
            get
            {
                return quantidade;
            }

            set
            {
                quantidade = value;
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

        public string DataReposicao
        {
            get
            {
                return dataReposicao;
            }

            set
            {
                dataReposicao = value;
            }
        }
    }
}

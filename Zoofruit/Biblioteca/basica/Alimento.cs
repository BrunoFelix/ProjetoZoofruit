using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
   public class Alimento
    {
        private int codigo;
        private string nome;
        private int quantidade;
        private double valorCalorico;
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

        public double ValorCalorico
        {
            get
            {
                return valorCalorico;
            }

            set
            {
                valorCalorico = value;
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

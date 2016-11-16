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
    public class Alimento
    {
        private int codigo;
        private string nome;
        private double quantidade;
        private double valorCalorico;

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

        [DataMember(IsRequired = true)]
        public double Quantidade
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

        [DataMember(IsRequired = true)]
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
    }
}

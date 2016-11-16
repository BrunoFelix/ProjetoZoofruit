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
    public class Medicamento
    {
        private int codigo;
        private string nome;
        private int quantidade;
        private string dataReposicao;

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
        [DataMember(IsRequired = true)]
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

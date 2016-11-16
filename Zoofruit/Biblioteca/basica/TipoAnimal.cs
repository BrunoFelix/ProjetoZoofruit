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
    public class TipoAnimal
    {
        private int codigo;
        private string descricao;

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
    }

}
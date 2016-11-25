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
    public class FichaExecucaoAlimento : FichaExecucao
    {
        private List<Alimento> listaAlimento;

        public FichaExecucaoAlimento() : base()
        {
            ListaAlimento = new List<Alimento>();
        }

        [DataMember(IsRequired = true)]
        public List<Alimento> ListaAlimento
        {
            get
            {
                return listaAlimento;
            }

            set
            {
                listaAlimento = value;
            }
        }
    }

}

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
    public class FichaAlimento : Ficha
    {
        private double qtd_max_cal;

        private List<Alimento> listaAlimento;

        [DataMember(IsRequired = true)]
        public double Qtd_max_cal
        {
            get
            {
                return qtd_max_cal;
            }

            set
            {
                qtd_max_cal = value;
            }
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

        public FichaAlimento() : base()
        {
            ListaAlimento = new List<Alimento>();
        }
    }
}

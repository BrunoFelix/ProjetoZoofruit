using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    public class FichaAlimento : Ficha
    {
        private double qtd_max_cal;

        public List<Alimento> listaAlimento;

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

        public FichaAlimento() : base()
        {
            listaAlimento = new List<Alimento>();
        }
    }
}

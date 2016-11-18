using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    class FichaExecucaoAlimento : Ficha
    {
        private List<Alimento> listaAlimento;

        public FichaExecucaoAlimento() : base()
        {
            ListaAlimento = new List<Alimento>();
        }

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

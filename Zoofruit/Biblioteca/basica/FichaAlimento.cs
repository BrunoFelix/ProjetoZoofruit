using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    public class FichaAlimento : Ficha
    {

        double qtd_Alimento;

        public List<Alimento> listaAlimento;
        public FichaAlimento() : base()
        {
            listaAlimento = new List<Alimento>();
        }
    }
}

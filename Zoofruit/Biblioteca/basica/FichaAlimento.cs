using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    public class FichaAlimento : Ficha
    {
        List<Alimento> listaalimento;
        public FichaAlimento() : base()
        {
            listaalimento = new List<Alimento>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    public class FichaMedicamento : Ficha
    {
        List<Medicamento> listamedicamento;
        public FichaMedicamento() : base()
        {
            listamedicamento = new List<Medicamento>();
        }
    }
}

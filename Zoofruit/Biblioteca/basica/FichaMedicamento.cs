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
    public class FichaMedicamento : Ficha
    {
        List<Medicamento> listamedicamento;
        public FichaMedicamento() : base()
        {
            listamedicamento = new List<Medicamento>();
        }
    }
}

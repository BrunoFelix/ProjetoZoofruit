using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    class FichaExecucaoMedicamento : Ficha
    {
        private List<Medicamento> listamedicamento;

        public FichaExecucaoMedicamento() : base()
        {
            ListaMedicamento = new List<Medicamento>();
        }

        public List<Medicamento> ListaMedicamento
        {
            get
            {
                return listamedicamento;
            }

            set
            {
                listamedicamento = value;
            }
        }
    }
}

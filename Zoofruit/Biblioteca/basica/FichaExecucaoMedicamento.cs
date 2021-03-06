﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.basica
{
    [Serializable]
    [DataContract()]
    class FichaExecucaoMedicamento : Ficha
    {
        private List<Medicamento> listamedicamento;

        public FichaExecucaoMedicamento() : base()
        {
            ListaMedicamento = new List<Medicamento>();
        }

        [DataMember(IsRequired = true)]
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

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
    public abstract class FichaExecucao
    {
        private int codigo;
        private string observacao;
        private string dataExecucao;
        private string status;
        private Usuario usuario;
        private FichaAlimento fichaAlimento;

        [DataMember(IsRequired = true)]
        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        [DataMember(IsRequired = true)]
        public string Observacao
        {
            get
            {
                return observacao;
            }

            set
            {
                observacao = value;
            }
        }

        [DataMember(IsRequired = true)]
        public string DataExecucao
        {
            get
            {
                return dataExecucao;
            }

            set
            {
                dataExecucao = value;
            }
        }

        [DataMember(IsRequired = true)]
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        [DataMember(IsRequired = true)]
        public Usuario Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        [DataMember(IsRequired = true)]
        public FichaAlimento FichaAlimento
        {
            get
            {
                return fichaAlimento;
            }

            set
            {
                fichaAlimento = value;
            }
        }
    }
}

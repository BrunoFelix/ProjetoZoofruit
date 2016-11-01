using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.util
{
    class NegocioException : Exception
    {
        public NegocioException() : base()
        {
            //
        }

        public NegocioException(Exception e) : base(e.Message)
        {
            //
        }

        public NegocioException(String mensagem) : base(mensagem)
        {
            //
        }
    }
}

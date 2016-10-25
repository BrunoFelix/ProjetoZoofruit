using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.util
{
    public class ConexaoException : Exception
    {
        public ConexaoException() : base()
        {
            //
        }

        public ConexaoException(Exception e) : base(e.Message)
        {
            //
        }

        public ConexaoException(String mensagem) : base(mensagem)
        {
            //
        }
    }
}

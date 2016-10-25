using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.util
{
    public class DadosException : Exception
    {
        public DadosException() : base()
        {
            //
        }

        public DadosException(Exception e) : base(e.Message)
        {
            //
        }

        public DadosException(String mensagem) : base(mensagem)
        {
            //
        }

    }
}

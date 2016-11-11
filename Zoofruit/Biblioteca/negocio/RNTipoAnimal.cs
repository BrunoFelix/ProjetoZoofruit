using Biblioteca.basica;
using Biblioteca.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.negocio
{
    public class RNTipoAnimal : NegocioException
    {
        public List<TipoAnimal> NListarTipoAnimal(TipoAnimal a)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }
    }
}

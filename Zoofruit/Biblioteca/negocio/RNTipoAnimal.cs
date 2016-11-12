using Biblioteca.basica;
using Biblioteca.dados;
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
        DAOTipoAnimal daotipoanimal;

        public RNTipoAnimal()
        {
            daotipoanimal = new DAOTipoAnimal();
        }
        public List<TipoAnimal> NListarTipoAnimal(TipoAnimal ta)
        {
            try
            {
                return daotipoanimal.Pesquisar(ta);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }
    }
}

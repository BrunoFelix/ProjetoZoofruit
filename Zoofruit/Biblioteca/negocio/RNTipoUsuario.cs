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
    public class RNTipoUsuario : NegocioException
    {
        DAOTipoUsuario daotipousuario;
        public RNTipoUsuario()
        {
            daotipousuario = new DAOTipoUsuario();
        }
        public List<TipoUsuario> NListarTipoUsuario(TipoUsuario tu)
        {
            try
            {
                return daotipousuario.Pesquisar(tu);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }
    }
}

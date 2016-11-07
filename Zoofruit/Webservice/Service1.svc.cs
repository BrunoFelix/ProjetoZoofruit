using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Biblioteca.basica;
using Biblioteca.negocio;

namespace Webservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {


        RNUsuario rnusuario;
        RNTipoUsuario rntipousuario;
         
        private Service1()
        {
            rnusuario = new RNUsuario();
            rntipousuario = new RNTipoUsuario();
        }


        /* ------------------- Usuario -------------------------------------- */
        public void InserirUsuario(Usuario u)
        {
            rnusuario.Adicionar(u);
        }

        public List<TipoUsuario> ListarTipoUsuario(TipoUsuario tu)
        {
            return rntipousuario.NListarTipoUsuario(tu);
        }

        public List<Usuario> ListarUsuario(Usuario u)
        {
            return rnusuario.NListarUsuario(u);
        }
        /* ------------------- Usuario -------------------------------------- */
    }
}

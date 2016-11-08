using Biblioteca.basica;
using Biblioteca.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
    public interface iDAOUsuario
    {
        void Adicionar(Usuario u); 
        void Alterar(Usuario u);
        void Excluir(Usuario u);
        List<Usuario> Pesquisar(Usuario u, bool alt=false);
        



    }
}

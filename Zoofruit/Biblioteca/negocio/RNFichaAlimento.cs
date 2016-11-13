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
    public class RNFichaAlimento : NegocioException
    {
        DAOFichaAlimento daofichaalimento;
        public RNFichaAlimento()
        {
            daofichaalimento = new DAOFichaAlimento();
        }

        public void Adicionar(FichaAlimento fa)
        {
            try
            {
                /*ValidarPreenchimentoDados(u);
                ValidarDados(u);
                VerificarDuplicidade(u);*/
                daofichaalimento.Adicionar(fa);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Alterar(FichaAlimento fa)
        {
            try
            {
                /*ValidarPreenchimentoDados(u);
                ValidarDados(u);
                VerificarDuplicidade(u, true);*/
                daofichaalimento.Alterar(fa);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Excluir(FichaAlimento fa)
        {
            try
            {
                daofichaalimento.Excluir(fa);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public List<FichaAlimento> NListarFichaAlimento(FichaAlimento fa)
        {
            try
            {
                return daofichaalimento.Pesquisar(fa);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        //######################################### VALIDAÇÕES
    }
}

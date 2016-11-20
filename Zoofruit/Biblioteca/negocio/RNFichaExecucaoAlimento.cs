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
    public class RNFichaExecucaoAlimento : NegocioException
    {
        DAOFichaExecucaoAlimento daofichaexecucaoalimento;
        public RNFichaExecucaoAlimento()
        {
            daofichaexecucaoalimento = new DAOFichaExecucaoAlimento();
        }

        public void Adicionar(FichaExecucaoAlimento fae)
        {
            try
            {
                /*ValidarPreenchimentoDados(u);
                ValidarDados(u);
                VerificarDuplicidade(u);*/
                daofichaexecucaoalimento.Adicionar(fae);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Alterar(FichaExecucaoAlimento fae)
        {
            try
            {
                /*ValidarPreenchimentoDados(u);
                ValidarDados(u);
                VerificarDuplicidade(u, true);*/
                daofichaexecucaoalimento.Alterar(fae);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Excluir(FichaExecucaoAlimento fae)
        {
            try
            {
                daofichaexecucaoalimento.Excluir(fae);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public List<FichaExecucaoAlimento> NListarFichaExecucaoAlimento(FichaExecucaoAlimento fae)
        {
            try
            {
                return daofichaexecucaoalimento.Pesquisar(fae);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public List<Alimento> NListarFichaExecucaoAlimentoAlimento(int codigo)
        {
            try
            {
                return daofichaexecucaoalimento.Pesquisar(codigo);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

    }
}

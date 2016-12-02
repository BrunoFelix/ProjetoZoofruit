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
        private DateTime resultado;
        DAOFichaExecucaoAlimento daofichaexecucaoalimento;
        public RNFichaExecucaoAlimento()
        {
            daofichaexecucaoalimento = new DAOFichaExecucaoAlimento();
        }

        public void Salvar(FichaExecucaoAlimento fae, double qtd_max_cal)
        {
            try
            {
                ValidarPreenchimentoDados(fae);
                ValidarDados(fae);
                CalcularQtdMaxCal(fae, qtd_max_cal);
                daofichaexecucaoalimento.Adicionar(fae);
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

        //######################################### VALIDAÇÕES

        private void ValidarPreenchimentoDados(FichaExecucaoAlimento fae)
        {
            if (fae.DataExecucao == null || fae.DataExecucao.Equals("") == true)
            {
                throw new NegocioException("O campo \"Data de Execução\" precisa ser preenchido!");
            }
            if (fae.Usuario == null)
            {
                throw new NegocioException("O campo \"Usuário\" precisa ser preenchido!");
            }
            if (fae.ListaAlimento == null)
            {
                throw new NegocioException("A \"Cesta de Alimentos\" precisa ser preenchida!");
            }
        }

        public void ValidarDados(FichaExecucaoAlimento fae)
        {
            if (!DateTime.TryParse(fae.DataExecucao.Trim(), out resultado))
            {
                throw new NegocioException("Data de Execução Inválida!");
            }
            if (fae.Usuario.Codigo <= 0)
            {
                throw new NegocioException("O campo \"Usuário\" é inválido!");
            }
            if (fae.ListaAlimento.Count <= 0)
            {
                throw new NegocioException("A \"Cesta de Alimentos\" precisa conter ao menos um alimento!");
            }
        }

        private void CalcularQtdMaxCal(FichaExecucaoAlimento fae, double qtd_max_cal)
        {
            double valoracumulado = 0;
            double valorreal = (qtd_max_cal * 10) / 100;
            foreach (Alimento alimento in fae.ListaAlimento)
            {
                valoracumulado += (double)(alimento.Quantidade * alimento.ValorCalorico);
            }

            if (qtd_max_cal > valoracumulado)
            {
                if ((qtd_max_cal - valoracumulado) > valorreal)
                {
                    throw new NegocioException("A \"Cesta de Alimentos\" não pode ultrapassar a quantidade máxima de calórias para mais de 10%!");
                }
            }
            else if (valoracumulado >= qtd_max_cal)
            {
                if ((valoracumulado - qtd_max_cal) > valorreal)
                {
                    throw new NegocioException("A \"Cesta de Alimentos\" não pode ultrapassar a quantidade máxima de calórias para mais de 10%!");
                }
            }
        }
    }
}

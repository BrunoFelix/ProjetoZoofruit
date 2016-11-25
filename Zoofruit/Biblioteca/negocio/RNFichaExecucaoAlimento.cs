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
            if (!DateTime.TryParse(fae.DataExecucao.Trim(), out resultado))
            {
                throw new NegocioException("Data de Execução Inválida!");
            }
            if (fae.Usuario == null || fae.Usuario.Codigo <= 0)
            {
                throw new NegocioException("Usuário inválido!");
            }
            if (fae.FichaAlimento == null)
            {
                throw new NegocioException("Não é possivel executar uma ficha sem montar uma cesta!");
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
                    throw new NegocioException("A quantidade máxima de calórias não pode ultrapassar 10% nem para mais, nem para menos!");
                }
            }
            else if (valoracumulado >= qtd_max_cal)
            {
                if ((valoracumulado - qtd_max_cal) > valorreal)
                {
                    throw new NegocioException("A quantidade máxima de calórias não pode ultrapassar 10% nem para mais, nem para menos!");
                }
            }
        }
    }
}

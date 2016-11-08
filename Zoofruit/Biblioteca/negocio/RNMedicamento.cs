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
    public class RNMedicamento : NegocioException
    {
        DAOMedicamento daomedicamento;
        public RNMedicamento()
        {
            daomedicamento = new DAOMedicamento();
        }

        public void Adicionar(Medicamento m)
        {
            try
            {
                /*ValidarPreenchimentoDados(u);
                ValidarDados(u);
                VerificarDuplicidade(u);*/
                daomedicamento.Adicionar(m);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Alterar(Medicamento m)
        {
            try
            {
                /*ValidarPreenchimentoDados(u);
                ValidarDados(u);
                VerificarDuplicidade(u, true);*/
                daomedicamento.Alterar(m);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Excluir(Medicamento m)
        {
            try
            {
                daomedicamento.Excluir(m);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public List<Medicamento> NListarMedicamento(Medicamento m)
        {
            try
            {
                return daomedicamento.Pesquisar(m);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        //######################################### VALIDAÇÕES
    }
}

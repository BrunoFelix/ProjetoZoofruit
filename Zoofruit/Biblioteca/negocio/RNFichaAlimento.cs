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
        private DateTime resultado;
        private int resultado2;
        DAOFichaAlimento daofichaalimento;
        public RNFichaAlimento()
        {
            daofichaalimento = new DAOFichaAlimento();
        }

        public void Adicionar(FichaAlimento fa)
        {
            try
            {
                ValidarPreenchimentoDados(fa);
                ValidarDados(fa);
                VerificarDuplicidade(fa);
                daofichaalimento.Adicionar(fa);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Alterar(FichaAlimento fa)
        {
            /*try
            {
                ValidarPreenchimentoDados(u);
                ValidarDados(u);
                VerificarDuplicidade(u, true);
                daofichaalimento.Alterar(fa);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }*/
        }

        public void Excluir(FichaAlimento fa)
        {
            try
            {   
                if (fa.Codigo < 0)
                {
                    throw new NegocioException("A ficha que você está tentando excluir não existe!");
                }
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
  
        private void ValidarPreenchimentoDados(FichaAlimento fa)
        {
            if (fa.DataCriacao == null || fa.DataCriacao.Equals("") == true)
            {
                throw new NegocioException("O campo \"Data de Criação\" precisa ser preenchido!");
            }
            if (fa.DataValidade == null || fa.DataValidade.Equals("") == true)
            {
                throw new NegocioException("O campo \"Data de Validade\" precisa ser preenchido!");
            }
            if (fa.Qtd_max_cal < 0)
            {
                throw new NegocioException("O campo \"Quantidade Máxima de Calórias\" precisa ser preenchido!");
            }
            if (fa.Hora_a_ser_executado == null || fa.Hora_a_ser_executado.Equals("") == true)
            {
                throw new NegocioException("O campo \"Hora que deve ser executada\" precisa ser preenchido!");
            }
            if (fa.Animal.Codigo <= 0)
            {
                throw new NegocioException("Animal inválido!");
            }
            if (fa.Usuario.Codigo <= 0)
            {
                throw new NegocioException("Usuário inválido!");
            }
            if (fa.ListaAlimento.Count <= 0)
            {
                throw new NegocioException("Não é possivel criar uma ficha sem nenhum alimento!");
            }
        }

        private void ValidarDados(FichaAlimento fa)
        {
            if (fa.Descricao.Length > 60)
            {
                throw new NegocioException("Descrição com limite de 60 caracteres!");
            }
            if (fa.Qtd_max_cal <= 0)
            {
                throw new NegocioException("Quantidade Máxima de Calórias Inválida!");
            }
            if (!Int32.TryParse(fa.Hora_a_ser_executado, out resultado2))
            {
                throw new NegocioException("Hora que deve ser executada Inválida!");
            }
            if ((resultado2 <= 0) || (resultado2 >= 24))
            {
                throw new NegocioException("Hora que deve ser executada Inválida!");
            }
            if (!DateTime.TryParse(fa.DataValidade.Trim(), out resultado))
            {
                throw new NegocioException("Data de Validade Inválida!");
            }
            if (!DateTime.TryParse(fa.DataCriacao.Trim(), out resultado))
            {
                throw new NegocioException("Data de Criação Inválida!");
            }
        }

        private void VerificarDuplicidade(FichaAlimento fa, bool alt = false)
        {
            FichaAlimento fa2 = new FichaAlimento();
            fa2.Usuario = new Usuario();
            fa2.ListaAlimento = new List<Alimento>();
            fa2.DataValidade = fa.DataValidade;
            fa2.Animal = fa.Animal;
            fa2.Hora_a_ser_executado = fa.Hora_a_ser_executado;

            if (daofichaalimento.Pesquisar(fa2, true).Count > 0)
            {
                throw new NegocioException("Já existe uma ficha cadastrada nesse mesmo horário para esse animal!");
            }
        }
    }
}

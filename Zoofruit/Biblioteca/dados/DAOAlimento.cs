using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.basica;
using System.Data.SqlClient;
using Biblioteca.util;
using System.Data;

namespace Biblioteca.dados
{
    public class DAOAlimento : iDAOAlimento
    {
        Conexao conexao;
        public DAOAlimento()
        {
            conexao = new Conexao();
        }

        //Adicinona um Registro a Tabela Alimento.
        public void Adicionar(Alimento a)
        {
            conexao.openConnection();
            try
            {
                string sql = "INSERT INTO ALIMENTO ( NOME, QUANTIDADE, VALOR_CALORICO, DT_REPOSICAO) VALUES (@NOME, @QUANTIDADE, @VALOR_CALORICO, @DT_REPOSICAO)";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

              
                cmd.Parameters.Add(new SqlParameter("@NOME", a.Nome));
                cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", a.Quantidade));
                cmd.Parameters.Add(new SqlParameter("@VALOR_CALORICO", a.ValorCalorico));
                cmd.Parameters.Add(new SqlParameter("@DT_REPOSICAO", a.DataReposicao));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DadosException(ex.Message);
            }
            finally
            {
                conexao.closeConnection();
            }
        }

        //Altera o Registro de um Aimento.
        public void Alterar(Alimento a)
        {
            conexao.openConnection();
            try
            {
                string sql = "ALTER TABLE ALIMENTO SET NOME=@NOME, QUANTIDADE=@QUANTIDADE, VALOR_CALORICO=@VALOR_CALORICO, DT_REPOSICAO=@DT_REPOSICAO WHERE CODIGO=@CODIGO";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@NOME", a.Nome));
                cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", a.Quantidade));
                cmd.Parameters.Add(new SqlParameter("@VALOR_CALORICO", a.ValorCalorico));
                cmd.Parameters.Add(new SqlParameter("@DT_REPOSICAO", a.DataReposicao));
                cmd.Parameters.Add(new SqlParameter("@CODIGO", a.Codigo));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DadosException(ex.Message);
            }
            finally
            {
                conexao.closeConnection();
            }
        }


        //Exclui o Registro de um Alimento.
        public void Excluir(Alimento a)
        {
            conexao.openConnection();
            try
            {
                string sql = "DELETE FROM ALIMENTO WHERE CODIGO=@CODIGO";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@CODIGO", a.Codigo));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DadosException(ex.Message);
            }
            finally
            {
                conexao.closeConnection();
            }
        }

        //Retorna uma Lista de todos os Alimentos.
        public List<Alimento> Pesquisar(Alimento a)
        {
            List<Alimento> listaAlimento = new List<Alimento>();

            try
            {
                conexao.openConnection();
                string sql = "SELECT ALIMENTO.CODIGO ,ALIMENTO.NOME,ALIMENTO.QUANTIDADE, ALIMENTO.VALOR_CALORICO , ALIMENTO.DT_REPOSICAO FROM ALIMENTO ";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Alimento alimento = new Alimento();
                    alimento.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO"));
                    alimento.Nome = reader.GetString(reader.GetOrdinal("NOME"));
                    alimento.Quantidade = reader.GetDouble(reader.GetOrdinal("QUANTIDADE"));
                    alimento.ValorCalorico = reader.GetDouble(reader.GetOrdinal("VALOR_CALORICO"));
                    alimento.DataReposicao = reader.GetDateTime(reader.GetOrdinal("DT_REPOSICAO")).ToString("dd/mm/yyyy");


                    listaAlimento.Add(alimento);
                }

                reader.Close();

                cmd.Dispose();

                conexao.closeConnection();
            }
            catch (Exception ex)
            {
                throw new DadosException(ex.Message);
            }

            return listaAlimento;

        }

    }
}


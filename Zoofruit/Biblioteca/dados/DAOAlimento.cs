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
        public void adicionar(Alimento a)
        {
            conexao.openConnection();
            try
            {
                string sql = "INSERT INTO ALIMENTO (CODIGO, NOME, QUANTIDADE, VALOR_CALORICO, DT_REPOSICAO) VALUES (@CODIGO, @NOME, @QUANTIDADE, @VALOR_CALORICO, @DT_REPOSICAO)";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@CODIGO", a.Codigo));
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
        public void alterar(Alimento a)
        {
            conexao.openConnection();
            try
            {
                string sql = "ALTER TABLE USUARIO SET CODIGO=@CODIGO, NOME=@NOME, QUANTIDADE=@QUANTIDADE, VALOR_CALORICO=@VALOR_CALORICO, DT_REPOSICAO@DT_REPOSICAO";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@CODIGO", a.Codigo));
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


        //Exclui o Registro de um Alimento.
        public void excluir(Alimento a)
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
        public List<Alimento> pesquisar(Alimento a)
        {
            List<Alimento> listaAlimentos = new List<Alimento>();

            try
            {
                conexao.openConnection();
                string sql = "SELECT ALIMENTO.CODIGO ,ALIMENTO.NOME,ALIMENTO.QUANTIDADE, ALIMENTO.VALOR_CALORICO , ALIMENTO.DT_REPOSICAO FROM ALIMENTO ";
                /**

                 if (a.Nome != null && a.Nome.Trim().Equals("") == false)
                 {
                     sql += " and login = @nome";
                 }

                 if (u.Senha != null && u.Senha.Trim().Equals("") == false)
                 {
                     sql += " and senha = @senha";
                 }



                 if (u.Login != null && u.Login.Trim().Equals("") == false)
                 {
                     cmd.Parameters.Add("@login", SqlDbType.VarChar);
                     cmd.Parameters["@login"].Value = u.Login;
                 }

                 if (u.Senha != null && u.Senha.Trim().Equals("") == false)
                 {
                     cmd.Parameters.Add("@senha", SqlDbType.VarChar);
                     cmd.Parameters["@senha"].Value = u.Senha;
                 } **/

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Alimento alimento = new Alimento();
                    alimento.Codigo = reader.GetInt32(reader.GetOrdinal("codigo"));
                    alimento.Nome = reader.GetString(reader.GetOrdinal("nome"));
                    alimento.Quantidade = reader.GetInt32(reader.GetOrdinal("quantidade"));
                    alimento.ValorCalorico = reader.GetInt32(reader.GetOrdinal("valor_calorico"));
                    alimento.DataReposicao = reader.GetString(reader.GetOrdinal("dataReposicao"));
                 

                    listaAlimentos.Add(alimento);
                }

                reader.Close();

                cmd.Dispose();

                conexao.closeConnection();
            }
            catch (Exception ex)
            {
                throw new DadosException(ex.Message);
            }

            return listaAlimentos;

        }

    }
}


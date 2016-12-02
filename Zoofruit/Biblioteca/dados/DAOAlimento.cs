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
                string sql = "INSERT INTO ALIMENTO ( NOME, QUANTIDADE, VALOR_CALORICO) VALUES (@NOME, @QUANTIDADE, @VALOR_CALORICO)";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@NOME", a.Nome));
                cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", a.Quantidade));
                cmd.Parameters.Add(new SqlParameter("@VALOR_CALORICO", a.ValorCalorico));

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
                string sql = "UPDATE ALIMENTO SET NOME=@NOME, QUANTIDADE=@QUANTIDADE, VALOR_CALORICO=@VALOR_CALORICO WHERE CODIGO=@CODIGO";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@NOME", a.Nome));
                cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", a.Quantidade));
                cmd.Parameters.Add(new SqlParameter("@VALOR_CALORICO", a.ValorCalorico));
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
                string sql = "UPDATE ALIMENTO SET ATIVO = 'F' WHERE CODIGO=@CODIGO";

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
        public List<Alimento> Pesquisar(Alimento a, bool alt = false)
        {
            List<Alimento> listaAlimento = new List<Alimento>();

            try
            {
                conexao.openConnection();
                string sql = "SELECT ALIMENTO.CODIGO, ALIMENTO.NOME, ALIMENTO.QUANTIDADE, ALIMENTO.VALOR_CALORICO FROM ALIMENTO WHERE ALIMENTO.ATIVO = 'T' ";

                if (a.Nome != null && a.Nome.Trim().Equals("") == false)
                {
                    sql += " and ALIMENTO.NOME = @NOME";
                }

                if (a.Quantidade > 0)
                {
                    sql += " and ALIMENTO.QUANTIDADE >= @QUANTIDADE";
                }

                if (a.ValorCalorico > 0)
                {
                    sql += " and ALIMENTO.VALOR_CALORICO = @VALOR_CALORICO";
                }

                if (alt == false)
                {
                    if (a.Codigo > 0)
                    {
                        sql += " and ALIMENTO.CODIGO = @codigo";
                    }

                }
                else
                {
                    if (a.Codigo > 0)
                    {
                        sql += " and ALIMENTO.CODIGO <> @codigo";
                    }
                }

                sql += " ORDER BY NOME ASC, QUANTIDADE ASC, VALOR_CALORICO ASC ";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                if (a.Nome != null && a.Nome.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                    cmd.Parameters["@NOME"].Value = a.Nome;
                }

                if (a.Quantidade > 0)
                {
                    cmd.Parameters.Add("@QUANTIDADE", SqlDbType.VarChar);
                    cmd.Parameters["@QUANTIDADE"].Value = a.Quantidade;
                }

                if (a.ValorCalorico > 0)
                {
                    cmd.Parameters.Add("@VALOR_CALORICO", SqlDbType.VarChar);
                    cmd.Parameters["@VALOR_CALORICO"].Value = a.ValorCalorico;
                }

                if (a.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO"].Value = a.Codigo;
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Alimento alimento = new Alimento();
                    alimento.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO"));
                    alimento.Nome = reader.GetString(reader.GetOrdinal("NOME"));
                    alimento.Quantidade = reader.GetDouble(reader.GetOrdinal("QUANTIDADE"));
                    alimento.ValorCalorico = reader.GetDouble(reader.GetOrdinal("VALOR_CALORICO"));

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


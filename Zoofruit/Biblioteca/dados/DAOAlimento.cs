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
                string sql = "INSERT INTO ALIMENTO (CODIGO, NOME, QUANTIDADE, VALOR_CALORICO, DT_VALIDADE, DT_REPOSICAO) VALUES (@CODIGO, @NOME, @QUANTIDADE, @VALOR_CALORICO, @DT_VALIDADE, @DT_REPOSICAO)";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@CODIGO", a.Codigo));
                cmd.Parameters.Add(new SqlParameter("@NOME", a.Nome));
                cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", a.Quantidade));
                cmd.Parameters.Add(new SqlParameter("@VALOR_CALORICO", a.ValorCalorico));
                cmd.Parameters.Add(new SqlParameter("@DT_VALIDADE", a.DataValidade));
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
                string sql = "ALTER TABLE USUARIO SET CODIGO=@CODIGO, NOME=@NOME, QUANTIDADE=@QUANTIDADE, VALOR_CALORICO=@VALOR_CALORICO, DT_VALIDADE=@DT_VALIDADE, DT_REPOSICAO@DT_REPOSICAO";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@CODIGO", a.Codigo));
                cmd.Parameters.Add(new SqlParameter("@NOME", a.Nome));
                cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", a.Quantidade));
                cmd.Parameters.Add(new SqlParameter("@VALOR_CALORICO", a.ValorCalorico));
                cmd.Parameters.Add(new SqlParameter("@DT_VALIDADE", a.DataValidade));
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
                string sql = "SELECT Usuario.codigo, Usuario.cpf, Usuario.login, Usuario.senha, Usuario.crmv, Usuario.codigo_TipoUsuario, " +

"TipoUsuario.descricao FROM Usuario LEFT JOIN TipoUsuario ON (TipoUsuario.codigo = Usuario.codigo_TipoUsuario) WHERE Usuario.codigo > 0 ";


                if (u.Login != null && u.Login.Trim().Equals("") == false)
                {
                    sql += " and login = @login";
                }

                if (u.Senha != null && u.Senha.Trim().Equals("") == false)
                {
                    sql += " and senha = @senha";
                }


                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                if (u.Login != null && u.Login.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@login", SqlDbType.VarChar);
                    cmd.Parameters["@login"].Value = u.Login;
                }

                if (u.Senha != null && u.Senha.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@senha", SqlDbType.VarChar);
                    cmd.Parameters["@senha"].Value = u.Senha;
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Alimento alimento = new Alimento();
                    alimento.Codigo = reader.GetInt32(reader.GetOrdinal("codigo"));
                    alimento.Cpf = reader.GetString(reader.GetOrdinal("cpf"));
                    alimento.Login = reader.GetString(reader.GetOrdinal("login"));
                    alimento.Senha = reader.GetString(reader.GetOrdinal("senha"));
                    alimento.Crmv = reader.GetString(reader.GetOrdinal("crmv"));
                    alimento.tipousuario.Codigo = reader.GetInt32(reader.GetOrdinal("codigo_TipoUsuario"));
                    alimento.tipousuario.Descricao = reader.GetString(reader.GetOrdinal("descricao"));

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

            return listausuarios;

        }

    }
}

    }
}

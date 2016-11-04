using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.basica;
using Biblioteca.util;
using System.Data.SqlClient;
using System.Data;

namespace Biblioteca.dados
{
    public class DAOUsuario : iDAOUsuario
    {
        Conexao conexao;
        public DAOUsuario()
        {
            conexao = new Conexao();
        }

        public void Adicionar(Usuario u)
        {
            conexao.openConnection();
            try
            {
                string sql = "INSERT INTO USUARIO (NOME, CPF, LOGIN, SENHA, CRMV, CODIGO_TIPOUSUARIO) VALUES (@NOME, @CPF, @LOGIN, @SENHA, @CRMV, @CODIGO_TIPOUSUARIO)";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@NOME", u.Nome));
                cmd.Parameters.Add(new SqlParameter("@CPF", u.Cpf));
                cmd.Parameters.Add(new SqlParameter("@LOGIN", u.Login));
                cmd.Parameters.Add(new SqlParameter("@SENHA", u.Senha));
                cmd.Parameters.Add(new SqlParameter("@CRMV", u.Crmv));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_TIPOUSUARIO", u.tipousuario.Codigo));

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

        public void Alterar(Usuario u)
        {
            conexao.openConnection();
            try
            {
                string sql = "ALTER TABLE USUARIO SET CPF=@CPF, LOGIN=@LOGIN, SENHA=@SENHA, CRMV=@CRMV, CODIGO_TIPOUSUARIO=@CODIGO_TIPOUSUARIO) WHERE CODIGO=@CODIGO";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@CPF", u.Cpf));
                cmd.Parameters.Add(new SqlParameter("@LOGIN", u.Login));
                cmd.Parameters.Add(new SqlParameter("@SENHA", u.Senha));
                cmd.Parameters.Add(new SqlParameter("@CRMV", u.Crmv));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_TIPOUSUARIO", u.tipousuario.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODIGO", u.Codigo));

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

        public void Excluir(Usuario u)
        {
            conexao.openConnection();
            try
            {
                string sql = "DELETE FROM USUARIO WHERE CODIGO=@CODIGO";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@CODIGO", u.Codigo));

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

        public List<Usuario> Pesquisar(Usuario u)
        {
            List<Usuario> listausuarios = new List<Usuario>();

            try
            {
                conexao.openConnection();
                string sql = "SELECT Usuario.codigo, Usuario.nome, Usuario.cpf, Usuario.login, Usuario.senha, Usuario.crmv, Usuario.codigo_TipoUsuario, "+ 
                    "TipoUsuario.descricao FROM Usuario LEFT JOIN TipoUsuario ON (TipoUsuario.codigo = Usuario.codigo_TipoUsuario) WHERE Usuario.codigo > 0 ";
        
                if (u.Login != null && u.Login.Trim().Equals("") == false)
                {
                    sql += " and login = @login";
                }

                if (u.Senha!= null && u.Senha.Trim().Equals("") == false)
                {
                    sql += " and senha = @senha";
                }

                if (u.Nome != null && u.Nome.Trim().Equals("") == false)
                {
                    sql += " and nome = @nome";
                }

                if (u.Cpf != null && u.Cpf.Trim().Equals("") == false)
                {
                    sql += " and cpf = @cpf";
                }

                if (u.Crmv != null && u.Crmv.Trim().Equals("") == false)
                {
                    sql += " and crmv = @crmv";
                }

                if (u.tipousuario.Descricao != null && u.tipousuario.Descricao.Trim().Equals("") == false)
                {
                    sql += " and TipoUsuario.descricao = @descricao";
                }

                if (u.Codigo > 0)
                {
                    sql += " and usuario.codigo = @codigo";
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

                if (u.Nome != null && u.Nome.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@nome", SqlDbType.VarChar);
                    cmd.Parameters["@nome"].Value = u.Nome;
                }

                if (u.Cpf != null && u.Cpf.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@cpf", SqlDbType.VarChar);
                    cmd.Parameters["@cpf"].Value = u.Cpf;
                }

                if (u.Crmv != null && u.Crmv.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@crmv", SqlDbType.VarChar);
                    cmd.Parameters["@crmv"].Value = u.Crmv;
                }

                if (u.tipousuario.Descricao != null && u.tipousuario.Descricao.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@descricao", SqlDbType.VarChar);
                    cmd.Parameters["@descricao"].Value = u.tipousuario.Descricao;
                }

                if (u.Codigo > 0)
                {
                    cmd.Parameters.Add("@codigo", SqlDbType.VarChar);
                    cmd.Parameters["@codigo"].Value = u.Codigo;
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Codigo = reader.GetInt32(reader.GetOrdinal("codigo"));
                    usuario.Nome = reader.GetString(reader.GetOrdinal("nome"));
                    usuario.Cpf = reader.GetString(reader.GetOrdinal("cpf"));
                    usuario.Login = reader.GetString(reader.GetOrdinal("login"));
                    usuario.Senha = reader.GetString(reader.GetOrdinal("senha"));
                    usuario.Crmv = reader.GetString(reader.GetOrdinal("crmv"));
                    usuario.tipousuario.Codigo = reader.GetInt32(reader.GetOrdinal("codigo_TipoUsuario"));
                    usuario.tipousuario.Descricao = reader.GetString(reader.GetOrdinal("descricao"));

                    listausuarios.Add(usuario);
                }

                reader.Close();

                cmd.Dispose();

                conexao.closeConnection();
            }
            catch(Exception ex)
            {
                throw new DadosException(ex.Message);
            }

            return listausuarios;
     
        }

    }
}

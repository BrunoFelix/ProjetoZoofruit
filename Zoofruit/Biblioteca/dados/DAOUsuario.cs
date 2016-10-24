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

        public void adicionar(Usuario u)
        {
            throw new NotImplementedException();
        }

        public void alterar(Usuario u)
        {
            throw new NotImplementedException();
        }

        public void excluir(Usuario u)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> pesquisar(Usuario u)
        {
            List<Usuario> listausuarios = new List<Usuario>();

            try
            {
                conexao.openConnection();
                string sql = "SELECT Usuario.codigo, Usuario.cpf, Usuario.login, Usuario.senha, Usuario.crmv, Usuario.codigo_TipoUsuario, TipoUsuario.descricao FROM Usuario LEFT JOIN TipoUsuario ON (TipoUsuario.codigo = Usuario.codigo_TipoUsuario) WHERE Usuario.codigo > 0 ";
        
                if (u.Login != null && u.Login.Trim().Equals("") == false)
                {
                    sql += " and login = @login";
                }

                if (u.Senha!= null && u.Senha.Trim().Equals("") == false)
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
                    Usuario usuario = new Usuario();
                    usuario.Codigo = reader.GetInt32(reader.GetOrdinal("Cod_Usuario"));
                    usuario.Cpf = reader.GetString(reader.GetOrdinal("cpf"));
                    usuario.Login = reader.GetString(reader.GetOrdinal("login"));
                    usuario.Senha = reader.GetString(reader.GetOrdinal("senha"));
                    usuario.Crmv = reader.GetString(reader.GetOrdinal("crmv"));
                    usuario.tipousuario.Codigo = reader.GetInt32(reader.GetOrdinal("cod_tipousuario"));
                    usuario.tipousuario.Descricao = reader.GetString(reader.GetOrdinal("descricao"));

                    listausuarios.Add(usuario);
                }

                reader.Close();

                cmd.Dispose();

                conexao.closeConnection();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listausuarios;
            
        }

    }
}

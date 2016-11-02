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
    public class DAOTipoUsuario : iDAOTipoUsuario
    {
        Conexao conexao;
        public DAOTipoUsuario()
        {
            conexao = new Conexao();
        }
        public List<TipoUsuario> Pesquisar(TipoUsuario tu)
        {
            List<TipoUsuario> listatipousuario = new List<TipoUsuario>();

            try
            {
                conexao.openConnection();
                string sql = "SELECT CODIGO, DESCRICAO FROM TIPOUSUARIO WHERE CODIGO > 0 ";

                if (tu.Codigo > 0)
                {
                    sql += " and CODIGO = @CODIGO";
                }

                if (tu.Descricao != null && tu.Descricao.Trim().Equals("") == false)
                {
                    sql += " and DESCRICAO = @DESCRICAO";
                }

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                if (tu.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO"].Value = tu.Codigo;
                }

                if (tu.Descricao != null && tu.Descricao.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@DESCRICAO", SqlDbType.VarChar);
                    cmd.Parameters["@DESCRICAO"].Value = tu.Descricao;
                }

                    SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TipoUsuario tipousuario = new TipoUsuario();
                    tipousuario.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO"));
                    tipousuario.Descricao = reader.GetString(reader.GetOrdinal("DESCRICAO"));

                    listatipousuario.Add(tipousuario);
                }

                reader.Close();

                cmd.Dispose();

                conexao.closeConnection();
            }
            catch (Exception ex)
            {
                throw new DadosException(ex.Message);
            }

            return listatipousuario;

        }
    }
}

using Biblioteca.basica;
using Biblioteca.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
    public class DAOTipoAnimal : iDAOTipoAnimal
    {
        Conexao conexao;
        public DAOTipoAnimal()
        {
            conexao = new Conexao();
        }
        public List<TipoAnimal> Pesquisar(TipoAnimal ta)
        {
            List<TipoAnimal> listatipoanimal = new List<TipoAnimal>();

            try
            {
                conexao.openConnection();
                string sql = "SELECT CODIGO, DESCRICAO FROM TIPOANIMAL WHERE CODIGO > 0 ";

                if (ta.Codigo > 0)
                {
                    sql += " and CODIGO = @CODIGO";
                }

                if (ta.Descricao != null && ta.Descricao.Trim().Equals("") == false)
                {
                    sql += " and DESCRICAO = @DESCRICAO";
                }

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                if (ta.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO"].Value = ta.Codigo;
                }

                if (ta.Descricao != null && ta.Descricao.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@DESCRICAO", SqlDbType.VarChar);
                    cmd.Parameters["@DESCRICAO"].Value = ta.Descricao;
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TipoAnimal tipoanimal = new TipoAnimal();
                    tipoanimal.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO"));
                    tipoanimal.Descricao = reader.GetString(reader.GetOrdinal("DESCRICAO"));

                    listatipoanimal.Add(tipoanimal);
                }

                reader.Close();

                cmd.Dispose();

                conexao.closeConnection();
            }
            catch (Exception ex)
            {
                throw new DadosException(ex.Message);
            }

            return listatipoanimal;

        }
    }
}

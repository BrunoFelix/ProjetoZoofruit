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
    public class DAOMedicamento : iDAOMedicamento
    {

        Conexao conexao;
        public DAOMedicamento()
        {
            conexao = new Conexao();
        }

        public void Adicionar(Medicamento m)
        {
            conexao.openConnection();
            try
            {
                string sql = "INSERT INTO MEDICAMENTO (NOME, QUANTIDADE, DT_REPOSICAO) VALUES (@NOME, @QUANTIDADE, @DT_REPOSICAO)";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@NOME", m.Nome));
                cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", m.Quantidade));
                cmd.Parameters.Add(new SqlParameter("@DT_REPOSICAO", m.DataReposicao));
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

        public void Alterar(Medicamento m)
        {
            conexao.openConnection();
            try
            {
                string sql = "ALTER TABLE MEDICAMENTO SET NOME=@NOME, QUANTIDADE=@QUANTIDADE, DT_REPOSICAO=@DT_REPOSICAO WHERE CODIGO=@CODIGO";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@NOME", m.Nome));
                cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", m.Quantidade));
                cmd.Parameters.Add(new SqlParameter("@DT_REPOSICAO", m.DataReposicao));

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

        public void Excluir(Medicamento m)
        {
            conexao.openConnection();
            try
            {
                string sql = "DELETE FROM MEDICAMENTO WHERE CODIGO=@CODIGO";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@CODIGO", m.Codigo));

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

        public List<Medicamento> Pesquisar(Medicamento m)
        {
            List<Medicamento> listaMedicamento = new List<Medicamento>();

            try
            {
                conexao.openConnection();
                string sql = "SELECT CODIGO, NOME, QUANTIDADE, DT_REPOSICAO FROM MEDICAMENTO";

                if (m.Codigo > 0)
                {
                    sql += " and CODIGO = @CODIGO";
                }

                if (m.Nome != null && m.Nome.Trim().Equals("") == false)
                {
                    sql += " and NOME = @NOME";
                }

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                if (m.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO"].Value = m.Codigo;
                }

                if (m.Nome != null && m.Nome.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                    cmd.Parameters["@NOME"].Value = m.Nome;
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Medicamento medicamento = new Medicamento();
                    medicamento.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO"));
                    medicamento.Nome = reader.GetString(reader.GetOrdinal("NOME"));
                    medicamento.Quantidade = reader.GetInt32(reader.GetOrdinal("QUANTIDADE"));
                    medicamento.DataReposicao = reader.GetString(reader.GetOrdinal("DT_REPOSICAO"));

                    listaMedicamento.Add(medicamento);
                }

                reader.Close();

                cmd.Dispose();

                conexao.closeConnection();
            }
            catch (Exception ex)
            {
                throw new DadosException(ex.Message);
            }

            return listaMedicamento;

        }

    }
}

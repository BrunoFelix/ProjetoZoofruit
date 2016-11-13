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
   public class DAOFichaAlimento : iDAOFichaAlimento
    {

        int codigo;
        Conexao conexao;
        public DAOFichaAlimento()
        {
            conexao = new Conexao();
        }


        public void Adicionar(FichaAlimento fa)
        {
            conexao.openConnection();
            try
            {
                
                string sql = "INSERT INTO FICHA_ALIMENTO (DESCRICAO, DT_CRIACAO, DT_VALIDADE, QTD_MAX_CAL, CODIGO_USUARIO, CODIGO_ANIMAL) VALUES (@DESCRICAO, @DT_CRIACAO, @DT_VALIDADE, @QTD_MAX_CAL, @CODIGO_USUARIO, @CODIGO_ANIMAL)";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", fa.Descricao));
                cmd.Parameters.Add(new SqlParameter("@DT_CRIACAO", fa.DataCriacao));
                cmd.Parameters.Add(new SqlParameter("@DT_VALIDADE", fa.DataValidade));
                cmd.Parameters.Add(new SqlParameter("@QTD_MAX_CAL", fa.Qtd_max_cal));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_USUARIO", 1));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_ANIMAL", 1));

                cmd.ExecuteNonQuery();

                /*sql = "SELECT MAX(CODIGO) FROM FICHA_ALIMENTO";
                SqlCommand cmd2 = new SqlCommand(sql, conexao.sqlconn);
                SqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    codigo = reader.GetInt32(reader.GetOrdinal("codigo"));
                }

                foreach (Alimento a in fa.listaAlimento)
                {
                    sql = "INSERT INTO ALIMENTO_DA_FICHA (QUANTIDADE, CODIGO_ALIMENTO, CODIGO_FICHA) VALUES (@QUANTIDADE, @CODIGO_ALIMENTO, @CODIGO_FICHA)";
                    SqlCommand cmd3 = new SqlCommand(sql, conexao.sqlconn);

                    cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", a.Quantidade));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_ALIMENTO", a.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_FICHA", codigo));

                    cmd.ExecuteNonQuery();
                }*/
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


        //Altera um Registro na tabela de Ficha de Alimento
        public void Alterar(FichaAlimento fa)
        {

            conexao.openConnection();
            try
            {

                string sql = "ALTER TABLE FICHA_ALIMENTO SET DT_VALIDADE=@DT_VALIDADE, CODIGO_USUARIO=@CODIGO_USUARIO, CODIGO_ANIMAL=@CODIGO_ANIMAL WHERE CODIGO=@CODIGO";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@DT_VALIDADE", fa.DataValidade));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_USUARIO", fa.usuario.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_ANIMAL", fa.usuario.Codigo));

                cmd.ExecuteNonQuery();

                sql = "SELECT MAX(CODIGO) FROM FICHA_ALIMENTO";
                SqlCommand cmd2 = new SqlCommand(sql, conexao.sqlconn);
                SqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    codigo = reader.GetInt32(reader.GetOrdinal("codigo"));
                }

                foreach (Alimento a in fa.listaAlimento)
                {
                    sql = "ALTER TABLE ALIMENTO_DA_FICHA SET QUANTIDADE=@QUANTIDADE, CODIGO_ALIMENTO=@CODIGO_ALIMENTO, CODIGO_FICHA=@CODIGO_FICHA WHERE CODIGO=@CODIGO";
                    SqlCommand cmd3 = new SqlCommand(sql, conexao.sqlconn);

                    cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", a.Quantidade));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_ALIMENTO", a.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_FICHA", codigo));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", fa.Codigo));

                    cmd.ExecuteNonQuery();
                }
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


        public void Excluir(FichaAlimento fa)
        {
            throw new NotImplementedException();
        }

        public List<FichaAlimento> Pesquisar(FichaAlimento fa, bool alt = false)
        {
            List<FichaAlimento> listafichaalimento = new List<FichaAlimento>();

            try
            {
                conexao.openConnection();
                string sql = "SELECT FICHA_ALIMENTO.CODIGO, FICHA_ALIMENTO.DESCRICAO, FICHA_ALIMENTO.DT_CRIACAO, FICHA_ALIMENTO.DT_VALIDADE, USUARIO.NOME AS NOME_USUARIO FROM FICHA_ALIMENTO " +
                             "INNER JOIN USUARIO ON (USUARIO.CODIGO = FICHA_ALIMENTO.CODIGO_USUARIO) WHERE FICHA_ALIMENTO.CODIGO > 0 ";

                if (fa.animal.Codigo > 0)
                {
                    sql += " and FICHA_ALIMENTO.CODIGO_ANIMAL = @CODIGO_ANIMAL";
                }

                if (fa.usuario.Codigo > 0)
                {
                    sql += " and FICHA_ALIMENTO.CODIGO_USUARIO = @CODIGO_USUARIO";
                }
 
                if (alt == false)
                {
                    if (fa.Codigo > 0)
                    {
                        sql += " and FICHA_ALIMENTO.CODIGO = @CODIGO";
                    }

                }
                else
                {
                    if (fa.Codigo > 0)
                    {
                        sql += " and FICHA_ALIMENTO.CODIGO <> @CODIGO";
                    }
                }

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                if (fa.animal.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO_ANIMAL", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO_ANIMAL"].Value = fa.animal.Codigo;
                }

                if (fa.usuario.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO_USUARIO", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO_USUARIO"].Value = fa.usuario.Codigo;
                }

                if (fa.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO"].Value = fa.Codigo;
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FichaAlimento fichaalimento = new FichaAlimento();
                    fichaalimento.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO"));
                    fichaalimento.Descricao = reader.GetString(reader.GetOrdinal("DESCRICAO"));
                    fichaalimento.DataCriacao = reader.GetDateTime(reader.GetOrdinal("DT_CRIACAO")).ToString("dd/MM/yyyy");
                    fichaalimento.DataValidade = reader.GetDateTime(reader.GetOrdinal("DT_VALIDADE")).ToString("dd/MM/yyyy");
                    fichaalimento.usuario.Nome= reader.GetString(reader.GetOrdinal("NOME_USUARIO"));

                    listafichaalimento.Add(fichaalimento);
                }

                reader.Close();

                cmd.Dispose();

                conexao.closeConnection();
            }
            catch (Exception ex)
            {
                throw new DadosException(ex.Message);
            }

            return listafichaalimento;
        }
    }
}

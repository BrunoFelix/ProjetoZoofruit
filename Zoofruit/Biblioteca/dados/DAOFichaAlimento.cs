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
        Conexao conexao2;
        public DAOFichaAlimento()
        {
            conexao = new Conexao();
        }


        public void Adicionar(FichaAlimento fa)
        {
            conexao.openConnection();
            try
            {
                
                string sql = "INSERT INTO FICHA_ALIMENTO (DESCRICAO, DT_CRIACAO, DT_VALIDADE, QTD_MAX_CAL, HORA_A_SER_EXECUTADO, CODIGO_USUARIO, CODIGO_ANIMAL) OUTPUT INSERTED.CODIGO VALUES (@DESCRICAO, @DT_CRIACAO, @DT_VALIDADE, @QTD_MAX_CAL, @HORA_A_SER_EXECUTADO, @CODIGO_USUARIO, @CODIGO_ANIMAL)";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", fa.Descricao));
                cmd.Parameters.Add(new SqlParameter("@DT_CRIACAO", fa.DataCriacao));
                cmd.Parameters.Add(new SqlParameter("@DT_VALIDADE", fa.DataValidade));
                cmd.Parameters.Add(new SqlParameter("@QTD_MAX_CAL", fa.Qtd_max_cal));
                cmd.Parameters.Add(new SqlParameter("@HORA_A_SER_EXECUTADO", fa.Hora_a_ser_executado));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_USUARIO", fa.Usuario.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_ANIMAL", fa.Animal.Codigo));

                //cmd.ExecuteNonQuery();

                /*sql = "SELECT MAX(CODIGO) AS CODIGO FROM FICHA_ALIMENTO";
                SqlCommand cmd2 = new SqlCommand(sql, conexao.sqlconn);
                SqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    codigo = reader.GetInt32(reader.GetOrdinal("codigo"));
                }*/

                int codigo = (int)cmd.ExecuteScalar();

                conexao.closeConnection();
                conexao.openConnection();

                foreach (Alimento a in fa.ListaAlimento)
                {
                    sql = "INSERT INTO FICHA_CONTEM_ALIMENTO (CODIGO_ALIMENTO, CODIGO_FICHA) VALUES (@CODIGO_ALIMENTO, @CODIGO_FICHA)";
                    SqlCommand cmd3 = new SqlCommand(sql, conexao.sqlconn);

                    cmd3.Parameters.Add(new SqlParameter("@CODIGO_ALIMENTO", a.Codigo));
                    cmd3.Parameters.Add(new SqlParameter("@CODIGO_FICHA", codigo));

                    cmd3.ExecuteNonQuery();
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


        //Altera um Registro na tabela de Ficha de Alimento
        public void Alterar(FichaAlimento fa)
        {

            /*conexao.openConnection();
            try
            {

                string sql = "ALTER TABLE FICHA_ALIMENTO SET DT_VALIDADE=@DT_VALIDADE, CODIGO_USUARIO=@CODIGO_USUARIO, CODIGO_ANIMAL=@CODIGO_ANIMAL WHERE CODIGO=@CODIGO";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@DT_VALIDADE", fa.DataValidade));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_USUARIO", fa.Usuario.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_ANIMAL", fa.Animal.Codigo));

                cmd.ExecuteNonQuery();

                /*INSERT INTO TESTE(NOME) OUTPUT INSERTED.NOME_DA_CHAVE_PRIMARIA VALUES ('melo');

                int modified = (int)cmd.executescalar();*/

                /*sql = "SELECT MAX(CODIGO) FROM FICHA_ALIMENTO";
                SqlCommand cmd2 = new SqlCommand(sql, conexao.sqlconn);
                SqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    codigo = reader.GetInt32(reader.GetOrdinal("codigo"));
                }

                foreach (Alimento a in fa.ListaAlimento)
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
            }*/
        }


        public void Excluir(FichaAlimento fa)
        {
            conexao.openConnection();
            try
            {
                string sql = "UPDATE FICHA_ALIMENTO SET ATIVO = 'F' WHERE CODIGO=@CODIGO";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@CODIGO", fa.Codigo));

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

        public List<FichaAlimento> Pesquisar(FichaAlimento fa, bool alt = false)
        {
            List<FichaAlimento> listafichaalimento = new List<FichaAlimento>();

            try
            {
                conexao.openConnection();
                string sql = "SELECT FICHA_ALIMENTO.CODIGO, FICHA_ALIMENTO.DESCRICAO, FICHA_ALIMENTO.DT_CRIACAO, FICHA_ALIMENTO.DT_VALIDADE, FICHA_ALIMENTO.QTD_MAX_CAL, FICHA_ALIMENTO.HORA_A_SER_EXECUTADO, " +
                             "USUARIO.NOME AS NOME_USUARIO, USUARIO.LOGIN AS LOGIN_USUARIO, FICHA_ALIMENTO.CODIGO_USUARIO, ANIMAL.NOME AS NOME_ANIMAL, FICHA_ALIMENTO.CODIGO_ANIMAL FROM FICHA_ALIMENTO " +
                             "INNER JOIN USUARIO ON (USUARIO.CODIGO = FICHA_ALIMENTO.CODIGO_USUARIO) "+
                             "INNER JOIN ANIMAL ON (ANIMAL.CODIGO = FICHA_ALIMENTO.CODIGO_ANIMAL) "+
                             "WHERE FICHA_ALIMENTO.CODIGO > 0 AND FICHA_ALIMENTO.ATIVO = 'T' ";

                if (fa.Animal.Codigo > 0)
                {
                    sql += " and FICHA_ALIMENTO.CODIGO_ANIMAL = @CODIGO_ANIMAL";
                }

                if (fa.Usuario.Codigo > 0)
                {
                    sql += " and FICHA_ALIMENTO.CODIGO_USUARIO = @CODIGO_USUARIO";
                }

                if (fa.DataValidade != null && fa.DataValidade.Trim().Equals("") == false)
                {
                    sql += " and FICHA_ALIMENTO.DT_VALIDADE >= @DT_VALIDADE";

                    sql += " AND FICHA_ALIMENTO.CODIGO NOT IN(SELECT FICHA_EXECUCAO_ALIMENTO.CODIGO_FICHA FROM FICHA_EXECUCAO_ALIMENTO WHERE " +
                           "CAST(FICHA_EXECUCAO_ALIMENTO.DT_EXECUCAO AS DATE) <= '"+ DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString()+"') ";
                }


                if (alt == false)
                {
                    if (fa.Hora_a_ser_executado != null && fa.Hora_a_ser_executado.Trim().Equals("") == false)
                    {
                        sql += " and FICHA_ALIMENTO.HORA_A_SER_EXECUTADO <= @HORA_A_SER_EXECUTADO";
                    }
                }
                else
                {
                    if (fa.Hora_a_ser_executado != null && fa.Hora_a_ser_executado.Trim().Equals("") == false)
                    {
                        sql += " and FICHA_ALIMENTO.HORA_A_SER_EXECUTADO = @HORA_A_SER_EXECUTADO";
                    }
                }

                if (fa.Codigo > 0)
                {
                    sql += " and FICHA_ALIMENTO.CODIGO = @CODIGO";
                }
            
                sql += " ORDER BY FICHA_ALIMENTO.HORA_A_SER_EXECUTADO ASC ";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                if (fa.Animal.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO_ANIMAL", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO_ANIMAL"].Value = fa.Animal.Codigo;
                }

                if (fa.Usuario.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO_USUARIO", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO_USUARIO"].Value = fa.Usuario.Codigo;
                }

                if (fa.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO"].Value = fa.Codigo;
                }

                if (fa.DataValidade != null && fa.DataValidade.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@DT_VALIDADE", SqlDbType.VarChar);
                    cmd.Parameters["@DT_VALIDADE"].Value = fa.DataValidade;
                }

                if (fa.Hora_a_ser_executado != null && fa.Hora_a_ser_executado.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@HORA_A_SER_EXECUTADO", SqlDbType.VarChar);
                    cmd.Parameters["@HORA_A_SER_EXECUTADO"].Value = fa.Hora_a_ser_executado;
                }

                SqlDataReader reader = cmd.ExecuteReader();
           

                while (reader.Read())
                {
                    FichaAlimento fichaalimento = new FichaAlimento();
                    fichaalimento.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO"));
                    fichaalimento.Descricao = reader.GetString(reader.GetOrdinal("DESCRICAO"));
                    fichaalimento.DataCriacao = reader.GetDateTime(reader.GetOrdinal("DT_CRIACAO")).ToString("dd/MM/yyyy");
                    fichaalimento.DataValidade = reader.GetDateTime(reader.GetOrdinal("DT_VALIDADE")).ToString("dd/MM/yyyy");
                    fichaalimento.Qtd_max_cal = reader.GetDouble(reader.GetOrdinal("QTD_MAX_CAL"));
                    fichaalimento.Hora_a_ser_executado = Convert.ToString(reader.GetInt32(reader.GetOrdinal("HORA_A_SER_EXECUTADO")));
                    fichaalimento.Usuario.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO_USUARIO"));
                    fichaalimento.Usuario.Nome = reader.GetString(reader.GetOrdinal("NOME_USUARIO"));
                    fichaalimento.Usuario.Login = reader.GetString(reader.GetOrdinal("LOGIN_USUARIO"));
                    fichaalimento.Animal.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO_ANIMAL"));
                    fichaalimento.Animal.Nome = reader.GetString(reader.GetOrdinal("NOME_ANIMAL"));

                    sql = "SELECT FICHA_CONTEM_ALIMENTO.CODIGO_ALIMENTO, ALIMENTO.NOME FROM FICHA_CONTEM_ALIMENTO INNER JOIN ALIMENTO ON (ALIMENTO.CODIGO = FICHA_CONTEM_ALIMENTO.CODIGO_ALIMENTO) " +
                      "WHERE FICHA_CONTEM_ALIMENTO.CODIGO_FICHA = " + fichaalimento.Codigo;

                    conexao2 = new Conexao();

                    conexao2.openConnection();

                    SqlCommand cmd2 = new SqlCommand(sql, conexao2.sqlconn);
                    SqlDataReader reader2 = cmd2. ExecuteReader();

                    List<Alimento> listaalimento = new List<Alimento>();

                    while (reader2.Read())
                    {
                        Alimento alimento = new Alimento();
                        alimento.Codigo = reader2.GetInt32(reader2.GetOrdinal("CODIGO_ALIMENTO"));
                        alimento.Nome = reader2.GetString(reader2.GetOrdinal("NOME"));
                        listaalimento.Add(alimento);
                    }

                    conexao2.closeConnection();

                    fichaalimento.ListaAlimento = listaalimento;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.basica;
using Biblioteca.util;
using System.Data.SqlClient;

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
                
                string sql = "INSERT INTO FICHA_ALIMENTO (DT_CRIACAO, HR_CRIACAO, DT_VALIDADE, CODIGO_USUARIO, CODIGO_ANIMAL) VALUES (@DT_CRIACAO, @HR_CRIACAO, @DT_VALIDADE, @TIPO, @CODIGO_USUARIO, @CODIGO_ANIMAL)";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@DT_CRIACAO", fa.DataCriacao));
                cmd.Parameters.Add(new SqlParameter("@HR_CRIACAO", fa.HoraCriacao));
                cmd.Parameters.Add(new SqlParameter("@DT_VALIDADE", fa.DataValidade));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_USUARIO", fa.Usuario.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_ANIMAL", fa.Animal.Codigo));

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
                    sql = "INSERT INTO ALIMENTO_DA_FICHA (QUANTIDADE, CODIGO_ALIMENTO, CODIGO_FICHA) VALUES (@QUANTIDADE, @CODIGO_ALIMENTO, @CODIGO_FICHA)";
                    SqlCommand cmd3 = new SqlCommand(sql, conexao.sqlconn);

                    cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", a.Quantidade));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_ALIMENTO", a.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_FICHA", codigo));

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


        //Altera um Registro na tabela de Ficha de Alimento
        public void Alterar(FichaAlimento fa)
        {

            conexao.openConnection();
            try
            {

                string sql = "ALTER TABLE FICHA_ALIMENTO SET DT_VALIDADE=@DT_VALIDADE, CODIGO_USUARIO=@CODIGO_USUARIO, CODIGO_ANIMAL=@CODIGO_ANIMAL WHERE CODIGO=@CODIGO";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@DT_VALIDADE", fa.DataValidade));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_USUARIO", fa.Usuario.Codigo));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_ANIMAL", fa.Animal.Codigo));

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

        public List<FichaAlimento> Pesquisar(FichaAlimento fa)
        {
            throw new NotImplementedException();
        }
    }
}

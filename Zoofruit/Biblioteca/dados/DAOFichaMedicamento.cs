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
    public class DAOFichaMedicamento : iDAOFichaMedicamento
    {
        int codigo;
        Conexao conexao;
        public DAOFichaMedicamento()
        {
            conexao = new Conexao();
        }

        public void Adicionar(FichaMedicamento fm)
        {
            conexao.openConnection();
            try
            {
                string sql = "INSERT INTO FICHA_MEDICAMENTO (DESCRICAO, DT_CRIACAO, DT_VALIDADE, CODIGO_USUARIO, CODIGO_ANIMAL ) VALUES (@DESCRICAO, @DT_CRIACAO, @DT_VALIDADE, @CODIGO_USUARIO, @CODIGO_ANIMAL)";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", fm.Descricao));
                cmd.Parameters.Add(new SqlParameter("@DT_CRIACAO", fm.DataCriacao));
                cmd.Parameters.Add(new SqlParameter("@DT_VALIDADE", fm.DataValidade));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_USUARIO", fm.Usuario));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_ANIMAL", fm.Animal));
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

        public void Alterar(FichaMedicamento fm)
        {
            conexao.openConnection();
            try
            {

                string sql = "ALTER TABLE FICHA_MEDICAMENTO SET DT_VALIDADE=@DT_VALIDADE, CODIGO_USUARIO=@CODIGO_USUARIO, CODIGO_ANIMAL=@CODIGO_ANIMAL WHERE CODIGO=@CODIGO";
                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@DESCRICAO", fm.Descricao));
                cmd.Parameters.Add(new SqlParameter("@DT_CRIACAO", fm.DataCriacao));
                cmd.Parameters.Add(new SqlParameter("@DT_VALIDADE", fm.DataValidade));

                cmd.ExecuteNonQuery();

                sql = "SELECT MAX(CODIGO) FROM FICHA_MEDICAMENTO";
                SqlCommand cmd2 = new SqlCommand(sql, conexao.sqlconn);
                SqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {
                    codigo = reader.GetInt32(reader.GetOrdinal("codigo"));
                }

                /*foreach (Alimento a in fm.listaMedicamento)
                {
                    sql = "ALTER TABLE ALIMENTO_DA_FICHA SET QUANTIDADE=@QUANTIDADE, CODIGO_ALIMENTO=@CODIGO_ALIMENTO, CODIGO_FICHA=@CODIGO_FICHA WHERE CODIGO=@CODIGO";
                    SqlCommand cmd3 = new SqlCommand(sql, conexao.sqlconn);

                    cmd.Parameters.Add(new SqlParameter("@QUANTIDADE", a.Quantidade));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_ALIMENTO", a.Codigo));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_FICHA", codigo));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", fa.Codigo));

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

        public void Excluir(FichaMedicamento fm)
        {
            throw new NotImplementedException();
        }

        public List<FichaMedicamento> Pesquisar(FichaMedicamento fm)
        {
            throw new NotImplementedException();
        }

        public List<FichaMedicamento> Pesquisar(FichaMedicamento fm, bool alt = false)
        {
            List<FichaMedicamento> listafichamedicamento = new List<FichaMedicamento>();

            try
            {
                conexao.openConnection();
                string sql = "SELECT FICHA_MEDICAMENTO.CODIGO, FICHA_MEDICAMENTO.DESCRICAO, FICHA_MEDICAMENTO.DT_CRIACAO, FICHA_MEDICAMENTO.DT_VALIDADE, USUARIO.NOME AS NOME_USUARIO FROM FICHA_MEDICAMENTO " +
                             "INNER JOIN USUARIO ON (USUARIO.CODIGO = FICHA_MEDICAMENTO.CODIGO_USUARIO) WHERE FICHA_MEDICAMENTO.CODIGO > 0 ";

                if (fm.Animal.Codigo > 0)
                {
                    sql += " and FICHA_ALIMENTO.CODIGO_ANIMAL = @CODIGO_ANIMAL";
                }

                if (fm.Usuario.Codigo > 0)
                {
                    sql += " and FICHA_ALIMENTO.CODIGO_USUARIO = @CODIGO_USUARIO";
                }

                if (alt == false)
                {
                    if (fm.Codigo > 0)
                    {
                        sql += " and FICHA_ALIMENTO.CODIGO = @CODIGO";
                    }

                }
                else
                {
                    if (fm.Codigo > 0)
                    {
                        sql += " and FICHA_ALIMENTO.CODIGO <> @CODIGO";
                    }
                }

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                if (fm.Animal.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO_ANIMAL", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO_ANIMAL"].Value = fm.Animal.Codigo;
                }

                if (fm.Usuario.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO_USUARIO", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO_USUARIO"].Value = fm.Usuario.Codigo;
                }

                if (fm.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO"].Value = fm.Codigo;
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FichaMedicamento fichamedicamento = new FichaMedicamento();
                    fichamedicamento.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO"));
                    fichamedicamento.Descricao = reader.GetString(reader.GetOrdinal("DESCRICAO"));
                    fichamedicamento.DataCriacao = reader.GetDateTime(reader.GetOrdinal("DT_CRIACAO")).ToString("dd/MM/yyyy");
                    fichamedicamento.DataValidade = reader.GetDateTime(reader.GetOrdinal("DT_VALIDADE")).ToString("dd/MM/yyyy");
                    fichamedicamento.Usuario.Nome = reader.GetString(reader.GetOrdinal("NOME_USUARIO"));

                    listafichamedicamento.Add(fichamedicamento);
                }

                reader.Close();

                cmd.Dispose();

                conexao.closeConnection();
            }
            catch (Exception ex)
            {
                throw new DadosException(ex.Message);
            }

            return listafichamedicamento;
        }
    }
}
  


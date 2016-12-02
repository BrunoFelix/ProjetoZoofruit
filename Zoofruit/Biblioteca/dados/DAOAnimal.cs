using System;
using System.Collections.Generic;
using Biblioteca.basica;
using Biblioteca.util;
using System.Data.SqlClient;
using System.Data;

namespace Biblioteca.dados
{
    public class DAOAnimal : iDAOAnimal
    {
        Conexao conexao;

        public DAOAnimal()
            {
            conexao = new Conexao();
            Animal a = new Animal();
            }

        public void Adicionar(Animal a)
        {
            conexao.openConnection();
            try
            {
                string sql = "INSERT INTO ANIMAL (NOME, COR, PORTE, PESO, CODIGO_TIPOANIMAL) VALUES (@NOME, @COR, @PORTE, @PESO, @CODIGO_TIPOANIMAL)";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@NOME", a.Nome));
                cmd.Parameters.Add(new SqlParameter("@COR", a.Cor));
                cmd.Parameters.Add(new SqlParameter("@PORTE", a.Porte));
                cmd.Parameters.Add(new SqlParameter("@PESO", a.Peso));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_TIPOANIMAL", a.TipoAnimal.Codigo));
                //cmd.Parameters.Add(new SqlParameter("@FOTO", a.Foto));


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

        public void Alterar(Animal a)
        {
            conexao.openConnection();
            try
            {
                string sql = "UPDATE ANIMAL SET NOME=@NOME, COR=@COR, PORTE=@PORTE, PESO=@PESO, CODIGO_TIPOANIMAL=@CODIGO_TIPOANIMAL WHERE CODIGO=@CODIGO";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@NOME", a.Nome));
                cmd.Parameters.Add(new SqlParameter("@COR", a.Cor));
                cmd.Parameters.Add(new SqlParameter("@PORTE", a.Porte));
                cmd.Parameters.Add(new SqlParameter("@PESO", a.Peso));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_TIPOANIMAL", a.TipoAnimal.Codigo));
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

        public void Excluir(Animal a)
        {
            conexao.openConnection();
            try
            {
                string sql = "UPDATE ANIMAL SET ATIVO = 'F' WHERE CODIGO=@CODIGO";

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

        public List<Animal> Pesquisar(Animal a, bool alt = false)
        {
            List<Animal> listaAnimal = new List<Animal>();

           try { 
            conexao.openConnection();
            string sql = "SELECT Animal.codigo, Animal.Nome, Animal.Cor, Animal.Porte, Animal.Peso, Animal.codigo_TipoAnimal, " +
                "TipoAnimal.descricao FROM Animal LEFT JOIN TipoAnimal ON (TipoAnimal.codigo = Animal.codigo_TipoAnimal) WHERE Animal.codigo > 0 AND Animal.ATIVO = 'T' ";

                if (a.Nome != null && a.Nome.Trim().Equals("") == false)
                {
                    sql += " and ANIMAL.NOME LIKE @NOME";
                }

                if (a.Cor != null && a.Cor.Trim().Equals("") == false)
                {
                    sql += " and ANIMAL.COR = @COR";
                }
                     
                if (a.Porte != null && a.Porte.Trim().Equals("") == false)
                {
                    sql += " and ANIMAL.PORTE = @PORTE";
                }

                if (a.Peso > 0)
                {
                    sql += " and ANIMAL.PESO = @PESO";
                }

                if (a.TipoAnimal.Codigo > 0)
                {
                    sql += " and ANIMAL.CODIGO_TIPOANIMAL = @CODIGO_TIPOANIMAL";
                }

                if (alt == false)
                {
                    if (a.Codigo > 0)
                    {
                        sql += " and ANIMAL.CODIGO = @codigo";
                    }

                }
                else
                {
                    if (a.Codigo > 0)
                    {
                        sql += " and ANIMAL.CODIGO <> @codigo";
                    }
                }

                sql += " ORDER BY TIPOANIMAL.DESCRICAO ASC, NOME ASC "; 

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                if (a.Nome != null && a.Nome.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@NOME", SqlDbType.VarChar);
                    cmd.Parameters["@NOME"].Value = "%"+a.Nome+"%";
                }

                if (a.Cor != null && a.Cor.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@COR", SqlDbType.VarChar);
                    cmd.Parameters["@COR"].Value = a.Cor;
                }

                if (a.Porte != null && a.Cor.Trim().Equals("") == false)
                {
                    cmd.Parameters.Add("@PORTE", SqlDbType.VarChar);
                    cmd.Parameters["@PORTE"].Value = a.Porte;
                }

                if (a.Peso > 0)
                {
                    cmd.Parameters.Add("@PESO", SqlDbType.VarChar);
                    cmd.Parameters["@PESO"].Value = a.Peso;
                }

                if (a.TipoAnimal.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO_TIPOANIMAL", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO_TIPOANIMAL"].Value = a.TipoAnimal.Codigo;
                }

                if (a.Codigo > 0)
                {
                    cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar);
                    cmd.Parameters["@CODIGO"].Value = a.Codigo;
                }

                SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Animal animal = new Animal();
                animal.Codigo = reader.GetInt32(reader.GetOrdinal("codigo"));
                animal.Nome= reader.GetString(reader.GetOrdinal("Nome"));
                animal.Cor = reader.GetString(reader.GetOrdinal("Cor"));
                animal.Porte = reader.GetString(reader.GetOrdinal("Porte"));
                animal.Peso = reader.GetDouble(reader.GetOrdinal("Peso"));
                animal.TipoAnimal.Codigo = reader.GetInt32(reader.GetOrdinal("codigo_TipoAnimal"));
                animal.TipoAnimal.Descricao = reader.GetString(reader.GetOrdinal("descricao"));
      
                listaAnimal.Add(animal);
            }

            reader.Close();

            cmd.Dispose();

            conexao.closeConnection();
        }
            catch(Exception ex)
            {
                throw new DadosException(ex.Message);
    }

            return listaAnimal;
        }
    }
}

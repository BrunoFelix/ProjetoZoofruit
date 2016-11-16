using System;
using System.Collections.Generic;
using Biblioteca.basica;
using Biblioteca.util;
using System.Data.SqlClient;


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
                string sql = "DELETE FROM FICHA_ALIMENTO WHERE CODIGO_ANIMAL=@CODIGO_ANIMAL";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@CODIGO_ANIMAL", a.Codigo));

                cmd.ExecuteNonQuery();

                sql = "DELETE FROM FICHA_MEDICAMENTO WHERE CODIGO_ANIMAL=@CODIGO_ANIMAL";

                cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@CODIGO_ANIMAL", a.Codigo));

                cmd.ExecuteNonQuery();

                sql = "DELETE FROM ANIMAL WHERE CODIGO=@CODIGO";

                cmd = new SqlCommand(sql, conexao.sqlconn);

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

        public List<Animal> Pesquisar(Animal a)
        {
            List<Animal> listaAnimal = new List<Animal>();

           try { 
            conexao.openConnection();
            string sql = "SELECT Animal.codigo, Animal.Nome, Animal.Cor, Animal.Porte, Animal.Peso, Animal.codigo_TipoAnimal, " +
                "TipoAnimal.descricao FROM Animal LEFT JOIN TipoAnimal ON (TipoAnimal.codigo = Animal.codigo_TipoAnimal) WHERE Animal.codigo > 0 ";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);
                SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Animal animal = new Animal();
                animal.Codigo = reader.GetInt32(reader.GetOrdinal("codigo"));
                animal.Nome= reader.GetString(reader.GetOrdinal("Nome"));
                animal.Cor = reader.GetString(reader.GetOrdinal("Cor"));
                animal.Porte = reader.GetString(reader.GetOrdinal("Porte"));
                animal.Peso = reader.GetDouble(reader.GetOrdinal("Peso"));
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

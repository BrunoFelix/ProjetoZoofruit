using System;
using System.Collections.Generic;
using Biblioteca.basica;
using Biblioteca.util;
using System.Data.SqlClient;


namespace Biblioteca.dados
{
    class DAOAnimal : iDAOAnimal
    {
        Conexao conexao;

        public DAOAnimal()
            {
            conexao = new Conexao();
            Animal a = new Animal();
            }

        public void adicionar(Animal a)
        {
            conexao.openConnection();
            try
            {
                string sql = "INSERT INTO ANIMAL (NOME, COR, PORTE, PESO, CODIGO_TIPOANIMAL, FOTO) VALUES (@NOME, @COR, @PORTE, @PESO, @CODIGO_TIPOANIMAL, @FOTO)";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add(new SqlParameter("@NOME", a.Nome));
                cmd.Parameters.Add(new SqlParameter("@COR", a.Cor));
                cmd.Parameters.Add(new SqlParameter("@PORTE", a.Porte));
                cmd.Parameters.Add(new SqlParameter("@PESO", a.Peso));
                cmd.Parameters.Add(new SqlParameter("@CODIGO_TIPOANIMAL", a.TipoAnimal.Codigo));
                cmd.Parameters.Add(new SqlParameter("@FOTO", a.Foto));


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

        public void alterar(Animal a)
        {
            conexao.openConnection();
            try
            {
                string sql = "ALTER TABLE USUARIO SET NOME=@NOME, COR=@COR, PORTE=@PORTE, PESO=@PESO, CODIGO_TIPOANIMAL=@CODIGO_TIPOANIMAL) WHERE CODIGO=@CODIGO";

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

        public void excluir(Animal a)
        {
            conexao.openConnection();
            try
            {
                string sql = "DELETE FROM ANIMAL WHERE CODIGO=@CODIGO";

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

        public List<Animal> pesquisar(Animal a)
        {
            List<Animal> listaanimal = new List<Animal>();

           try { 
            conexao.openConnection();
            string sql = "SELECT Animal.Nome, Animal.Cor, Animal.Porte, Animal.Peso, Animal.codigo_TipoAnimal, " +
                "TipoUsuario.descricao FROM Usuario LEFT JOIN TipoUsuario ON (TipoAnimal.codigo = Animal.codigo_TipoAnimal) WHERE Animal.codigo > 0 ";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);
                SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Animal animal = new Animal();
                animal.Codigo = reader.GetInt32(reader.GetOrdinal("Cod_Animal"));
                animal.Nome= reader.GetString(reader.GetOrdinal("Nome"));
                animal.Cor = reader.GetString(reader.GetOrdinal("Cor"));
                animal.Porte = reader.GetString(reader.GetOrdinal("Porte"));
                animal.Peso = reader.GetDouble(reader.GetOrdinal("Peso"));
                animal.TipoAnimal.Codigo = reader.GetInt32(reader.GetOrdinal("cod_tipoAnimal"));
                

                listaanimal.Add(animal);
            }

            reader.Close();

            cmd.Dispose();

            conexao.closeConnection();
        }
            catch(Exception ex)
            {
                throw new DadosException(ex.Message);
    }

            return listaanimal;
        }
    }
}

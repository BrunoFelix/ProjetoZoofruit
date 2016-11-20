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
    class DAOFichaExecucaoAlimento : iDAOFichaExecucaoAlimento
    {
        Conexao conexao;
        public DAOFichaExecucaoAlimento()
        {
            conexao = new Conexao();
        }

        public void Adicionar(FichaExecucaoAlimento fea)
        {
            throw new NotImplementedException();
        }

        public void Alterar(FichaExecucaoAlimento fea)
        {
            throw new NotImplementedException();
        }

        public void Excluir(FichaExecucaoAlimento fea)
        {
            throw new NotImplementedException();
        }

        public List<Alimento> Pesquisar(int codigo)
        {
            List<Alimento> listaAlimento = new List<Alimento>();

            try
            {
                conexao.openConnection();
                string sql = "SELECT ALIMENTO.CODIGO ,ALIMENTO.NOME,ALIMENTO.QUANTIDADE, ALIMENTO.VALOR_CALORICO FROM FICHA_CONTEM_ALIMENTO "+
                             "INNER JOIN ALIMENTO ON (ALIMENTO.CODIGO = FICHA_CONTEM_ALIMENTO.CODIGO_ALIMENTO) WHERE FICHA_CONTEM_ALIMENTO.CODIGO_FICHA = @CODIGO";

                SqlCommand cmd = new SqlCommand(sql, conexao.sqlconn);

                cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar);
                cmd.Parameters["@CODIGO"].Value = codigo;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Alimento alimento = new Alimento();
                    alimento.Codigo = reader.GetInt32(reader.GetOrdinal("CODIGO"));
                    alimento.Nome = reader.GetString(reader.GetOrdinal("NOME"));
                    alimento.Quantidade = reader.GetDouble(reader.GetOrdinal("QUANTIDADE"));
                    alimento.ValorCalorico = reader.GetDouble(reader.GetOrdinal("VALOR_CALORICO"));

                    listaAlimento.Add(alimento);
                }

                reader.Close();

                cmd.Dispose();

                conexao.closeConnection();
            }
            catch (Exception ex)
            {
                throw new DadosException(ex.Message);
            }

            return listaAlimento;
        }

        public List<FichaExecucaoAlimento> Pesquisar(FichaExecucaoAlimento fea, bool alt = false)
        {
            throw new NotImplementedException();
        }
    }
}

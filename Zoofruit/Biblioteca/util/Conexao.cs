using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.util
{
    public class Conexao
    {
        public SqlConnection sqlconn;

        //string stringdeconexao = "Data Source=localhost; Initial Catalog=zoofruit; User Id=aluno; Password=aluno;";

        string stringdeconexao = @"Data Source=MAIKONSILVA\SQLSERVER14; Initial Catalog=zoofruit; User Id=sa; Password=123456789;"; //Maikon

        //string stringdeconexao = @"Data Source=NOTEBOOK-L3N0VO\SQLEXPRESS; Initial Catalog=zoofruit; User Id=sa; Password=123456789;";

        //string stringdeconexao = @"Data Source=DESKTOP-EPHSSJ8\SQLEXPRESS; Initial Catalog=zoofruit; User Id=sa; Password=123456;";


        public void openConnection()
        {
            try
            {
                this.sqlconn = new SqlConnection(stringdeconexao);
                this.sqlconn.Open();
            }
            catch (SqlException ex)
            {
                throw new ConexaoException(ex.Message);
            }
        }

        public void closeConnection()
        {
            try
            {
                this.sqlconn.Close();
                this.sqlconn.Dispose();
            }
            catch (SqlException ex)
            {
                throw new ConexaoException(ex.Message);
            }
        }
    }
}

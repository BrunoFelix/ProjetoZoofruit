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
        string stringdeconexao = "Data Source=localhost; Initial Catalog=zoofruit; User Id=aluno; Password=aluno;";

        public void openConnection()
        {
            this.sqlconn = new SqlConnection(stringdeconexao);
            this.sqlconn.Open();
        }

        public void closeConnection()
        {
            this.sqlconn.Close();
            this.sqlconn.Dispose();
        }
    }
}

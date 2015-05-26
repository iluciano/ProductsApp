using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProductsApp.Controllers
{
    public static class conexaoBD
    {
        public static SqlConnection RetornarConexao()

         {

         SqlConnection conn = new SqlConnection();

         conn.ConnectionString = "Server=(local);Database=conteel;Trusted_Connection=True;";

         return conn;

         }
    }
}
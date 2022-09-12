using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Medicine_Bank
{
    internal class ConnectionHelper
    {
        public static SqlConnection GetConnection()
        {
            String strcon= ConfigurationManager.ConnectionStrings["first_config"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            return conn;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALBase
    {
        public static SqlConnection GetConnection()
        {
            string connectionString;
            SqlConnection objCon;

            connectionString = ConfigurationManager.ConnectionStrings["DBMain"].ConnectionString;
            objCon = new SqlConnection(connectionString);

            return objCon;
        }
        public static SqlConnection GetConnectionTest()
        {
            string connectionString;
            SqlConnection objCon;

            connectionString = ConfigurationManager.ConnectionStrings["DBMainTest"].ConnectionString;
            objCon = new SqlConnection(connectionString);

            return objCon;
        }
    }
}

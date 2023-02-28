using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Data
{
    public class Database
    {
        private static string connectionString = "Data source=DESKTOP-HT8BVVU;Database=Shop1;integrated security=true";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}

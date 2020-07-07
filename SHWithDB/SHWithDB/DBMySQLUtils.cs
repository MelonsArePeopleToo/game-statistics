using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHWithDB
{
    class DBMySQLUtils
    {
        public static MySqlConnection
              GetDBConnection(string host, int port, string database, string username, string password)
        {
            String connString = "Server=" + host + ";Database=" + database
                              + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;

        }

        public static bool IfItNULL(DbDataReader reader, int num)
        {
            reader.GetString(num);
            return true;
        }
    }
}

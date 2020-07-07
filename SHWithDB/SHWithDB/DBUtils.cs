using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHWithDB
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "esport";
            string username = "sanchez";
            string password = "qwerty12";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}

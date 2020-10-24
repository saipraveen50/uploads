using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeConnectionStringAtRuntime
{
    class TestConnection
    {
        SqlConnection connection;

        public TestConnection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public bool IsConnection
        {
            get
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                return true;
            }
        }
    }
}

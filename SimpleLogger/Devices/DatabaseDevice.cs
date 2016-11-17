using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Devices
{
    internal class DatabaseDevice : IDevice
    {
        public void Log(string message, MessageType type)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();
           
            string sql = string.Format("Insert into Log Values('{0}', '{1}', '{2}')", message, type.ToString(), DateTime.Now.ToString("yyyy-MM-dd h:m:s"));
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

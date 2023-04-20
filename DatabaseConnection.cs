using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    class DatabaseConnection
    {
        private string connectionString;
        private SqlConnection connection;

        public DatabaseConnection(string server, string database, string username, string password)
        {
            connectionString = $"Data Source={server};Initial Catalog={database};User ID={username};Password={password}";
            connection = new SqlConnection(connectionString);
        }

        public void Connect()
        {
            try
            {
                connection.Open();                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Disconnect()
        {
            try
            {
                connection.Close();
         
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}






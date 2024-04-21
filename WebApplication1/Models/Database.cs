using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WebApplication1.Models
{
    public class Database : DbContext
    {
        private string host = "127.0.0.1";
        private string port = "3306";
        private string database = "test";
        private string username = "root";
        private string password = "Ar100308";
        private MySqlConnection? Connection { get; set; }
        public MySqlConnection getConnection()
        {
                String connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;
                Connection = new MySqlConnection(connString);
            Console.WriteLine("Connection with db success");
            return Connection;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WebApplication1.Models
{
    public class Database : DbContext
    {
        private string _host = "127.0.0.1";
        private string _port = "3306";
        private string _database = "test";
        private string _username = "root";
        private string _password = "Ar100308";
        private MySqlConnection? Connection { get; set; }
        public MySqlConnection GetConnection() //установка соединения с базой данных
        {
                String connString = "Server=" + _host + ";Database=" + _database + ";port=" + _port + ";User Id=" + _username + ";password=" + _password;
                Connection = new MySqlConnection(connString);
            Console.WriteLine("Connection with db success");
            return Connection;
        }
    }
}

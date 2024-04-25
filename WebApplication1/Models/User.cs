using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebApplication1.Models
{
    public class User
    {
        private string? Username { get; set; }
        private string? Password { get; set; }
        private MySqlConnection? _db;
        public User() 
        {
            _db = new Database().GetConnection();
        }
        public DataSet? GetUsers()
        {
            DataSet? dataSet;
            List<string> users = new List<string>();
            try
            {
                _db?.Open();
                string sql = "SELECT * FROM users";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, _db);
                dataSet = new DataSet();
                adapter.Fill(dataSet);
                _db?.Close();
            }
            catch
            {
                dataSet = null;
            }
            return dataSet;
        }

        public void CreateUser(string? username, string? password)
        {
            _db?.Open();
            string sql = $"INSERT INTO users (`username`, `password`) VALUES ('{username}', '{password}')";
            MySqlCommand command = new MySqlCommand(sql, _db);
            command.ExecuteNonQuery();
            _db?.Close();
        }
    }
}

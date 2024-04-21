using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebApplication1.Models
{
    public class User
    {
        private string? Username { get; set; }
        private string? Password { get; set; }
        private MySqlConnection? db;
        public User() 
        {
            db = new Database().getConnection();
        }
        public DataSet getUsers()
        {
            DataSet? dataSet;
            List<string> users = new List<string>();
            try
            {
                db.Open();
                string sql = "SELECT * FROM users";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, db);
                dataSet = new DataSet();
                adapter.Fill(dataSet);
                db.Close();
            }
            catch
            {
                dataSet = null;
            }
            return dataSet;
        }
    }
}

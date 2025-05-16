using MySql.Data.MySqlClient;
using System.Data;

namespace QuanLyDaiLy.DAL
{
    public class DatabaseHelper
    {
        private string connectionString = "server=localhost;database=dbQuanLyGiaiVoDichBongDaQuocGia;user=root;password=letmein;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var command = new MySqlCommand(query, conn))
            {
                if(parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        public int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var command = new MySqlCommand(query, conn))
            {
                if(parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                conn.Open();

                return command.ExecuteNonQuery();
            }
        }
    }
}

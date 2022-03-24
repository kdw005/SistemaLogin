
using System.Data;
using MySql.Data.MySqlClient;

namespace SistemaLogin2.Util
{
    public class DAL
    {
        private static string server = "localhost";
        private static string database = "financeiro";
        private static string user = "root";
        private static string password = "winneroption";
        private static string connectionString = string.Format(@"Server = {0}; Database = {1}; Uid = {2}; Pwd = {3}", server, database, user, password);
        private  MySqlConnection connection;

        public  DAL()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        public DataTable dql(string sql)
        {
            DataTable dt = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(dt);
            return dt;
        }

        public void dml(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();

        }


    }
}

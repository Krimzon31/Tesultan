using Npgsql;
using System.Data;

namespace Tea_Consultant
{
    public class DBClass
    {
        private static string connstring = String.Format(
           "Server={0};" +
           "Port={1};" +
           "User id={2};" +
           "Password={3};" +
           "Database={4};",

           "localhost",
           5432,
           "postgres",
           "310504",
           "TeaCons");

        private NpgsqlConnection connection = new NpgsqlConnection(connstring);
        private string sql;
        private NpgsqlCommand command;
        private DataTable dataTable;

        public DataTable Select()
        {
            try
            {
                connection.Open();
                sql = @"select * from comand";
                command = new NpgsqlCommand(sql, connection);
                dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                connection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine("Error: " + ex.Message);
                return dataTable;
            }
        }
        
    }
}

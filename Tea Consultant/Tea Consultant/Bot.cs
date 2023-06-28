using Npgsql.Internal.TypeHandlers.GeometricHandlers;
using System.Data;
using Tea_Consultant;

namespace SignalR
{
    public class Bot
    {
        public static DBClass dbClass = new DBClass();
        DataTable table = dbClass.Select();
        /*
        List<(string, string)> lines = new List<(string, string)>();
        public List<(string, string)> DataTableToList()
        {

            public List<(string, string)> dataFileReader()
            {

                var lines = File.ReadAllLines("data.txt");
                var questions = lines
                .Select(s => s.Split('|'))
                .Where(s => s.Length >= 2) // Добавленная проверка
                .Select(s => (s[0], s[1]))
                .ToList();


                return questions;
            }

            return lines;
        }
        */

        public string otveBota(string message)
        {
            string otvet = "";
            try
            {

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string dbOtv = table.Rows[i][0].ToString();
                    if (message.Trim().ToLowerInvariant() == dbOtv.Trim().ToLowerInvariant().ToString())
                    {
                        otvet = table.Rows[i][1].ToString();
                        break;
                    }
                    else
                    {
                        otvet = "Это консультант немного глупый и не понял что вы имеете ввиду. Напишите пожалуйста так как попросили в предыдущем сообщении";
                    }
                }
                return otvet;
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return otvet;
            }

        }
    }
}

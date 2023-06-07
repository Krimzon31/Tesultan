namespace SignalR
{
    public class Bot
    {

        public List<(string, string)> dataFaleReader()
        {
            var lines = File.ReadAllLines("data.txt");
            var questions = lines
            .Select(s => s.Split('|'))
            .Where(s => s.Length >= 2) // Добавленная проверка
            .Select(s => (s[0], s[1]))
            .ToList();
            return questions;
        }


        public string otveBota(string message)
        {
            string otvet = "";
            foreach (var question in dataFaleReader())
            {
                if (message.Trim().ToLowerInvariant() == question.Item1.Trim().ToLowerInvariant().ToString())
                {
                    otvet = question.Item2;
                    break;
                }
                else
                {
                    otvet = "Это консультант немного глупый и не понял что вы имеете ввиду. Напишите пожалуйста так как попросили в предыдущем сообщении";
                }
            }
            return otvet.ToString();

        }
    }
}

using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть дату (у форматі дд.мм.рррр): ");
        string input = Console.ReadLine();
        DateTime targetDate;
        bool parsed = DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out targetDate);
        if (!parsed)
        {
            Console.WriteLine("Неправильний формат дати. Використовуйте дд.мм.рррр.");
            return;
        }
        DateTime today = DateTime.Today;
        if (targetDate < today)
        {
            Console.WriteLine("Ця дата вже минула.");
        }
        else if (targetDate == today)
        {
            Console.WriteLine("Це сьогодні!");
        }
        else
        {
            int daysRemaining = (targetDate - today).Days;
            Console.WriteLine($"До вказаної дати залишилось {daysRemaining} днів.");
        }
    }
}
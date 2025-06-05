using System;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Введіть 3 дати через кому (у форматі дд.мм.рррр):");
        string input = Console.ReadLine();
        string[] parts = input.Split(',');
        if (parts.Length != 3)
        {
            Console.WriteLine("Помилка: введіть рівно три дати.");
            return;
        }
        DateTime[] dates = new DateTime[3];
        for (int i = 0; i < 3; i++)
        {
            if (!DateTime.TryParseExact(parts[i].Trim(), "dd.MM.yyyy", 
                                        CultureInfo.InvariantCulture, 
                                        DateTimeStyles.None, out dates[i]))
            {
                Console.WriteLine($"Помилка: неправильний формат дати — '{parts[i]}'");
                return;
            }
        }
        int minYear = dates.Min(d => d.Year);
        Console.WriteLine($"а) Найменший рік: {minYear}");
        var springDates = dates.Where(d => d.Month >= 3 && d.Month <= 5);
        Console.WriteLine("б) Весняні дати:");
        foreach (var d in springDates)
            Console.WriteLine(d.ToString("dd.MM.yyyy"));
        var latestDate = dates.Max();
        Console.WriteLine($"в) Найпізніша дата: {latestDate:dd.MM.yyyy}");
    }
}
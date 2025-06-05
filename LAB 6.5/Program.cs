using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> strings = new List<string>();
        Console.WriteLine("Введіть кілька рядків (введіть 'stop' для завершення):");
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (input.ToLower() == "stop") break;
            strings.Add(input);
        }
        Console.WriteLine("\nУведені рядки:");
        foreach (string str in strings)
            Console.WriteLine(str);
        Console.Write("\nВведіть значення для пошуку: ");
        string search = Console.ReadLine();
        var found = strings.Where(s => s.Contains(search)).ToList();
        Console.WriteLine($"\nРядки, що містять '{search}':");
        foreach (string str in found)
            Console.WriteLine(str);
        Console.Write("\nВведіть довжину рядків для підрахунку: ");
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            int count = strings.Count(s => s.Length == n);
            Console.WriteLine($"Кількість рядків довжини {n}: {count}");
        }
        else
        {
            Console.WriteLine("Неправильне число.");
        }
        var ascending = strings.OrderBy(s => s).ToList();
        Console.WriteLine("\nСортування у зростаючому порядку:");
        foreach (string str in ascending)
            Console.WriteLine(str);
        var descending = strings.OrderByDescending(s => s).ToList();
        Console.WriteLine("\nСортування у спадному порядку:");
        foreach (string str in descending)
            Console.WriteLine(str);
    }
}
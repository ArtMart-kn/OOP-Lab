using System;

public class Pow
{
   static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть число: ");
        double a = int.Parse(Console.ReadLine());
        double b = Math.Pow(a, 3);
        Console.WriteLine($"Результат: {b}");
    }
}

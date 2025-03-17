using System;

public class Sum
{
   static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть перше число: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введіть друге число: ");
        int b = int.Parse(Console.ReadLine());
        int sum = a + b;
        Console.WriteLine($"Сума: {sum}");
    }
}

using System;

public class Max
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть перше число: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введіть друге число: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Введіть третє число: ");
        int c = int.Parse(Console.ReadLine());
        if (a>b && a>c) 
        {
            Console.WriteLine($"Найбільше число: {a}");
        }
        else if (b>a && b>c) 
        {
            Console.WriteLine($"Найбільше число: {b}");
        }
        else 
        {
            Console.WriteLine($"Найбільше число: {c}");
        }
    }
}

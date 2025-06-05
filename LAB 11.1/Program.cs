using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть рядок з 0 та 1: ");
        string input = Console.ReadLine();
        Console.Write("Введіть позицію, з якої почати заміну (0-based): ");
        int startIndex = int.Parse(Console.ReadLine());
        if (startIndex < 0 || startIndex >= input.Length)
        {
            Console.WriteLine("Помилка: позиція виходить за межі рядка.");
            return;
        }
        char[] chars = input.ToCharArray();
        for (int i = startIndex; i < chars.Length; i++)
        {
            if (chars[i] == '0')
                chars[i] = '1';
            else if (chars[i] == '1')
                chars[i] = '0';
        }
        string result = new string(chars);
        Console.WriteLine("Результат: " + result);
    }
}
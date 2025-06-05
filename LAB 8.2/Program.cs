using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFile = @"D:\C#\test\f.txt";
        string outputFile = @"D:\C#\test\g.txt";

        try
        {
            string text = File.ReadAllText(inputFile);
            string lowerText = text.ToLower();
            File.WriteAllText(outputFile, lowerText);
            Console.WriteLine("Файл g створено успішно з малими літерами.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}
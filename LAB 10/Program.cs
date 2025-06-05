using System;
using System.Collections.Generic;

class CharSet
{
    private HashSet<char> elements;

    // () — конструктор множини (порожньої)
    public CharSet()
    {
        elements = new HashSet<char>();
    }

    // Конструктор з ініціалізатором
    public CharSet(IEnumerable<char> chars)
    {
        elements = new HashSet<char>(chars);
    }

    // Додати символ до множини
    public void Add(char c)
    {
        elements.Add(c);
    }

    // Перевантаження оператора + (об'єднання)
    public static CharSet operator +(CharSet a, CharSet b)
    {
        var result = new CharSet(a.elements);
        foreach (char c in b.elements)
            result.elements.Add(c);
        return result;
    }

    // Перевантаження оператора <= (перевірка підмножини)
    public static bool operator <=(CharSet a, CharSet b)
    {
        return a.IsSubsetOf(b);
    }

    // Для коректності: також перевантажуємо >=
    public static bool operator >=(CharSet a, CharSet b)
    {
        return b <= a;
    }

    // Метод для перевірки підмножини
    public bool IsSubsetOf(CharSet other)
    {
        return elements.IsSubsetOf(other.elements);
    }

    // Вивід на консоль
    public void Print()
    {
        Console.Write("{ ");
        foreach (char c in elements)
            Console.Write(c + " ");
        Console.WriteLine("}");
    }
}
class Program
{
    static void Main()
    {
        CharSet A = new CharSet(new[] { 'a', 'b', 'c' }); 
        CharSet B = new CharSet(new[] { 'b', 'c', 'd' });

        Console.Write("A = "); A.Print();
        Console.Write("B = "); B.Print();

        CharSet C = A + B; 
        Console.Write("A + B = "); C.Print();

        Console.WriteLine($"A <= B? {(A <= B ? "Yes" : "No")}");
        Console.WriteLine($"B <= C? {(B <= C ? "Yes" : "No")}");
    }
}
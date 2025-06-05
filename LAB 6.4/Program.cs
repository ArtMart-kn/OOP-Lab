using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Sum : IComparable<Sum>
{
    public int A { get; set; }
    public int B { get; set; }
    public int Result => A + B;

    public Sum(int a, int b) { A = a; B = b; }

    public int CompareTo(Sum other) => Result.CompareTo(other.Result);

    public override string ToString() => $"A: {A}, B: {B}, Сума: {Result}";
}

public class CollectionType<T> : IEnumerable<T>
{
    private List<T> items = new List<T>();

    public void Add(T item) => items.Add(item);
    public void RemoveAt(int index) => items.RemoveAt(index);
    public int Count => items.Count;
    public T this[int index] { get => items[index]; set => items[index] = value; }

    public void Sort()
    {
        if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
            items.Sort();
        else
            throw new InvalidOperationException("Тип не підтримує сортування");
    }

    public IEnumerable<T> Where(Func<T, bool> predicate) => items.Where(predicate);

    public void Print()
    {
        foreach (var item in items)
            Console.WriteLine(item);
    }

    public IEnumerator<T> GetEnumerator() => items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var collection = new CollectionType<Sum>
        {
            new Sum(3, 4),   
            new Sum(1, 2),  
            new Sum(5, 5),   
            new Sum(0, 0),   
            new Sum(2, 8),   
            new Sum(4, 1),   
        };

        Console.WriteLine("Уся колекція:");
        collection.Print();

        //1. Where + OrderByDescending + Select
        var query1 = collection
            .Where(s => s.Result > 4)
            .OrderByDescending(s => s.Result)
            .Select(s => s.Result);

        Console.WriteLine("\n1. Суми > 4, за спаданням:");
        foreach (var r in query1)
            Console.WriteLine(r);

        //2. GroupBy + Where + OrderBy + Select
        var query2 = collection
            .GroupBy(s => s.Result)
            .Where(g => g.Count() > 1)
            .OrderBy(g => g.Key)
            .Select(g => new { Sum = g.Key, Count = g.Count() });

        Console.WriteLine("\n2. Групи, де однакова сума зустрічається більше 1 разу:");
        foreach (var group in query2)
            Console.WriteLine($"Сума: {group.Sum}, Кількість: {group.Count}");

        //3. Any + Where + FirstOrDefault + OrderBy
        bool hasZeroA = collection.Any(s => s.A == 0);
        if (hasZeroA)
        {
            var query3 = collection
                .Where(s => s.A > s.B)
                .OrderBy(s => s.A)
                .FirstOrDefault();

            Console.WriteLine("\n3. Перший елемент, де A > B (якщо є A == 0):");
            Console.WriteLine(query3);
        }

        //4. Where + Select + Skip + Take + Count
        var query4 = collection
            .Where(s => s.Result > 3)
            .Select(s => s.Result)
            .Skip(2)
            .Take(2)
            .Count(r => r % 2 == 0);

        Console.WriteLine($"\n4. Кількість парних сум після Skip(2), Take(2): {query4}");

        //5. Max + Where + Select + Reverse
        int maxSum = collection.Max(s => s.Result);

        var query5 = collection
            .Where(s => s.Result == maxSum)
            .Select(s => s.ToString())
            .Reverse();

        Console.WriteLine("\n5. Елементи з максимальною сумою:");
        foreach (var str in query5)
            Console.WriteLine(str);
    }
}
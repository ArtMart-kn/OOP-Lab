using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Sum : IComparable<Sum>
{
    public int A { get; set; }
    public int B { get; set; }

    public int Result => A + B;

    public Sum(int a, int b)
    {
        A = a;
        B = b;
    }

    public int CompareTo(Sum other)
    {
        if (other == null) return 1;
        return this.Result.CompareTo(other.Result);
    }

    public override string ToString()
    {
        return $"A: {A}, B: {B}, Сума: {Result}";
    }
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
        var collection = new CollectionType<Sum>();
        collection.Add(new Sum(3, 4));  
        collection.Add(new Sum(1, 2));  
        collection.Add(new Sum(5, 5));  
        Console.WriteLine("До сортування:");
        collection.Print();

        collection.Sort();

        Console.WriteLine("\nПісля сортування:");
        collection.Print();

        Console.WriteLine("\nЕлементи, де сума > 5:");
        foreach (var item in collection.Where(s => s.Result > 5))
            Console.WriteLine(item);
    }
}
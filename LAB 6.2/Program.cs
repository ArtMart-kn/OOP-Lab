using System;
using System.Collections;
using System.Collections.Generic;

public class CollectionType<T> : IEnumerable<T>
{
    private List<T> items;
    public CollectionType()
    {
        items = new List<T>();
    }

    public CollectionType(IEnumerable<T> collection)
    {
        items = new List<T>(collection);
    }

    public void Add(T item)
    {
        items.Add(item);
    }

    public bool Remove(T item)
    {
        return items.Remove(item);
    }

    public void RemoveAt(int index)
    {
        items.RemoveAt(index);
    }

    public bool Contains(T item)
    {
        return items.Contains(item);
    }

    public void Clear()
    {
        items.Clear();
    }

    public int Count => items.Count;

    public T this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    public static CollectionType<T> operator +(CollectionType<T> a, CollectionType<T> b)
    {
        return new CollectionType<T>(a.items.Concat(b.items));
    }

    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Print()
    {
        foreach (var item in items)
            Console.WriteLine(item);
    }
}
class Program
{
    static void Main()
    {
        var collection1 = new CollectionType<string>();
        collection1.Add("Apple");
        collection1.Add("Banana");

        var collection2 = new CollectionType<string>(new[] { "Orange", "Mango" });

        Console.WriteLine("Колекція 1:");
        collection1.Print();

        Console.WriteLine("\nКолекція 2:");
        collection2.Print();

        var merged = collection1 + collection2;

        Console.WriteLine("\nОб'єднана колекція:");
        merged.Print();

        Console.WriteLine($"\nЕлемент за індексом 1: {merged[1]}");

        Console.WriteLine($"Кількість: {merged.Count}");
    }
}
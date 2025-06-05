using System;
using System.Collections.Generic;
using System.Linq;

class CollectionType
{
    public string Name { get; set; }
    public int Value { get; set; }
    public override string ToString()
    {
        return $"Name: {Name}, Value: {Value}";
    }
}

class Program
{
    static void Main()
    {
        List<CollectionType>[] collections = new List<CollectionType>[]
        {
            new List<CollectionType>
            {
                new CollectionType { Name = "A1", Value = 10 },
                new CollectionType { Name = "A2", Value = 20 }
            },
            new List<CollectionType>
            {
                new CollectionType { Name = "B1", Value = 5 },
                new CollectionType { Name = "B2", Value = 15 },
                new CollectionType { Name = "B3", Value = 25 }
            },
            new List<CollectionType>
            {
                new CollectionType { Name = "C1", Value = 50 },
                new CollectionType { Name = "C2", Value = 30 }
            }
        };
        int countWithTwo = collections.Count(c => c.Count == 2);
        Console.WriteLine($"Кількість колекцій з 2 елементами: {countWithTwo}");
        List<CollectionType> minCollection = collections
            .OrderBy(c => c.Min(item => item.Value))
            .First();

        List<CollectionType> maxCollection = collections
            .OrderByDescending(c => c.Max(item => item.Value))
            .First();
        Console.WriteLine("\nКолекція з мінімальним значенням Value:");
        minCollection.ForEach(item => Console.WriteLine(item));
        Console.WriteLine("\nКолекція з максимальним значенням Value:");
        maxCollection.ForEach(item => Console.WriteLine(item));
    }
}
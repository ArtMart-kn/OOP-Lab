using System;
using System.Collections.Generic;

class KeyValueStorage<TKey, TValue>
{
    private Dictionary<TKey, TValue> storage = new Dictionary<TKey, TValue>();

    public void Add(TKey key, TValue value)
    {
        if (!storage.ContainsKey(key))
        {
            storage[key] = value;
            Console.WriteLine($"Додано: ({key}, {value})");
        }
        else
        {
            Console.WriteLine($"Ключ {key} вже існує.");
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        return storage.TryGetValue(key, out value);
    }

    public void Remove(TKey key)
    {
        if (storage.Remove(key))
        {
            Console.WriteLine($"Ключ {key} видалено.");
        }
        else
        {
            Console.WriteLine($"Ключ {key} не знайдено.");
        }
    }

    public void DisplayAll()
    {
        foreach (var pair in storage)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        KeyValueStorage<int, string> storage = new KeyValueStorage<int, string>();
        storage.Add(1, "One");
        storage.Add(2, "Two");
        storage.Add(3, "Three");
        storage.DisplayAll();
        if (storage.TryGetValue(2, out string value))
        {
            Console.WriteLine($"Значення ключа 2: {value}");
        }
        storage.Remove(2);
        storage.DisplayAll();
    }
}

using System;
using System.Collections.Generic;

interface IObserver
{
    void Update(string message);
}

class User : IObserver
{
    public string Name { get; }
    public User(string name)
    {
        Name = name;
    }
    public void Update(string message)
    {
        Console.WriteLine($"Користувач {Name} отримав повідомлення: {message}");
    }
}

class Server
{
    private List<IObserver> observers = new List<IObserver>();
    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
        Console.WriteLine($"Користувач підписаний.");
    }
    public void Unsubscribe(IObserver observer)
    {
        observers.Remove(observer);
        Console.WriteLine($"Користувача відписано.");
    }
    public void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Server server = new Server();
        User u1 = new User("Олег");
        User u2 = new User("Марія");
        User u3 = new User("Іван");
        server.Subscribe(u1);
        server.Subscribe(u2);
        server.Notify("Новина: Система оновлена!");
        server.Subscribe(u3);
        server.Notify("Нове повідомлення: Сервер буде перезапущено о 22:00.");
    }
}
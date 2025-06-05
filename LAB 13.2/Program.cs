using System;

public class Dispatcher
{
    private static Dispatcher _instance;
    private static readonly object _lock = new object();
    private Dispatcher()
    {
        Console.WriteLine("Dispatcher створено.");
    }
    public static Dispatcher Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Dispatcher();
                }
                return _instance;
            }
        }
    }
    public void HandleEvent(string message)
    {
        Console.WriteLine($"[Dispatcher] Обробка події: {message}");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Dispatcher d1 = Dispatcher.Instance;
        Dispatcher d2 = Dispatcher.Instance;
        Console.WriteLine($"Dispatcher однаковий: {object.ReferenceEquals(d1, d2)}");
        d1.HandleEvent("Натиснута кнопка");
        d2.HandleEvent("Завантаження завершено");
    }
}
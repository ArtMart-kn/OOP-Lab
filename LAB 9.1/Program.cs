using System;

// Завдання 1 – простий делегат без параметрів
public delegate void SimpleAction();
// Завдання 2 – делегат, який приймає значення x і повертає f(x)
public delegate double Function(double x);
// Завдання 3 – мультикаст-делегат
public delegate void LogAction();
// Завдання 4 – делегат на методи об'єкта, що приймає 2 параметри
public delegate void Operation(double a, double b);
// Завдання 5 – делегат для виводу результату
public delegate void Output(double result);

class Logger
{
    public static void Start() => Console.WriteLine("[ЛОГ]: Початок обчислення.");
    public static void Step() => Console.WriteLine("[ЛОГ]: Виконується обчислення...");
    public static void End() => Console.WriteLine("[ЛОГ]: Завершення обчислення.");
}

class MathFunctions
{
    // Завдання 2: Функція f(x)
    public static double ExampleFunction(double x) => x * x - 2; 
}

class BisectionSolver
{
    // Завдання 4: Метод пошуку
    public void Solve(double a, double b)
    {
        Console.WriteLine($"[Object Method] Пошук кореня на відрізку [{a}; {b}]...");
    }
    public void PrintResult(double a, double b)
    {
        Console.WriteLine("[Object Method] Завершено підготовку до розрахунків.");
    }
}

class RootFinder
{
    // Завдання 5: Пошук кореня рівняння з делегатами
    public void FindRoot(double a, double b, Function f, Output output, LogAction logs, double eps = 1e-6)
    {
        if (f(a) * f(b) >= 0)
        {
            Console.WriteLine("Неправильний проміжок: f(a) і f(b) мають однаковий знак.");
            return;
        }
        logs?.Invoke();
        double c = a;
        while ((b - a) >= eps)
        {
            c = (a + b) / 2;

            if (f(c) == 0.0)
                break;

            if (f(c) * f(a) < 0)
                b = c;
            else
                a = c;
        }
        output(c);
    }
}


class Program
{
    // Завдання 1: Метод без параметрів
    public static void ShowStartMessage()
    {
        Console.WriteLine("[Delegate] Запуск методу знаходження кореня рівняння.");
    }

    // Завдання 5: Метод для виводу результату
    public static void Print(double x)
    {
        Console.WriteLine($"[RESULT] Знайдений корінь ≈ {x:F6}");
    }

    static void Main(string[] args)
    {
        // Завдання 1
        SimpleAction simple = new SimpleAction(ShowStartMessage);
        simple();
        // Завдання 2
        Function f = new Function(MathFunctions.ExampleFunction);
        Console.WriteLine($"[Delegate] f(2) = {f(2)}");
        // Завдання 3: Мультикаст логування
        LogAction logs = Logger.Start;
        logs += Logger.Step;
        logs += Logger.End;
        // Завдання 4: Об’єктні методи
        BisectionSolver solver = new BisectionSolver();
        Operation op = new Operation(solver.Solve);
        op += solver.PrintResult;
        op(1, 2);
        // Завдання 5: Повноцінне обчислення
        RootFinder rootFinder = new RootFinder();
        Output output = new Output(Print);
        // Обчислення кореня функції x^2 - 2 на відрізку [1, 2]
        rootFinder.FindRoot(1, 2, f, output, logs);
    }
}
using System;

public delegate void RootFoundHandler(double root);

class BisectionSolverWithEvent
{
    public event RootFoundHandler RootFound;
    public void FindRoot(double a, double b, Func<double, double> f, double eps = 1e-6)
    {
        if (f(a) * f(b) >= 0)
        {
            Console.WriteLine("Невірний проміжок: f(a) і f(b) мають однаковий знак.");
            return;
        }
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
        RootFound?.Invoke(c);
    }
}

class TestMain
{
    public static void OnRootFound(double root)
    {
        Console.WriteLine($"[ПОДІЯ] Корінь знайдено: x ≈ {root:F6}");
    }

    public static double MyFunction(double x)
    {
        return x * x - 3;
    }

    static void Main()
    {
        BisectionSolverWithEvent solver = new BisectionSolverWithEvent();
        solver.RootFound += OnRootFound;
        solver.FindRoot(1, 2, MyFunction);
    }
}

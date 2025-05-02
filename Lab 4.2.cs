using System;

abstract class TVSeries
{
    protected double First;
    protected double CommonDiff;
    public TVSeries(double first, double commonV)
    {
        First = first;
        CommonDiff = commonV;
    }
    public abstract double GetNthTerm(int n);
    public abstract double GetSum(int n);
}

class ArithmeticProgression : TVSeries
{
    public ArithmeticProgression(double first, double commonDiff)
        : base(first, commonDiff) { }

    public override double GetNthTerm(int n)
    {
        return First + (n - 1) * CommonDiff;
    }
    public override double GetSum(int n)
    {
        return (n / 2.0) * (2 * First + (n - 1) * CommonDiff);
    }
}

class GeometricProgression : TVSeries
{
    public GeometricProgression(double first, double commonR)
        : base(first, commonR) { }

    public override double GetNthTerm(int n)
    {
        return First * Math.Pow(CommonDiff, n - 1);
    }
    public override double GetSum(int n)
    {
        if (CommonDiff == 1)
            return n * First;
        return First * (1 - Math.Pow(CommonDiff, n)) / (1 - CommonDiff);
    }
}

class Program
{
    static void Main()
    {
        Random random = new Random();
        int n = 10;
        TVSeries[] series = new TVSeries[n];
        for (int i = 0; i < n; i++)
        {
            double first = random.Next(1, 10);
            double commonV = random.Next(1, 5);
            if (i % 2 == 0)
                series[i] = new GeometricProgression(first, commonV);
            else
                series[i] = new ArithmeticProgression(first, commonV);
        }
        int bestIndex = 0;
        double maxNthTerm = series[0].GetNthTerm(10);
        for (int i = 1; i < n; i++)
        {
            double currentNthTerm = series[i].GetNthTerm(10);
            if (currentNthTerm > maxNthTerm)
            {
                maxNthTerm = currentNthTerm;
                bestIndex = i;
            }
        }
        double sumM = series[bestIndex].GetSum(5);
        Console.WriteLine($"Максимальний 10-й член: {maxNthTerm}");
        Console.WriteLine($"Сума перших 5 членів прогресії з найбільшим 10-м членом: {sumM}");
    }
}

using System;

interface IPrintable
{
    void Print();
}

class Report : IPrintable
{
    public void Print()
    {
        Console.WriteLine("Друк звіту");
    }
}

class Program
{
    static void Main()
    {
        IPrintable report = new Report();
        report.Print();
    }
}

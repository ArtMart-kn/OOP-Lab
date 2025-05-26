using System;

interface IA
{
    void MethodA();
}

interface IB : IA
{
    void MethodB();
}

class MyClass : IB
{
    public void MethodA()
    {
        Console.WriteLine("Виклик методу MethodA");
    }

    public void MethodB()
    {
        Console.WriteLine("Виклик методу MethodB");
    }
}

class Program
{
    static void Main()
    {
        MyClass obj = new MyClass();
        obj.MethodA();  
        obj.MethodB();  
    }
}

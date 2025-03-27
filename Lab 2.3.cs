using System;

class GlobalExample
{
    public void ShowMessage()
    {
        Console.WriteLine("Це повідомлення з глобального класу");
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        GlobalExample example = new GlobalExample();
        example.ShowMessage();
    }
}
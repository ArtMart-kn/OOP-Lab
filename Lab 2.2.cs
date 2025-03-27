using System;

struct Rectangle
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double CalculateArea()
    {
        return Width * Height;
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
         Console.Write("Введіть ширину прямокутника: ");
        double width = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть висоту прямокутника: ");
        double height = Convert.ToDouble(Console.ReadLine());
        Rectangle rect = new Rectangle(width, height);
        Console.WriteLine($"Площа прямокутника: {rect.CalculateArea()}");
    }
}
using System;

abstract class Птах
{
    public abstract void Fly();
    public abstract void Sing();
    public abstract void LayEggs();
}

class Зозуля : Птах
{
    public override void Fly()
    {
        Console.WriteLine("Зозуля літає високо в небі.");
    }
    public override void Sing()
    {
        Console.WriteLine("Ку-ку! Ку-ку!");
    }
    public override void LayEggs()
    {
        Console.WriteLine("Зозуля підкладає яйця в чужі гнізда.");
    }
}

class Квочка : Птах
{
    public override void Fly()
    {
        Console.WriteLine("Квочка літає погано і на короткі відстані.");
    }
    public override void Sing()
    {
        Console.WriteLine("Квочка кудкудакає.");
    }
    public override void LayEggs()
    {
        Console.WriteLine("Квочка несе яйця в своєму гнізді.");
    }
    public void IncubateChicks()
    {
        Console.WriteLine("Квочка висиджує пташенят.");
    }
}

class Program
{
    static void Main()
    {
        Птах cuckoo = new Зозуля();
        cuckoo.Fly();
        cuckoo.Sing();
        cuckoo.LayEggs();
        Console.WriteLine();
        Квочка hen = new Квочка();
        hen.Fly();
        hen.Sing();
        hen.LayEggs();
        hen.IncubateChicks();
    }
}

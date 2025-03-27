using System;

class Book
{
    public string Title { get; }
    public string Author { get; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть назву книги: ");
        string title = Console.ReadLine();
        Console.Write("Введіть автора книги: ");
        string author = Console.ReadLine();
        Book book = new Book(title, author);
        Console.WriteLine($"Книга: {book.Title}, Автор: {book.Author}");
    }
}
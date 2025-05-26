using System;
using System.Collections.Generic;

class Student : IComparable<Student>
{
    public string Name { get; set; }
    public int Grade { get; set; }

    public Student(string name, int grade)
    {
        Name = name;
        Grade = grade;
    }

    public int CompareTo(Student other)
    {
        
        return this.Grade.CompareTo(other.Grade);
    }

    public override string ToString()
    {
        return $"{Name} - {Grade}";
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("Олег", 12),
            new Student("Ірина", 8),
            new Student("Андрій", 7),
            new Student("Марія", 9)
        };
        students.Sort(); 
        Console.WriteLine("Список студентів після сортування:");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }
}

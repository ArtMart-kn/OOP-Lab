using System;
using System.Collections.Generic;

public class University
{
    public string Name { get; set; }
    public List<Faculty> Faculties { get; set; } = new List<Faculty>();
}

public class Faculty
{
    public string Name { get; set; }
    public int NumberOfTeachers { get; set; }
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
}

public class Teacher
{
    public string FullName { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }

    public Teacher(string fullName, string position, decimal salary)
    {
        if (salary < 0)
        {
            throw new OkladException(salary);
        }

        FullName = fullName;
        Position = position;
        Salary = salary;
    }

    public virtual void CalculateSalary()
    {
        try
        {
            Console.WriteLine($"Зарплата викладача {FullName}: {Salary} грн");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при розрахунку зарплати: {ex.Message}");
        }
    }
}

public class RegularTeacher : Teacher
{
    public decimal Bonus { get; set; }

    public RegularTeacher(string fullName, string position, decimal salary, decimal bonus)
        : base(fullName, position, salary)
    {
        Bonus = bonus;
    }

    public override void CalculateSalary()
    {
        try
        {
            if (Bonus < 0)
                throw new PremiyaException($"Премія не може бути від’ємною: {Bonus}");

            decimal total = Salary + Bonus;
            Console.WriteLine($"Зарплата штатного викладача {FullName} з премією: {total} грн");
        }
        catch (PremiyaException ex)
        {
            Console.WriteLine($"[PremiyaException] {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при розрахунку зарплати: {ex.Message}");
        }
    }
}

public class PartTimeTeacher : Teacher
{
    public PartTimeTeacher(string fullName, string position, decimal salary)
        : base(fullName, position, salary) { }

    public override void CalculateSalary()
    {
        try
        {
            Console.WriteLine($"Зарплата викладача-сумісника {FullName}: {Salary} грн");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при розрахунку зарплати: {ex.Message}");
        }
    }
}
public class PremiyaException : Exception
{
    public PremiyaException(string message) : base(message) { }
}

public class OkladException : Exception
{
    public OkladException(decimal oklad)
        : base($"Неможливо створити співробітника – вказано негативний оклад: {oklad}") { }
}

class Program
{
    static void Main()
    {
        try
        {
            Teacher t1 = new Teacher("Іван Петренко", "Доцент", -5000);
        }
        catch (OkladException ex)
        {
            Console.WriteLine($"[OkladException] {ex.Message}");
        }
        Console.WriteLine();
        RegularTeacher rt = new RegularTeacher("Марія Іваненко", "Професор", 10000, -2000);
        rt.CalculateSalary();
        Console.WriteLine();
        PartTimeTeacher pt = new PartTimeTeacher("Олег Сидоренко", "Асистент", 3000);
        pt.CalculateSalary();
        Console.WriteLine();
        RegularTeacher rt2 = new RegularTeacher("Анна Коваль", "Старший викладач", 9000, 1500);
        rt2.CalculateSalary();
    }
}
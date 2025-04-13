using System;
using System.Collections.Generic;
class Vehicle
{
 public string Name { get; set; }
 public virtual void Describe()
 {
 Console.WriteLine("Description");
 }
}
class Car : Vehicle
{
 public override void Describe()
 {
 Console.WriteLine("Car has 4 wheels");
 }
}
class Bike : Vehicle
{
 public override void Describe()
 {
 Console.WriteLine("Bike has 2 wheels");
 }
}
class Program
{
 static void Main()
 {
 List<Vehicle> vehicles = new List<Vehicle>
 {
 new Car { Name = "Car" },
 new Bike { Name = "Bike" }
 };
 foreach (var vehicle in vehicles)
 {
 Console.Write($"{vehicle.Name} describtion: ");
 vehicle.Describe();
 }
 }
}

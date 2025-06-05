using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class OrderItem
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public OrderItem() { }
    public OrderItem(string productName, int quantity)
    {
        ProductName = productName;
        Quantity = quantity;
    }
}

[Serializable]
public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    [XmlArray("Items")]
    [XmlArrayItem("OrderItem")]
    public List<OrderItem> Items { get; set; }
    public Order()
    {
        Items = new List<OrderItem>();
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Створюємо об'єкт замовлення з даними
        Order order = new Order
        {
            OrderId = 1001,
            OrderDate = DateTime.Now,
            Items = new List<OrderItem>
            {
                new OrderItem("Хліб", 2),
                new OrderItem("Молоко", 1),
                new OrderItem("Сир", 3)
            }
        };
        // Серіалізація у файл order.xml
        XmlSerializer serializer = new XmlSerializer(typeof(Order));
        using (FileStream fs = new FileStream("order.xml", FileMode.Create))
        {
            serializer.Serialize(fs, order);
        }
        Console.WriteLine("Замовлення успішно серіалізовано у файл order.xml");
    }
}
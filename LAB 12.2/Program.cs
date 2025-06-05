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
        string filePath = "order.xml";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл order.xml не знайдено.");
            return;
        }
        XmlSerializer serializer = new XmlSerializer(typeof(Order));
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            Order order = (Order)serializer.Deserialize(fs);
            Console.WriteLine($"Ідентифікатор замовлення: {order.OrderId}");
            Console.WriteLine($"Кількість товарів: {order.Items.Count}");
        }
    }
}
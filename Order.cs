using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
namespace PizzaMaker
{
    public class Size
    {
        public String Name { get; set; }
        public double Price { get; set; }
        public Size(String name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
    public class Topping
    {
        public String Name { get; set; }
        public double Price { get; set; }
        public Topping(String name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
    public class Pizza
    {
        public String Name { get; set; }
        public double Price { get; set; }        
        public Pizza(String name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
    public class Item 
    {
        public Pizza Pizza { get; set; }
        public List<Topping> Topping { get; set; }
        public Size Size { get; set; }
        public String Name { get; set; }
        public Item(String name, Pizza pizza, List<Topping> topping, Size size)
        {
            this.Name = name;
            this.Pizza = new(pizza.Name, pizza.Price);
            this.Size = new(size.Name, size.Price);
            this.Topping = topping;
        }
        public double GetPrice(Pizza pizza, List<Topping> topping, Size size)
        {
            return (pizza.Price + topping.Sum(t => t.Price)) * size.Price;
        }
    }
    public class Order
    {
        public List<Item> Orders { get; set; } = new();
        public void SaveOrders()
        {     
            if(!File.Exists("Orders.json"))
                File.Create("Orders.json").Close();  
            File.WriteAllText("Orders.json", JsonSerializer.Serialize(Orders));
        }
        public void AddOrder(Item order)
        {
            this.Orders.Add(order);
            SaveOrders();
        }
        public Item ReadOrder(String orderName)
        {   
            ReadOrders();
            return Orders.Find(order => order.Name == orderName);
        }
        public void ReadOrders()
        {
            if(!File.Exists("Orders.json"))
                File.Create("Orders.json").Close();  
            try
            {
              Orders = JsonSerializer.Deserialize<List<Item>>(File.ReadAllText("Orders.json"));
            }
            catch
            {
                Console.WriteLine("No orders was saved");
            }
        }
    }
}
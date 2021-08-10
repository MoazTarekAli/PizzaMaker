using System;
using System.Collections.Generic;

namespace PizzaMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new();
            menu.ReadMenu();
            Order pizza = new();
            pizza.ReadOrders();
            string action = "";
            while(action != "0")
            {
                action = "";
                Console.WriteLine("1-Make order");
                Console.WriteLine("2-View orders");
                Console.WriteLine("3-View order");
                Console.WriteLine("press 0 to exit");
                action = Console.ReadLine();
                int index;
                switch(action)
                {
                    case "1":
                    index = 1;
                    menu.Pizzas.ForEach(pizza =>
                    {
                        Console.Write($"{index.ToString()}-{pizza.Name} ");
                        index++;
                    });
                    action = Console.ReadLine();
                    Pizza orderedPizza = menu.Pizzas[Int16.Parse(action) - 1];
                    index = 1;
                    menu.Sizes.ForEach(size =>
                    {
                        Console.Write($"{index.ToString()}-{size.Name} ");
                        index++;
                    });
                    action = Console.ReadLine();
                    Size orderedSize = menu.Sizes[Int16.Parse(action) - 1];
                    index = 1;
                    menu.Toppings.ForEach(topping =>
                    {
                        Console.Write($"{index.ToString()}-{topping.Name} ");
                        index++;
                    });
                    action = Console.ReadLine();
                    List<Topping> orderedTopping = new();
                    orderedTopping.Add(menu.Toppings[Int16.Parse(action) - 1]);
                    Console.Write("please enter order name:");
                    action = Console.ReadLine();
                    Item order = new(action, orderedPizza, orderedTopping, orderedSize);
                    pizza.AddOrder(order);
                    break;
                    case "2":
                    index = 1;
                    pizza.Orders.ForEach(order =>
                    {
                        Console.WriteLine($"{index.ToString()}-Order name:{order.Name} is a {order.Size.Name} size {order.Pizza.Name} pizza with {order.Topping[0].Name}");
                        index++;
                    });
                    break;
                    case "3":
                    Console.Write("please enter order name:");
                    action = Console.ReadLine();
                    Item requiredOrder = pizza.ReadOrder(action);
                    if(requiredOrder is null)
                        Console.WriteLine("This order doesn't exist");
                    else
                        Console.WriteLine($"Order name:{requiredOrder.Name} is a {requiredOrder.Size.Name} size {requiredOrder.Pizza.Name} pizza with {requiredOrder.Topping[0].Name}");
                    break;
                }
            }
        }
    }
}

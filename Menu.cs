using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace PizzaMaker
{
    public class Menu
    {
        public List<Pizza> Pizzas { get; set; } = new();
        public List<Topping> Toppings { get; set; } = new();
        public List<Size> Sizes { get; set; } = new();
        public void Default()
        {
            Pizzas.Add(new("Chicken", 30));
            Pizzas.Add(new("Cheese", 20));
            Pizzas.Add(new("Sausage", 40));
            Toppings.Add(new("Onion", 5));
            Toppings.Add(new("Olive", 10));
            Toppings.Add(new("Mushrom", 15));
            Sizes.Add(new("Small", 1));
            Sizes.Add(new("Medium", 2));
            Sizes.Add(new("Large", 3));
        }
        public void SaveMenu()
        {
            if(!File.Exists("Menu.json"))
                File.Create("Menu.json").Close();  
            File.WriteAllText("Menu.json", JsonSerializer.Serialize(this));
        }
        public void ReadMenu()
        {
            try
            {
                Menu temp = JsonSerializer.Deserialize<Menu>(File.ReadAllText("Menu.json"));
                this.Pizzas = temp.Pizzas;
                this.Sizes = temp.Sizes;
                this.Toppings = temp.Toppings;
            }
            catch
            {
                Default();
            }
            SaveMenu();
        }
    }
}
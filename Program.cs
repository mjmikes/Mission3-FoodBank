// See https://aka.ms/new-console-template for more information

using System;
using Mission3_FoodBank;
using static Mission3_FoodBank.FoodItem;

internal class Program
{
    public List<string> inventory = new List<string>();
    public static void Main()
    {
        bool exit = false;
        
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Food Bank Inventory System!");
            Console.WriteLine("How can we help you?");
            Console.WriteLine("1. Add an item");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Delete an item");
            Console.WriteLine("4. Exit Program");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Mission3_FoodBank.FoodItem add = new Mission3_FoodBank.FoodItem();
                    add.addFoodItem();
                    break;
                    
                case ConsoleKey.D3:
                    Mission3_FoodBank.FoodItem delete = new Mission3_FoodBank.FoodItem();
                    delete.deleteFoodItem();
                    exit = true;
                    break;
                
                case ConsoleKey.D2:
                    Mission3_FoodBank.FoodItem view = new Mission3_FoodBank.FoodItem();
                    view.showInventory();
                    exit = true;
                    break;
                
                case ConsoleKey.D4:
                    Console.WriteLine("Closing program...");
                    System.Threading.Thread.Sleep(1000);  // Pause for 1 second
                    Console.Clear();
                    exit = true;
                    break;
            }
        }
    }
}
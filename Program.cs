﻿// See https://aka.ms/new-console-template for more information

using System;
using Mission3_FoodBank;
using static Mission3_FoodBank.FoodItem;

internal class Program
{
    public static void Main()
    {
        bool exit = false; // Iniitalize boolean for while loop
        
        while (!exit)
        {
            // Dsiplay Menu
            Console.Clear();
            Console.WriteLine("Welcome to the Food Bank Inventory System!");
            Console.WriteLine("How can we help you?");
            Console.WriteLine("1. Add an item");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Delete an item");
            Console.WriteLine("4. Exit Program");
            
            // logic to call the correct method based off user input (numberpad not allowed, must use digits near top of keyboard)
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    addFoodItem();
                    break;
                    
                case ConsoleKey.D3:
                    deleteFoodItem();
                    break;
                
                case ConsoleKey.D2:
                    showInventory();
                    anotherItem();
                    break;
                
                case ConsoleKey.D4:
                    Console.WriteLine("Closing program...");
                    System.Threading.Thread.Sleep(1000);  // Pause for 1 second
                    Console.Clear();
                    exit = true;
                    break;
                
                //Error handling for invalid user input
                default:
                    Console.WriteLine("\n Invalid input! Please enter a number between 1 and 4.");
                    System.Threading.Thread.Sleep(2000);  // Pause to let the user read the message
                    break;
            }
        }
    }
}
namespace Mission3_FoodBank;

public class FoodItem()
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }

    public void StoreItem(string name, string category, int quantity, DateTime date)
    {
        Console.WriteLine($"Item Added: {name} - {category} - {quantity} - {date}");
        Console.WriteLine($"Would you like to add another item?");
        Console.WriteLine("1. Add item");
        Console.WriteLine("2. Return to Main Menu");

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                Mission3_FoodBank.FoodItem add = new Mission3_FoodBank.FoodItem();
                add.addFoodItem();
                break;
            
            case ConsoleKey.D2:
                Console.WriteLine("Returning to Main Menu... ");
                System.Threading.Thread.Sleep(1000);  // Pause for 1 second
                Console.Clear();
                break;
        }
        
        
        
    }
    
    public void addFoodItem()
    {
        Console.WriteLine($"Loading...");
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("Please enter the name of the food item:");
        string name = Console.ReadLine();
        Console.WriteLine("Please enter the category of the food item:");
        string category = Console.ReadLine();
        Console.WriteLine("Please enter the quantity of the food item in units:");
        int quantity = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the expiration date in mm/dd/yyyy format:");
        string expirationDate = Console.ReadLine();
        Console.WriteLine($"Adding item...");
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
        Mission3_FoodBank.FoodItem storeFood = new Mission3_FoodBank.FoodItem();
        storeFood.StoreItem(name, category, quantity, DateTime.Parse(expirationDate));
    }
    
    public void deleteFoodItem()
    {
        Console.WriteLine("Delete Food Item Selected");
    }

    public void showInventory()
    {
        Console.WriteLine("Show Inventory Selected");
    }
}
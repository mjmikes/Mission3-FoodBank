namespace Mission3_FoodBank;

public class FoodItem
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    
    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        Date = expirationDate;
    }

    public static List<FoodItem> inventory = new List<FoodItem>();
    

    public static void StoreItem(string name, string category, int quantity, DateTime date)
    {
        FoodItem newFood = new FoodItem(name, category, quantity, date);
        inventory.Add(newFood);
        
        Console.WriteLine($"Item Added: {name} - {category} - {quantity} - {date}");
        anotherItem();

    }
    public static void addFoodItem()
    {
        Console.WriteLine($"Loading Pantry...");
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
        StoreItem(name, category, quantity, DateTime.Parse(expirationDate));
    }

    public static void anotherItem()
    {
        Console.WriteLine($"Would you like to add an additional item?");
        Console.WriteLine("1. Add item");
        Console.WriteLine("2. Return to Main Menu");

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                addFoodItem();
                break;
            
            case ConsoleKey.D2:
                Console.WriteLine("Returning to Main Menu... ");
                System.Threading.Thread.Sleep(1000);  // Pause for 1 second
                Console.Clear();
                break;
        }
    }
    public static void deleteFoodItem()
    {
        {
            string stay = "";

            while (stay == "")
            {
                showInventory();
                if (inventory.Count == 0)
                {
                    Console.WriteLine("Looks like theres no food! ");
                    stay = "beast";
                    anotherItem();
                }
                else
                {
                        Console.WriteLine("Which item would you like to delete?");
                        int itemNumber = int.Parse(Console.ReadLine());
                        string saveName = inventory[itemNumber - 1].Name;
                        inventory.RemoveAt(itemNumber - 1);
                        showInventory();
                        Console.WriteLine($"Item Removed: {saveName}");
                        Console.WriteLine("1. Delete Another Item");
                        Console.WriteLine("2. Return to Main Menu");


                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                                break;

                            case ConsoleKey.D2:
                                stay = Console.ReadLine();
                                break;
                        }
                }
            
                
            }
        }
       
        
        
    }

    public static void showInventory()
    {
        Console.Clear();
        Console.WriteLine($"Loading Pantry...");
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("--INVENTORY--");
        Console.WriteLine($"   NAME       CATEGORY       QUANTITY       EXPIRATION DATE");
        if (inventory.Count == 0)
            Console.WriteLine("No inventory available.");
        
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i].Name}     {inventory[i].Category}     {inventory[i].Quantity}     {inventory[i].Date}");
        }
        Console.WriteLine("\n\n\n");
    }
}
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
        Console.WriteLine("Loading Pantry...");
        System.Threading.Thread.Sleep(1000);
        Console.Clear();

        // Get Item Name (Non-Empty)
        string name;
        do
        {
            Console.WriteLine("Please enter the name of the food item:");
            name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                Console.WriteLine("❌ Name cannot be empty. Please try again.\n");
        } while (string.IsNullOrWhiteSpace(name));

        // Get Category (Non-Empty)
        string category;
        do
        {
            Console.WriteLine("Please enter the category of the food item:");
            category = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(category))
                Console.WriteLine("❌ Category cannot be empty. Please try again.\n");
        } while (string.IsNullOrWhiteSpace(category));

        // Get Quantity (Must be a positive integer)
        int quantity;
        do
        {
            Console.WriteLine("Please enter the quantity of the food item in units:");
            if (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
            {
                Console.WriteLine("❌ Invalid input. Please enter a positive number.\n");
            }
        } while (quantity <= 0);

        // Get Expiration Date (Must be valid date)
        DateTime expirationDate;
        do
        {
            Console.WriteLine("Please enter the expiration date in MM/dd/yyyy format:");
            if (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out expirationDate))
            {
                Console.WriteLine("❌ Invalid date format. Please enter the date in MM/dd/yyyy format.\n");
            }
        } while (expirationDate == default);

        // Confirm Addition
        Console.WriteLine("Adding item...");
        System.Threading.Thread.Sleep(1000);
        Console.Clear();

        // Store the item
        StoreItem(name, category, quantity, expirationDate);
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
                        Console.WriteLine("Which item would you like to delete? Press 'Enter' to confirm.");
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
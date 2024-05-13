namespace HabitLogger;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        
        // Start up message
        Console.WriteLine("-------------------------");
        Console.WriteLine("Welcome to Habit Logger!");
        Console.WriteLine("-------------------------");
        Console.WriteLine();
        
        // Call the menu
        Menu menu = new Menu();
        menu.ShowMenu();
    }
}
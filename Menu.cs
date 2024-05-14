namespace HabitLogger;

public class Menu
{
    public void ShowMenu()
    {
        bool isOn = true;
        do
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("Type 0 to Close Application");
            Console.WriteLine("Type 1 to Show all habits");
            Console.WriteLine("Type 2 to Add a new habit");
            Console.WriteLine("Type 3 to Delete a habit");
            Console.WriteLine("Type 4 to Update a habit");
            
            Console.Write("Your option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    isOn = false;
                    break;
                case "1":
                    // Show all habits
                    Engine.DisplayAll();
                    break;
                case "2":
                    // Add a new habit
                    break;
                case "3":
                    // Delete a habit
                    break;
                case "4":
                    // Update a habit
                    break;
                default:
                    Console.WriteLine("Invalid Command. Please type a number from 0 to 4");
                    break;
            }
        } while (isOn);
    }
}
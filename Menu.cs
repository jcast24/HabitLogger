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
            Console.WriteLine("Type 1 to View All Records");
            Console.WriteLine("Type 2 to Insert Record");
            Console.WriteLine("Type 3 to Delete a Record");
            Console.WriteLine("Type 4 to Update Record");
            
            Console.Write("Your option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    isOn = false;
                    break;
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Invalid Command. Please type a number from 0 to 4");
                    break;
            }
            

        } while (isOn);
    }
}
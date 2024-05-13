namespace HabitLogger;

public class Menu
{
    public void ShowMenu()
    {
        bool isOn = true;
        do
        {
            Console.Write("What would you like to do?");
            Console.WriteLine("Type 0 to Close Application");
            Console.WriteLine("Type 1 to View All Records");
            Console.WriteLine("Type 2 to Insert Record");
            Console.WriteLine("Type 3 to Delete a Record");
            Console.WriteLine("Type 4 to Update Record");
            
            var option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    isOn = false;
                    break;
            }
            

        } while (isOn);
    }
}
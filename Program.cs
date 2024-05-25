using Microsoft.Data.Sqlite;

namespace HabitLogger;

class Program
{
    private static string connectionString = @"Data Source=habit.db";

    public static string DbConnect => connectionString;


    static void Main(string[] args)
    {
        // establish connection with db 
        using (var connection = new SqliteConnection(connectionString))
        {
            // open the connection
            connection.Open();

            // tell the connection to create a command
            var tableCmd = connection.CreateCommand();

            // create the table if it doesn't exist
            tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS habit (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Date TEXT, Hours INTEGER)";

            // ask the database not to return any values
            tableCmd.ExecuteNonQuery();

            // close the connection with database
            connection.Close();
        }

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
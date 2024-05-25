using System.Data;
using System.Globalization;
using Microsoft.Data.Sqlite;

namespace HabitLogger;

public class Engine
{
    // private static string connectionString = @"Data source=habit.db";
    public static void DisplayAll()
    {
        using (var connection = new SqliteConnection(Program.DbConnect))
        {
            connection.Open();

            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = @"SELECT * FROM habit";

            List<Habit> tableData = [];

            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tableData.Add(new Habit
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Date = DateTime.ParseExact(reader.GetString(2), "dd-MM-yyyy", new CultureInfo("en-US")),
                        NumberOfHours = reader.GetInt32(3)
                    });
                }
            }
            else
            {
                Console.WriteLine("No rows found");
            }
            
            connection.Close();
            
            Console.WriteLine();
            foreach (var hb in tableData)
            {
                Console.WriteLine($"{hb.Id} {hb.Name} {hb.Date} {hb.NumberOfHours}");
            }
            Console.WriteLine();
        }
    }
    public static void Insert()
    {
        Console.WriteLine("Enter name of habit: ");
        string name = Console.ReadLine();
            
        Console.WriteLine("Enter date in format dd-MM-yyyy: ");
        string date = Console.ReadLine();
        
        Console.WriteLine("Enter the number of hours: ");
        int numOfHours = int.Parse(Console.ReadLine());
            
        using (var connection = new SqliteConnection(Program.DbConnect))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = $"INSERT INTO Habit(Name, Date, Hours) VALUES ('{name}', '{date}' ,'{numOfHours}')";
            tableCmd.ExecuteNonQuery();
            
            connection.Close();
        }
    }
}
using System.Data;
using System.Globalization;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace HabitLogger;

public class Engine
{
    // private static string connectionString = @"Data source=habit.db";

    public static string GetDate()
    {
        Console.WriteLine("Please insert the date: (Format dd-mm-yyyy).");
        string dateInput = Console.ReadLine();

        while (!DateTime.TryParseExact(dateInput, "dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
        {
            Console.WriteLine("Invalid date. Format: dd-MM-yyyy. Try again: ");
            dateInput = Console.ReadLine();
        }
        return dateInput;
    }

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
        // TODO: Add input validation
        Console.WriteLine("Enter name of habit: ");
        string name = Console.ReadLine();

        // Console.WriteLine("Enter date in format dd-MM-yyyy: ");
        // string date = Console.ReadLine();
        string date = GetDate();

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

    public static void Delete()
    {
        Console.Clear();

        DisplayAll();

        Console.WriteLine("Please enter an ID to delete: ");

        int getRecordID = int.Parse(Console.ReadLine());

        using (var connection = new SqliteConnection(Program.DbConnect))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = $"DELETE from habit WHERE Id = '{getRecordID}'";

            int rowCount = tableCmd.ExecuteNonQuery();

            if (rowCount == 0)
            {
                Console.WriteLine($"Record with Id {getRecordID} doesn't exist");
                Delete();
            }
        }
        Console.WriteLine($"Record with Id {getRecordID} was deleted.");
    }

    public static void Update()
    {
        Console.Clear();

        DisplayAll();

        Console.WriteLine("Please enter the ID to update a habit: ");

        int getRecordID = int.Parse(Console.ReadLine());

        using (var connection = new SqliteConnection(Program.DbConnect))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = $"SELECT EXISTS(SELECT 1 FROM habit WHERE id={getRecordID})";

            int check = Convert.ToInt32(tableCmd.ExecuteScalar());

            if (check == 0)
            {
                Console.WriteLine("Record does not exist");
                connection.Close();
                Update();
            }

            Console.WriteLine("Enter name of new habit: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter date in format dd-MM-yyyy: ");
            string date = Console.ReadLine();

            Console.WriteLine("Enter the number of hours: ");
            int numOfHours = int.Parse(Console.ReadLine());

            var newCommand = connection.CreateCommand();
            newCommand.CommandText = $"UPDATE habit SET Name = '{name}', Date = '{date}', Hours = '{numOfHours}' WHERE Id = '{getRecordID}' ";

            newCommand.ExecuteNonQuery();

            connection.Close();

        }
    }
}
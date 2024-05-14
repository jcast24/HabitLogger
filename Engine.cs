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
        }
    }
}
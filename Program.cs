﻿using Microsoft.Data.Sqlite;

namespace HabitLogger;

class Program
{
    private static string connectionString = @"Data Source=habit.db";
    static void Main(string[] args)
    {
        // Console.Clear();
        //
        // // Start up message
        // Console.WriteLine("-------------------------");
        // Console.WriteLine("Welcome to Habit Logger!");
        // Console.WriteLine("-------------------------");
        // Console.WriteLine();
        //
        // // Call the menu
        // Menu menu = new Menu();
        // menu.ShowMenu();
        using (var connection = new SqliteConnection(connectionString))
        {
            // open the connection
            connection.Open();
            
            // tell the connection to create a command
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = "";

            // ask the database not to return any values
            tableCmd.ExecuteNonQuery();
            
            // close the connection with database
            connection.Close();

        }
            

    }
}
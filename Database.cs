using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Coursework
{
    internal static class Database
    {
        public static string dbPath = "database.db";

        // Static constructor to create the database, and initialise a table for user accounts.
        static Database()
        {
            // Creates the table, the file is automatically created if it does not exist.
            using (var conn = new SqliteConnection($"Data Source={dbPath}"))
            {
                conn.Open();

                var command = conn.CreateCommand();
                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS Users (
                            UserID INTEGER PRIMARY KEY,
                            Username TEXT NOT NULL,
                            zValue TEXT NOT NULL,
                            yShift TEXT NOT NULL)";

                command.ExecuteNonQuery();
            }
        }

        // METHODS //

        // Add an account to the database
        internal static void addAccount(string username, string zValue, string yShift)
        {
            using (var conn = new SqliteConnection($"Data Source={dbPath}"))
            {
                conn.Open();

                // Initialise the command
                var command = conn.CreateCommand();
                command.CommandText =
                    @"INSERT INTO Users
                        VALUES (NULL,$user,$zVal,$ySh)";

                // Add parameters separately (to prevent SQL injection)
                command.Parameters.AddWithValue("$user", username);
                command.Parameters.AddWithValue("$zVal", zValue);
                command.Parameters.AddWithValue("$ySh", yShift);

                // Run the command
                command.ExecuteNonQuery();
            }
        }
    }
}

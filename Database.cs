using System;
using System.Collections.Generic;
using System.Data;
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

        /// <summary>
        /// Creates a new account and inserts it into the database.
        /// </summary>
        /// <param name="username">The username of the account</param>
        /// <param name="zValue">The "Z" prime obtained by X * Y</param>
        /// <param name="yShift">The circular-shifted Y' value.</param>
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

        /// <summary>
        /// A function to get a User object from a username, only if it exists in the database.
        /// </summary>
        /// <param name="username">The username to find the account of</param>
        /// <returns>A "User" object representing the account if it exists, or null if it does not.</returns>
        /// <exception cref="Exception">The SQL query returned a result but the account was not found.</exception>
        internal static User getUser(string username)
        {
            using (var conn = new SqliteConnection($"Data Source={dbPath}"))
            {
                conn.Open();

                //Initialise the query
                var command = conn.CreateCommand();
                command.CommandText =
                    @"SELECT * FROM Users WHERE Username == '$user'";

                // Add the parameter
                command.Parameters.AddWithValue("$user", username);

                using (var reader = command.ExecuteReader())
                {
                    // There is no relevant user, return null.
                    if (!reader.HasRows)
                        return null;
                    //Find the user
                    while (reader.Read())
                    {
                        string uName = reader.GetValue(1).ToString();
                        string zValue = reader.GetValue(2).ToString();
                        string yShift = reader.GetValue(3).ToString();

                        // Set up an object and return it
                        User result = new User(uName, zValue, yShift);
                        return result;

                    }

                    throw new Exception("Expected account, got none.");
                }
            }
        }
    }
}

using System;
using Microsoft.Data.Sqlite;

namespace Coursework
{
    internal static class Database
    {
        // We can assume the Storage folder already exists, due to being instantiated in Program.cs
        public static string dbPath = @"Storage\database.db";

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
                            yShift TEXT NOT NULL,
                            Salt TEXT NOT NULL)";

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
        /// <param name="salt">The salt to go along with the password</param>
        internal static void addAccount(string username, string zValue, string yShift, string salt)
        {
            using (var conn = new SqliteConnection($"Data Source={dbPath}"))
            {
                conn.Open();

                // Initialise the command
                var command = conn.CreateCommand();
                command.CommandText =
                    @"INSERT INTO Users
                        VALUES (NULL,$user,$zVal,$ySh,$sal)";

                // Add parameters separately (to prevent SQL injection)
                command.Parameters.AddWithValue("$user", username);
                command.Parameters.AddWithValue("$zVal", zValue);
                command.Parameters.AddWithValue("$ySh", yShift);
                command.Parameters.AddWithValue("$sal", salt);

                // Run the command
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates an existing account with new values.
        /// </summary>
        /// <param name="username">The username of the account</param>
        /// <param name="zValue">The "Z" prime obtained by X * Y</param>
        /// <param name="yShift">The circular-shifted Y' value.</param>
        /// <param name="salt">The salt to go along with the password</param>
        internal static void updateAccount(string username, string zValue, string yShift, string salt)
        {
            using (var conn = new SqliteConnection($"Data Source={dbPath}"))
            {
                conn.Open();

                // Initialise the command
                var command = conn.CreateCommand();
                command.CommandText =
                    @"UPDATE Users
                        SET zValue = $zVal, yShift = $ySh, Salt = $sal
                        WHERE Username = $user";

                // Add the parameters
                command.Parameters.AddWithValue("$user", username);
                command.Parameters.AddWithValue("$zVal", zValue);
                command.Parameters.AddWithValue("$ySh", yShift);
                command.Parameters.AddWithValue("$sal", salt);

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

                // Initialise the query
                var command = conn.CreateCommand();
                command.CommandText =
                    @"SELECT * FROM Users WHERE Username == $user";

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
                        string salt = reader.GetValue(4).ToString();

                        // Set up an object and return it
                        User result = new User(uName, zValue, yShift, salt);
                        return result;

                    }

                    throw new Exception("Expected account, got none.");
                }
            }
        }

        /// <summary>
        /// Deletes an account from the database
        /// </summary>
        /// <param name="username">The username of the account to delete</param>
        internal static void deleteUser(string username)
        {
            using(var conn = new SqliteConnection($"Data Source={dbPath}"))
            {
                conn.Open();

                // Initialise the query
                var command = conn.CreateCommand();
                command.CommandText =
                    @"DELETE FROM Users WHERE Username == $user";

                // Add the parameter
                command.Parameters.AddWithValue("$user", username);

                // Run the command
                command.ExecuteNonQuery();
            }
        }
    }
}

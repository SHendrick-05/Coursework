using System.Collections.Generic;
using System.Linq;

namespace Coursework
{
    /// <summary>
    /// Static class to handle user accounts.
    /// </summary>
    internal static class Users
    {
        /// <summary>
        /// The user object of the account currently logged in.
        /// </summary>
        internal static User loggedInUser = null;

        /// <summary>
        /// Permanently deletes an account from the program.
        /// </summary>
        /// <param name="user">The user object of the account to delete.</param>
        internal static void deleteAccount(User user)
        {
            string username = user.username;
            Database.deleteUser(username);
            // Remove all scores.
            foreach(uint ID in Scores.scoreDict.Keys)
            {
                Scores.scoreDict[ID].RemoveAll(x => x.User == username);
            }
            Scores.SaveScores();
        }
    }

    /// <summary>
    /// The class that represents a user account.
    /// </summary>
    internal class User
    {
        /// <summary>
        /// A unique identifier integer for each account.
        /// </summary>
        internal int ID { get; set; }

        /// <summary>
        /// The account's chosen username. What they will be represented as.
        /// </summary>
        internal string username { get; set; }

        /// <summary>
        /// Security variable. The product of their two security primes.
        /// </summary>
        internal string zValue { get; set; }

        /// <summary>
        /// Security variable. The result of the bitwise XOR between a prime and their hashed password.
        /// </summary>
        internal string yShifted { get; set; }

        /// <summary>
        /// Security variable. The salt that the user's password was hashed with.
        /// </summary>
        internal string Salt { get; set; }

        /// <summary>
        /// The user's preferred note speed, measured in pixels per second.
        /// </summary>
        internal int Speed { get; set; }

        /// <summary>
        /// All the scores that the user has set.
        /// </summary>
        internal List<Score> scores { get; set; }

        /// <summary>
        /// The constructor function for a user account.
        /// </summary>
        /// <param name="UN">Username</param>
        /// <param name="ZP">The Z value, obtained by Z = X * Y</param>
        /// <param name="YS">Y' value, obtained by Y' = Y XOR HK'</param>
        /// <param name="salt">The salt associated with the user's password.</param>
        /// <param name="speed">The user's preferred notespeed.</param>
        internal User(string UN, string ZP, string YS, string salt, int speed)
        {
            username = UN;
            zValue = ZP;
            yShifted = YS;
            Salt = salt;
            Speed = speed;
        }
    }
}

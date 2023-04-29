using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Security
{
    internal static class Verification
    {
        // Cannot store this on the database, as salts are stored there. Stored in-code for security in case of a db-only leak.
        private const string pepper = "2QKKq9QbuBj927YmKMcn";

        /// <summary>
        /// Attempts to register an account, and add it to the database.
        /// </summary>
        /// <param name="username">The username to register an account under.</param>
        /// <param name="password">The password given for the account.</param>
        /// <returns>An integer code based on success [0 = Success, 1 = Empty field, 2 = Account exists]</returns>
        internal static int attemptRegister(string username, string password)
        {
            // One or more of the input fields was empty.
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return 1;
            }

            // An account with that username already exists.
            if (Database.getUser(username) != null)
            {
                return 2;
            }

            // Hash the password, using a salt and pepper.
            string salt = RandomGenerator.NextString(12);
            string toHash = password + salt + pepper;

            SHA512 hashAlgo = SHA512.Create();

            // Generate the two primes, X and Y.
            BigInteger X = Primes.generatePrime();
            BigInteger Y;
            do
            {
                Y = Primes.generatePrime();
            } while (X == Y);

            


            throw new NotImplementedException();
        }
    }
}

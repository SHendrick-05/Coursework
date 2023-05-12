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
        /// Attempts to register an account, and (if successful) adds it to the database.
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
            byte[] hash512Array = hashAlgo.ComputeHash(Encoding.Default.GetBytes(toHash));

            // Concaternate the hash with itself to get a 1024-bit hash.
            byte[] hashArray = hash512Array.Concat(hash512Array).ToArray();

            // Right circular shift the array
            int len = password.Length;
            int i, j = 0;
            // Bytes
            for (; len > 7; hashArray.)
            //

            // Generate the two primes, X and Y.
            BigInteger X = Primes.generatePrime();
            BigInteger Y;
            do
            {
                Y = Primes.generatePrime();
            } while (X == Y);

            // Convert one of the primes, Y, into a byte array for bitwise operations with the hash.
            byte[] yByteArray = Y.ToByteArray();

            // Use a Bitwise XOR between Y and the shifted 1024-bit hash.
            byte[] yTransformed = new byte[128];
            for (int i = 0; i < 128; i++)
            {
                int transformedByte = yByteArray[i] ^ shiftedArray[i];
                yTransformed[i] = Convert.ToByte(transformedByte);
            }

            // Convert the transformed Y value to an integer
            BigInteger yTransformedInt = new BigInteger(yTransformed);
            // Find Z, given by X * Y
            BigInteger Z = BigInteger.Multiply(X, Y);

            // Now we have all the values we need, register the account with the database, and return a success code.
            Database.addAccount(username, Z.ToString(), yTransformedInt.ToString(), salt);
            return 0;
        }

    }
}

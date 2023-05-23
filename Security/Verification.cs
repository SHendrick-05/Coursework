using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Policy;
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
            byte[] hashKey = hashShift(password, salt);

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
            byte[] yTransformed = bitwiseXOR(hashKey, yByteArray);

            // Convert the transformed Y value to an integer
            BigInteger yTransformedInt = new BigInteger(yTransformed);

            // Find Z, given by X * Y
            BigInteger Z = BigInteger.Multiply(X, Y);

            // Now we have all the values we need, register the account with the database, and return a success code.
            Database.addAccount(username, Z.ToString(), yTransformedInt.ToString(), salt);
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">The username of the account to update</param>
        /// <param name="password">The new password, used to overwrite the old one</param>
        /// <returns>An integer code [0 = Success, 1 = Field empty]</returns>
        internal static int attemptUpdate(string username, string password)
        {
            // One or more of the input fields was empty.
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return 1;
            }

            // Generate new encryption values for the new password.
            string salt = RandomGenerator.NextString(12);
            byte[] hashKey = hashShift(password, salt);

            BigInteger X = Primes.generatePrime();
            BigInteger Y;
            do
            {
                Y = Primes.generatePrime();
            } while (X == Y);
            // Get new values and push to DB
            byte[] yByteArray = Y.ToByteArray();
            byte[] yTransformed = bitwiseXOR(hashKey, yByteArray);
            BigInteger yTransformedInt = new BigInteger(yTransformed);
            BigInteger Z = BigInteger.Multiply(X, Y);
            Database.updateAccount(username, Z.ToString(), yTransformedInt.ToString(), salt);
            // Success
            return 0;

        }

        /// <summary>
        /// Attempts to login to a specific account.
        /// </summary>
        /// <param name="username">The username of the login attempt</param>
        /// <param name="password">The password of the login attempt</param>
        /// <returns>An integer code representing success [0 = Success, 1 = Empty field, 2 = Account does not exist, 3 = Invalid password]</returns>
        internal static int attemptLogin(string username, string password)
        {
            // One or more of the input fields was empty.
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return 1;
            }

            // Fetches the user from database, returning code 2 if null;
            User user = Database.getUser(username);
            if (user == null)
            {
                return 2;
            }

            // Salt, hash, and circular shift the password to obtain HK'
            string salt = user.Salt;
            byte[] hashKey = hashShift(password, salt);

            //Obtain Z and Y' from database
            BigInteger Z = BigInteger.Parse(user.zValue);
            BigInteger yTransformed = BigInteger.Parse(user.yShifted);

            // Use a XOR on Y' and HK' to obtain Y.
            byte[] yTransformedArray = yTransformed.ToByteArray();
            byte[] yArray = bitwiseXOR(yTransformedArray, hashKey);

            // Convert Y to an integer, and use a modulo test
            BigInteger Y = new BigInteger(yArray);
            BigInteger result = Z % Y;
            // If the result of the modulus is zero, that means the Y is the initial Y used, meaning the HK' was correct, owing to the valid password being entered.
            if (result.IsZero)
            {
                return 0;
            }
            else
            {
                return 3;
            }
        }

        /// <summary>
        /// A function that hashes a password, then expands it to 1024 bit, before right-circular shifting by the password length.
        /// </summary>
        /// <param name="password">The password to hash</param>
        /// <param name="salt">The salt with which to hash the password</param>
        /// <returns>A 1024-bit byte array representing the shifted hash key HK'</returns>
        internal static byte[] hashShift(string password, string salt)
        {
            // We are using SHA512, due to it being a secure hashing algorithm.
            SHA512 hashAlgo = SHA512.Create();
            // Get the string to hash, and hash it
            string toHash = password + salt + pepper;
            byte[] hash512Array = hashAlgo.ComputeHash(Encoding.Default.GetBytes(toHash));
            // Concaternate the hash with itself to get a 1024-bit hash.
            byte[] hashArray = hash512Array.Concat(hash512Array).ToArray();
            // Circular shift by passwordlength*4 bits, using hex.
            string hexHash = Convert.ToHexString(hashArray);
            string shiftedHex = hexHash.Substring(hexHash.Length - password.Length) + hexHash.Substring(0, hexHash.Length - password.Length);
            // Convert back and return the result
            byte[] shiftedArray = Convert.FromHexString(shiftedHex);
            return shiftedArray;
        }

        /// <summary>
        /// A bitwise XOR function between two byte arrays
        /// </summary>
        /// <returns>A byte array representing the result.</returns>
        internal static byte[] bitwiseXOR(byte[] array1, byte[] array2)
        {
            byte[] result = new byte[array1.Length];
            for(int i = 0; i < array1.Length; i++)
            {
                int resultByte = array1[i] ^ array2[i];
                result[i] = Convert.ToByte(resultByte);
            }
            return result;
        }
    }
}

using System;
using System.Numerics;
using System.Security.Cryptography;

namespace Coursework.Security
{
    /// <summary>
    /// Class for generating cryptographically secure large random numbers.
    /// </summary>
    internal static class RandomGenerator
    {
        
        /// <summary>
        /// A cryptographically secure random number generator. Used for generating large primes.
        /// </summary>
        /// <returns>A BigInteger type representing a 1024-bit random positive odd number</returns>
        internal static BigInteger Next()
        {
            // Fill an array of bytes, before making an appropriate BigInteger
            byte[] data = RandomNumberGenerator.GetBytes(128);
            BigInteger result = new BigInteger(data);

            // Apply a bitwise mask to make sure the MSB and the LSB are both 1.
            // This means that the result will be odd, and it will be sufficiently large.
            result |= (1 << ((int)result.GetBitLength() - 1)) | 1;

            // Take the absolute value to prevent negative numbers.
            return BigInteger.Abs(result);
        }

        /// <summary>
        /// A cryptographically secure random alphanumeric string generator. Used for generating user salts.
        /// </summary>
        /// <param name="length">The amount of characters to be in the output</param>
        /// <returns>A string of length "length" that consists of letters and digits.</returns>
        internal static string NextString(int length)
        {
            byte[] data = RandomNumberGenerator.GetBytes(length);
            string result = Convert.ToBase64String(data);
            return result;
        }
    }

    /// <summary>
    /// A class for the secure generation of prime numbers.
    /// </summary>
    internal static class Primes
    {
        /// <summary>
        /// A function to generate a large (probable) prime number, for security purposes.
        /// </summary>
        /// <returns>A 1024-bit large number</returns>
        internal static BigInteger generatePrime()
        {
            // Loops this section of code indefinitely until a prime is found.
            while (true)
            {
                // Generates an initial large number
                BigInteger possiblePrime = RandomGenerator.Next();
                // Tests for primality, and returns it if it passes.
                if (checkPrime(possiblePrime, 64))
                { 
                    return possiblePrime;
                }
            }
        }

        /// <summary>
        /// A test for whether a number is prime, using the Miller-Rabin probable primality test
        /// </summary>
        /// <param name="src">The BigInteger to be tested for primality</param>
        /// <param name="k">The bound for the test (the degree of certainty that src is prime), usually 64.</param>
        /// <returns>A boolean value representing the primality of src</returns>
        private static bool checkPrime(BigInteger src, int k)
        {
            BigInteger d = src - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            BigInteger a;

            // Perform the Miller-Rabin test for all cases up to k
            
            for (int i = 0; i < k; i++)
            {
                // Generate a new BigInteger, a.
                do
                {
                    a = RandomGenerator.Next();
                } while (a >= src - 2);

                // Use this to find a^d, modulo "src"
                BigInteger x = BigInteger.ModPow(a, d, src);

                // If the conditions are satisfied, move on to the next k
                if (x == 1 || x == src - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, i, src);
                    // If the test fails, it is a guaranteed composite. Return false immediately.
                    if (x == 1) return false;
                    if (x == src - 1) break;
                }

                if (x != src - 1) return false;
            }

            // The number has passed all tests and is a prime with very high probability.
            return true;
        }
    }
}

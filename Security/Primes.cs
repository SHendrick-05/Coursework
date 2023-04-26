using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml.XPath;

namespace Coursework.Security
{
    internal static class RandomGenerator
    {
        /// <summary>
        /// A cryptographically secure random number generator.
        /// </summary>
        /// <returns>A BigInteger type representing a 1024-bit random number</returns>
        public static BigInteger Next()
        {
            // Fill an array of bytes, before making an appropriate BigInteger
            byte[] data = RandomNumberGenerator.GetBytes(128);
            BigInteger result = new BigInteger(data);

            // Apply a bitwise mask to make sure the MSB and LSB are both 1.
            // This means that the result will be odd, and it will be sufficiently large.
            result |= 1;
            return BigInteger.Abs(result);
        }
    }
    internal static class Primes
    {
        /// <summary>
        /// A function to generate a large (probable) prime number, for security purposes.
        /// </summary>
        /// <returns>A 1024-bit large number</returns>
        public static BigInteger generatePrime()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Security
{
    internal static class Verification
    {
        /// <summary>
        /// Attempts to register an account, and add it to the database.
        /// </summary>
        /// <param name="username">The username to register an account under.</param>
        /// <param name="password">The password given for the account.</param>
        /// <returns>An integer code based on success [0 = Success, 1 = Empty field, 2 = Account exists]</returns>
        internal static int attemptRegister(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return 1;

            throw new NotImplementedException();
        }
    }
}

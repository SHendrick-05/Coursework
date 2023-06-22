using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    internal static class Users
    {
        internal static User loggedInUser = null;

        internal static void deleteAccount(User user)
        {
            string username = user.username;
            Database.deleteUser(username);
        }
    }
    internal class User
    {
        internal int ID { get; set; }
        internal string username { get; set; }
        internal string zValue { get; set; }
        internal string yShifted { get; set; }
        internal string Salt { get; set; }
        /// <summary>
        /// The user's preferred note speed, measured in pixels per second.
        /// </summary>
        internal int Speed { get; set; }
        internal List<Score> scores { get; set; }
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

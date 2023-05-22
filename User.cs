using Microsoft.Xna.Framework.Input;
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
            foreach(Score score in Scores.scoreList)
            {
                if (score.User == username)
                    Scores.scoreList.Remove(score);
            }
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
        internal List<Score> scores { get; set; }
        // The notespeed used (given as pixels per measure)
        internal int noteSpeed { get; set; }

        // The keybinds to be used for gameplay
        internal Keys keyLeft;
        internal Keys keyDown;
        internal Keys keyUp;
        internal Keys keyRight;
        internal Keys[] keyLayout { get
            {
                return new Keys[4]
                {
                    keyLeft,
                    keyDown,
                    keyUp,
                    keyRight
                };
            } }
        internal User(string UN, string ZP, string YS, string salt)
        {
            username = UN;
            zValue = ZP;
            yShifted = YS;
            Salt = salt;
        }
    }
}

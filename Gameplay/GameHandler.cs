using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Gameplay
{
    internal static class GameHandler
    {
        // The X positions of each arrow on the screen.
        internal static int[] arrowColumns = new int[4]
        {
            200, 300, 400, 500
        };
        // The keys the user has to press to hit arrows.
        internal static Keys[] hitKeys = new Keys[4]
        {
            Keys.A, Keys.S, Keys.L, Keys.OemSemicolon
        };
        // An array of lists, divided by column
        internal static List<Arrow>[] arrows = new List<Arrow>[4]
        {
            new List<Arrow>(), new List<Arrow>(), new List<Arrow>(), new List<Arrow>()
        };
        // How fast the arrows should fall.
        internal static double speed = 300;

        // Creates an arrow and adds it to the list.
        internal static void loadArrow(int Y, Dir dir, Point spriteCrop)
        {
            Arrow arrow = new Arrow(Y, dir, spriteCrop);
            arrows[(int)dir].Add(arrow);

        }
    }
}

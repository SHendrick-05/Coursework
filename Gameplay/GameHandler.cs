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
        // Timing windows for judgement boundaries
        internal static double[] timeWindows = new double[5]
        {
            0.022, // Perfect
            0.045, // Great
            0.090, // Good
            0.135, // OK
            0.180  // Bad
        };
        // An array of lists, divided by column
        internal static List<Arrow>[] arrows = new List<Arrow>[4]
        {
            new List<Arrow>(), new List<Arrow>(), new List<Arrow>(), new List<Arrow>()
        };
        // How fast the arrows should fall. (pixels per second)
        internal static double speed = 300;

        internal static int score;

        // Creates an arrow and adds it to the list.
        internal static void loadArrow(int Y, Dir dir, Point spriteCrop)
        {
            Arrow arrow = new Arrow(Y, dir, spriteCrop);
            arrows[(int)dir].Add(arrow);
        }

        internal static void arrowHit(Arrow arrow, Receptor recep)
        {
            float distance = Math.Abs(arrow.position.Y - recep.position.Y);
            double time = distance / speed;
            int judgement = 5;
            for(int i = 0; i < 5; i++)
            {
                if (timeWindows[i] > time)
                {
                    judgement = i;
                    break;
                }
            }
            switch (judgement)
            {
                case 0: // Perfect
                    score += 300;
                    break;
                case 1: // Great
                    score += 200;
                    break;
                case 2: // Good
                    score += 150;
                    break;
                case 3: // OK
                    score += 100;
                    break;
                case 4: // Bad
                    score += 50;
                    break;
                case 5: // Miss
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}

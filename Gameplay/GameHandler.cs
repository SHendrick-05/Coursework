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
        internal static int[] arrowColumns = new int[4]
        {
            200, 300, 400, 500
        };
        internal static Keys[] hitKeys = new Keys[4]
        {
            Keys.A, Keys.S, Keys.L, Keys.OemSemicolon
        };
        internal static List<Arrow>[] arrows = new List<Arrow>[4];
    }
}

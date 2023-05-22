using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Gameplay
{
    internal class GameHandler
    {
        internal static Song currentSong;

        internal static double[] windows = new double[5]
        {
            0.022, 
            0.045,
            0.090,
            0.135,
            0.180
        };
        internal static Keys[] hitKeys;
    }
}

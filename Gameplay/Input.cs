using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Gameplay
{
    internal class Input
    {
        internal static MouseState mouseState;
        internal static MouseState lastMouseState;

        internal static KeyboardState kbState;
        internal static KeyboardState lastkbState;
        internal static void Update()
        {
            lastMouseState = mouseState;
            mouseState = Mouse.GetState();

            lastkbState = kbState;
            kbState = Keyboard.GetState();
        }
    }
}

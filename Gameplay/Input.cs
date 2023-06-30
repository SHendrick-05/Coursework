using Microsoft.Xna.Framework.Input;

namespace Coursework.Gameplay
{
    internal class Input
    {
        /// <summary>
        /// The current state of the mouse
        /// </summary>
        internal static MouseState mouseState;

        /// <summary>
        /// The state of the mouse in the previous frame
        /// </summary>
        internal static MouseState lastMouseState;

        /// <summary>
        /// The current state of the keyboard
        /// </summary>
        internal static KeyboardState kbState;

        /// <summary>
        /// The state of the keyboard in the previous frame
        /// </summary>
        internal static KeyboardState lastkbState;

        /// <summary>
        /// Gets the latest mouse and keyboard states.
        /// </summary>
        internal static void Update()
        {
            // Update the mouse
            lastMouseState = mouseState;
            mouseState = Mouse.GetState();

            // Update the keyboard
            lastkbState = kbState;
            kbState = Keyboard.GetState();
        }
    }
}

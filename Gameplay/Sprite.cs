using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coursework.Gameplay
{
    internal class Sprite
    {
        private Texture2D texture;
        private int posX;
        private int posY;

        internal Vector2 position
        {
            get
            {
                return new Vector2(posX, posY);
            }
        }

        internal Texture2D Texture { get { return texture; } }
    }
}

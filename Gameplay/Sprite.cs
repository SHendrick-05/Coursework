using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coursework.Gameplay
{
    internal abstract class Sprite
    {
        protected Texture2D texture;
        protected int posX;
        protected int posY;

        internal Vector2 position
        {
            get
            {
                return new Vector2(posX, posY);
            }
        }

        internal abstract void Update(GameTime gameTime);
        internal Texture2D Texture { get { return texture; } }
    }
}

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

        internal Point size;
        internal float rotation;
        internal Point? spriteCrop;

        /// <summary>
        /// A rectangle representing how the texture should be cropped.
        /// </summary>
        internal Rectangle crop
        {
            get
            {
                if (spriteCrop == null)
                {
                    return Texture.Bounds;
                }
                Point location = new Point(
                    spriteCrop.Value.X * size.X,
                    spriteCrop.Value.Y * size.Y);

                return new Rectangle(location, size);
            }
        }

        internal Vector2 position
        {
            get
            {
                return new Vector2(posX, posY);
            }
        }

        internal abstract void Update(GameTime gameTime);
        internal Texture2D Texture { get { return texture; } }

        internal Sprite()
        {
            SongPlayer.addSprite(this);
        }
    }
}

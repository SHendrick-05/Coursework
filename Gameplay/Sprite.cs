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
        internal static float[] rotations = new float[4]
        {
            (float)Math.PI * 0.5f,
            0f,
            (float)Math.PI,
            (float)Math.PI * -0.5f
        };

        protected Texture2D texture;
        protected int posX;
        protected int posY;

        internal Point size;
        internal float rotation;
        internal Point spriteCrop;

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
                    spriteCrop.X * size.X,
                    spriteCrop.Y * size.Y);

                return new Rectangle(location, size);
            }
        }

        internal Vector2 origin
        {
            get
            {
                return new Vector2(size.X * 0.5f, size.Y * 0.5f);
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
            rotation = 0f;
            SongPlayer.addSprite(this);
        }
    }
}

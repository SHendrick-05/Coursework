using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coursework.Gameplay
{
    /// <summary>
    /// The base class for most sprites that are being drawn.
    /// </summary>
    internal abstract class Sprite
    {
        internal static float[] rotations = new float[4]
        {
            (float)Math.PI * 0.5f,
            0f,
            (float)Math.PI,
            (float)Math.PI * -0.5f
        };
        /// <summary>
        /// The (full) texture of the sprite
        /// </summary>
        protected Texture2D texture;
        
        protected int posX;
        protected int posY;
        internal bool isDeprecated;
        /// <summary>
        /// The rotation of the sprite, in clockwise radians.
        /// </summary>
        internal float rotation;
        /// <summary>
        /// The width and height of the sprite.
        /// </summary>
        internal Point size;
        /// <summary>
        /// How the sprite should be cropped.
        /// </summary>
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

        /// <summary>
        /// The centre of rotation. Returns the middle of the sprite bounds.
        /// </summary>
        internal Vector2 origin
        {
            get
            {
                return new Vector2(size.X * 0.5f, size.Y * 0.5f);
            }
        }

        /// <summary>
        /// The public property representing the position.
        /// </summary>
        internal Vector2 position
        {
            get
            {
                return new Vector2(posX, posY);
            }
        }

        /// <summary>
        /// This abstract feature will be implemented in inherited classes to perform specific tasks.
        /// </summary>
        internal abstract void Update(GameTime gameTime);
        
        /// <summary>
        /// The property for the sprite's texture.
        /// </summary>
        internal Texture2D Texture { get { return texture; } }

        /// <summary>
        /// Removes this sprite from being visible or from having calculations performed.
        /// </summary>
        internal virtual void Deprecate()
        {
            isDeprecated = true;
        }

        /// <summary>
        /// The base constructor function for all sprites.
        /// </summary>
        internal Sprite()
        {
            rotation = 0f;
            SongPlayer.addSprite(this);
            isDeprecated = false;
        }
    }

    /// <summary>
    /// A marker to show up for each judgement as a form of user feedback.
    /// </summary>
    internal class Tag
    {
        /// <summary>
        /// A rectangle representing the size that the tag should occupy.
        /// </summary>
        internal Rectangle bounds;

        /// <summary>
        /// The number of frames the tag should be displayed for.
        /// </summary>
        internal int frames;

        /// <summary>
        /// A float from 0 to 1 representing how opaque or transparent the tag should be. 0 is transparent, 1 is opaque.
        /// </summary>
        internal float opacity;

        /// <summary>
        /// A boolean value representing whether this tag should be displayed any further or not.
        /// </summary>
        internal bool isDeprecated;

        /// <summary>
        /// The colour of the tag.
        /// </summary>
        internal Color color;

        /// <summary>
        /// Initialise a tag to display on-screen
        /// </summary>
        /// <param name="pos">The X and Y coordinates of the tag</param>
        /// <param name="size">The width and height of the tag</param>
        /// <param name="frames">How many frames the tag should last for before being deprecated</param>
        internal Tag(Point pos, Point size, int frames, Color color)
        {
            bounds = new Rectangle(pos, size);
            this.frames = frames;
            this.color = color;
        }

        /// <summary>
        /// The update function, called each frame.
        /// </summary>
        internal void Update()
        {
            // This effect for the tag becoming more transparent.
            opacity = Math.Min(1f, --frames / 60f);
            if (frames <= 0)
            {
                // The tag should no longer be displayed after this point.
                isDeprecated = true;
            }
        }
    }
}

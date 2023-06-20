using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coursework.Gameplay
{

    internal class Arrow : Sprite
    {
        internal Random rnd = new Random();
        internal Dir dir;
        /// <summary>
        /// Constructor for the arrow class
        /// </summary>
        /// <param name="posY">The Y-position of the arrow (position of the top of the arrow)</param>
        /// <param name="dir">The directional enum of the arrow</param>
        /// <param name="spriteCrop">The point at which to crop the main sprite</param>
        internal Arrow(int posY, Dir dir, Point spriteCrop) : base()
        {
            // Set the variables
            this.posY = posY;
            this.dir = dir;
            this.spriteCrop = spriteCrop;
            size = GameHandler.arrowSize;
            posX = GameHandler.arrowColumns[(int)dir];
            rotation = rotations[(int)dir];
        }
        internal override void Update(GameTime gameTime)
        {
            // Move the arrow downwards by the appropriate amount.
            double distance = gameTime.ElapsedGameTime.TotalSeconds * GameHandler.speed;
            posY += (int)Math.Round(distance);
            MineUpdate();
            HitUpdate();
        }
        internal virtual void MineUpdate() { }
        internal virtual void HitUpdate() { }
        internal override void Deprecate()
        {
            GameHandler.arrows[(int)dir].Remove(this);
            isDeprecated = true;
        }
    }

    internal class Hit : Arrow
    {
        internal Hit(int posY, Dir dir, Point spriteCrop) : base(posY, dir, spriteCrop)
        {
            texture = SongPlayer.arrowTexture;
        }
        internal override void HitUpdate()
        {
            // Check if the note can no longer be hit and is offscreen.
            double positionDiff = posY - GameHandler.receptors[(int)dir].position.Y;
            double timeDiff = positionDiff / GameHandler.speed;
            if (posY > GameHandler.bounds.Y && timeDiff > GameHandler.timeWindows[5])
            {
                // Award a miss
                GameHandler.ArrowHit(this, (float)positionDiff);
            }
        }
    }

    internal class Mine : Arrow
    {
        int framesPerUpdate;
        int frame;
        int frames;
        internal Mine(int posY, Dir dir, Point spriteCrop) : base(posY, dir, spriteCrop)
        {
            texture = SongPlayer.mineTexture;
            framesPerUpdate = 10;
            frame = 0;
            frames = 8;
        }
        internal override void MineUpdate()
        {
            if (++frame >= framesPerUpdate)
            {
                if (spriteCrop.X++ == frames-1)
                    spriteCrop.X = 0;
                frame = 0;
            }
            // Check if the note is offscreen and cannot be hit
            double positionDiff = posY - GameHandler.receptors[(int)dir].position.Y;
            double timeDiff = positionDiff / GameHandler.speed;
            if (posY > GameHandler.bounds.Y && timeDiff > GameHandler.timeWindows[5])
            {
                // Remove the mine.
                Deprecate();
            }
        }
    }



    internal class Receptor : Sprite
    {
        internal Dir dir;
        internal Keys hitKey
        {
            get
            {
                return GameHandler.hitKeys[(int)dir];
            }
        }

        internal Receptor(int X, int Y, Dir dir, Point spriteCrop) : base()
        {
            posX = X;
            posY = Y;
            size = new Point(64, 64);
            this.spriteCrop = spriteCrop;
            this.dir = dir;
            texture = SongPlayer.recepTexture;
            rotation = rotations[(int)dir];
        }

        internal override void Update(GameTime gameTime)
        {
            KeyboardState kState = Input.kbState;
            KeyboardState lastKstate = Input.lastkbState;
            // If the corresponding key is pressed
            if (kState.IsKeyDown(hitKey))
            {
                spriteCrop.X = 1;
                // If the key was just pressed, not held from before.
                if (lastKstate.IsKeyUp(hitKey))
                {
                    // Get all the possible arrows of that column
                    List<Arrow> candidates = GameHandler.arrows[(int)dir];

                    Dictionary<Arrow, float> timings
                        = candidates.ToDictionary(x => x,
                        x => position.Y - x.position.Y);
                    // Find the latest/earliest possible hit.
                    double maximum = GameHandler.timeWindows[5] * GameHandler.speed;
                    // Find the possible ones, then filter to the latest one.
                    List<Arrow> canBeHit = timings.Keys.Where(x => Math.Abs(timings[x])<= maximum).ToList();
                    // If there are any arrows that can be hit.
                    if (canBeHit.Count != 0)
                    {
                        Arrow closest = canBeHit.MinBy(x => timings[x]);
                        // This is the hit arrow. Pass it on.
                        GameHandler.ArrowHit(closest, timings[closest]);
                    }
                }
            }
            else
            {
                spriteCrop.X = 0;
            }
        }
    }
}

/* 
 * Dir to rotation:
 * 0 = 90* ACW
 * 1 = 0
 * 2 = 180*
 * 3 = 90* CW
 */
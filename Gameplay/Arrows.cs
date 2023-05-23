﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            size = new Point(64, 64);
            posX = GameHandler.arrowColumns[(int)dir];
            rotation = rotations[(int)dir];
        }

        internal override void Update(GameTime gameTime)
        {
            // Move the arrow downwards by the appropriate amount.
            double distance = gameTime.ElapsedGameTime.TotalSeconds * GameHandler.speed;
            posY += (int)Math.Round(distance);
            MineUpdate();
        }
        internal virtual void MineUpdate() { }
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
    }

    internal class Mine : Arrow
    {
        int framesPerUpdate = 10;
        int frame = 0;
        internal Mine(int posY, Dir dir, Point spriteCrop) : base(posY, dir, spriteCrop)
        {
            texture = SongPlayer.mineTexture;
        }
        internal override void MineUpdate()
        {
            if (++frame >= framesPerUpdate)
            {
                if (spriteCrop.X++ == 7)
                    spriteCrop.X = 0;
                frame = 0;
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
                    // Find the possible ones, then filter to the earliest one.
                    List<Arrow> canBeHit = timings.Keys.Where(x => Math.Abs(timings[x])<= maximum).ToList();
                    // If there are any arrows that can be hit.
                    if (canBeHit.Count != 0)
                    {
                        Arrow closest = canBeHit.MinBy(x => timings[x]);
                        // This is the hit arrow. Pass it on.
                        GameHandler.arrowHit(closest, timings[closest]);
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
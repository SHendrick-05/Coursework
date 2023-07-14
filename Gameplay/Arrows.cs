using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coursework.Gameplay
{
    /// <summary>
    /// The arrow class that hits, mines and holds are inherited from.
    /// </summary>
    internal abstract class Arrow : Sprite
    {
        /// <summary>
        /// The direction that the arrow will be facing.
        /// </summary>
        internal Dir dir;

        /// <summary>
        /// What division of the measure the arrow is in.
        /// </summary>
        internal int measureDiv;

        /// <summary>
        /// What measure of the song the arrow is in. Starts at 0.
        /// </summary>
        internal int measure;

        /// <summary>
        /// Constructor for the arrow class
        /// </summary>
        /// <param name="posY">The Y-position of the arrow (position of the top of the arrow)</param>
        /// <param name="dir">The directional enum of the arrow</param>
        /// <param name="spriteCrop">The point at which to crop the main sprite</param>
        /// <param name="measureDiv">What position in the measure this arrow is at.</param>
        /// <param name="measure">What measure in the song this arrow is a part of</param>
        internal Arrow(int posY, Dir dir, Point spriteCrop, int measureDiv, int measure) : base()
        {
            // Set the variables to their default values.
            this.posY = posY;
            this.dir = dir;
            this.measure = measure;
            this.measureDiv = measureDiv;
            this.spriteCrop = spriteCrop;
            size = GameHandler.arrowSize;
            posX = GameHandler.arrowColumns[(int)dir];
            rotation = rotations[(int)dir];
        }

        /// <summary>
        /// The base update function, which ensures that the arrow moves at the appropriate note speed.
        /// </summary>
        internal override void Update(GameTime gameTime)
        {
            // Move the arrow downwards by the appropriate amount.
            double distance = gameTime.ElapsedGameTime.TotalSeconds * GameHandler.speed;
            posY += (int)Math.Round(distance);
            MineUpdate();
            HitUpdate();
            HoldUpdate();
        }
        /// <summary>
        /// An update function specific to mine objects.
        /// </summary>
        internal virtual void MineUpdate() { }

        /// <summary>
        /// An update function specific to hit notes.
        /// </summary>
        internal virtual void HitUpdate() { }

        /// <summary>
        /// An update function specific to hold notes.
        /// </summary>
        internal virtual void HoldUpdate() { }

        internal override void Deprecate()
        {
            GameHandler.arrows[(int)dir].Remove(this);
            isDeprecated = true;
        }
    }

    /// <summary>
    /// The basic "tap" arrow, where the user has to just press the key.
    /// </summary>
    internal class Hit : Arrow
    {
        internal Hit(int posY, Dir dir, Point spriteCrop, int measureDiv, int measure) : base(posY, dir, spriteCrop, measureDiv, measure)
        {
            texture = songPlayer.arrowTexture;
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

    /// <summary>
    /// A mine, which must be avoided in gameplay
    /// </summary>
    internal class Mine : Arrow
    {
        /// <summary>
        /// How many frames it should take for the mine's texture to update.
        /// </summary>
        int framesPerUpdate;

        /// <summary>
        /// What frame in the animation the mine is at.
        /// </summary>
        int frame;

        /// <summary>
        /// How many frames the animation has in total.
        /// </summary>
        int frames;
        
        internal Mine(int posY, Dir dir, Point spriteCrop, int measureDiv, int measure) : base(posY, dir, spriteCrop, measureDiv, measure)
        {
            texture = songPlayer.mineTexture;
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

    /// <summary>
    /// A hold note, which must be held down until the end of the body.
    /// </summary>
    internal class Hold : Arrow
    {
        /// <summary>
        /// The measure of the song that the note will stop being held at. Starts from 0.
        /// </summary>
        internal int endMeasure;

        /// <summary>
        /// The division of the measure that the note will stop being held at.
        /// </summary>
        internal int endMeasureDivision;

        /// <summary>
        /// The Y position that the note will stop being held at.
        /// </summary>
        internal int endY;
        internal Point bodySize
        {
            get
            {
                return new Point(GameHandler.arrowSize.X, endY - posY);
            }
        }
        internal Hold(int startY, int endY, Dir dir, Point spriteCrop, int startMeasureDiv, int startMeasure, int endMeasureDiv, int endMeasure) : base(startY, dir, spriteCrop, startMeasureDiv, startMeasure)
        {
            texture = songPlayer.arrowTexture;
            this.endMeasure = endMeasure;
            endMeasureDivision = endMeasureDiv;
            this.endY = endY;
        }

        internal override void HoldUpdate()
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


    /// <summary>
    /// The receptor class, which will be the points that the arrows must be hit at.
    /// </summary>
    internal class Receptor : Sprite
    {
        /// <summary>
        /// A boolean value to represent whether this receptor is currently holding down a LN.
        /// </summary>
        internal bool isHoldNote;

        /// <summary>
        /// The direction that the receptor is facing.
        /// </summary>
        internal Dir dir;

        /// <summary>
        /// The key that must be pressed to trigger this receptor. Taken from the static array in GameHandler.
        /// </summary>
        internal Keys hitKey
        {
            get
            {
                return GameHandler.hitKeys[(int)dir];
            }
        }

        /// <summary>
        /// The constuctor function of the receptors.
        /// </summary>
        internal Receptor(int X, int Y, Dir dir, Point spriteCrop) : base()
        {
            posX = X;
            posY = Y;
            size = new Point(64, 64);
            this.spriteCrop = spriteCrop;
            this.dir = dir;
            texture = songPlayer.recepTexture;
            rotation = rotations[(int)dir];
            isHoldNote = false;
        }

        /// <summary>
        /// The frame-by-frame update function for receptors. Handles notes being hit.
        /// </summary>
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
 * 0 = 90* ACW = PI/2
 * 1 = 0
 * 2 = 180* = PI
 * 3 = 90* CW = -PI/2
 */
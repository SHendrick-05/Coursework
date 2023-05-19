using Microsoft.Xna.Framework;
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
        internal Arrow(int posY, Dir dir, Point spriteCrop) : base()
        {
            
            this.posY = posY;
            this.dir = dir;
            size = new Point(64, 64);
            this.spriteCrop = spriteCrop;
            spriteCrop = new Point(0, rnd.Next(5));
            texture = SongPlayer.arrowTexture;
            posX = GameHandler.arrowColumns[(int)dir];
        }

        internal override void Update(GameTime gameTime)
        {
            // Move the arrow downwards by the appropriate amount.
            double distance = gameTime.ElapsedGameTime.TotalSeconds * GameHandler.speed;
            posY += (int)Math.Round(distance);
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

        internal Receptor(int X, int Y, Texture2D texture, Dir dir) : base()
        {
            posX = X;
            posY = Y;
            size = new Point(64, 64);
            this.dir = dir;
            this.texture = texture;
        }

        internal override void Update(GameTime gameTime)
        {
            KeyboardState kState = Input.kbState;
            KeyboardState lastKstate = Input.lastkbState;
            if (kState.IsKeyDown(hitKey))
            {
                if (lastKstate.IsKeyUp(hitKey))
                {
                    List<Arrow> candidates = GameHandler.arrows[(int)dir];
                }
            }
        }
    }
}

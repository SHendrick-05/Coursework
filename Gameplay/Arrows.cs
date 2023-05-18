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
        internal Dir dir;
        internal Arrow(int posY, Dir dir)
        {
            this.posY = posY;
            this.dir = dir;
            
            posX = GameHandler.arrowColumns[(int)dir];
        }
        internal override void Update(GameTime gameTime)
        {

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

        internal Receptor(int X, int Y, Texture2D texture, Dir dir)
        {
            posX = X;
            posY = Y;
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

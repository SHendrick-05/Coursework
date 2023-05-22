using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Gameplay
{
    internal class Label
    {
        internal SpriteFont sFont;
        private int posX;
        private int posY;
        internal string text;

        internal Vector2 position
        {
            get
            {
                return new Vector2(posX, posY);
            }
        }
        internal void Deprecate()
        {
            SongPlayer.labels[this] = 0;
        }
    }
}

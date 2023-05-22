using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Coursework.Gameplay
{
    internal class SongPlayer : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private static List<Sprite> sprites;
        internal static Texture2D arrowTexture;
        internal static Texture2D recepTexture;
        internal static SpriteFont centuryGothic;

        /// <summary>
        /// A dictionary representing all labels via keys, with the value being how many frames they are displayed for. -1 means they are always displayed.
        /// </summary>
        internal static Dictionary<Label, int> labels;


        internal static void addSprite(Sprite spr)
            => sprites.Add(spr);

        internal static void removeSprite(Sprite spr)
            => sprites.Remove(spr);
        

        internal SongPlayer()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Set the monogame to borderless
            if (GraphicsDevice == null)
                _graphics.ApplyChanges();
            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.HardwareModeSwitch = false;
            _graphics.ApplyChanges();

            // Initialise the list
            sprites = new List<Sprite>();
            labels = new Dictionary<Label, int>();

            // Get textures
            arrowTexture = Content.Load<Texture2D>("downTap");
            recepTexture = Content.Load<Texture2D>("downReceptor");
            centuryGothic = Content.Load<SpriteFont>("centuryGothic16");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Load receptors
            for(int i = 0; i < 4; i++)
            {
                Receptor rcp = new Receptor(GameHandler.arrowColumns[i],
                                        _graphics.PreferredBackBufferHeight - 200,
                                        (Dir)i,
                                        new Point(0, 0));
            }
            Random rnd = new Random();

            int baseY = 100;
            for (int i = 0; i < 100; i++)
            {
                GameHandler.loadArrow(baseY, (Dir)rnd.Next(4), new Point(0, rnd.Next(5)));
                baseY -= 100;
            }

            /*
            Random rnd = new Random();
            Song sng = new Song();
            sng.BPM = 110;
            sng.name = "test";
            sng.description = "test2";
            for (int i = 0; i < 200; i++)
            {
                songNoteType[,] measure = new songNoteType[16, 4];
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 16; k++)
                    {
                        songNoteType note = rnd.Next(10) == 0 ? songNoteType.HIT : songNoteType.NONE;
                        measure[k, j] = note;
                    }
                }
                sng.measures.Add(measure);
            }
            string songTXT = JsonConvert.SerializeObject(sng, Formatting.None);
            File.WriteAllText(@"Storage\test.json", songTXT); */
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Update sprites
            List<Sprite> toRemove = new List<Sprite>();
            foreach(Sprite spr in sprites)
            {
                spr.Update(gameTime);
                if (spr.isDeprecated) toRemove.Add(spr);
            }
            // Remove the deprecated sprites
            sprites = sprites.Except(toRemove).ToList();

            // Update input
            Input.Update();

            // Update labels
            foreach(KeyValuePair<Label, int> pair in labels)
            {
                // Permanent label, or one to deprecate
                if (pair.Value <= 0) continue;
                // Label to decrement
                else labels[pair.Key]--;
            }
            // Remove the deprecated labels.
            labels = labels.Where(x => x.Value != 0).ToDictionary(x => x.Key, x => x.Value);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.BackToFront);
            float ord = 1;
            foreach (Sprite spr in sprites)
            {
                _spriteBatch.Draw(
                    spr.Texture,
                    spr.position,
                    spr.crop,
                    Color.White,
                    spr.rotation,
                    spr.origin,
                    1f, // Scale
                    SpriteEffects.None,
                    ord
                    );
                ord++;
            }
            /*
            // Draw labels
            foreach(Label lab in labels.Keys)
            {
                _spriteBatch.DrawString(
                    lab.sFont,
                    lab.text,
                    lab.position,
                    Color.White);

            }

            _spriteBatch.DrawString(centuryGothic, "test", new Vector2(0, 0), Color.Black);
            _spriteBatch.End();
            */
            base.Draw(gameTime);
        }


    }
}
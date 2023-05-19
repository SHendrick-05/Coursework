using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Coursework.Gameplay
{
    internal class SongPlayer : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private static List<Sprite> sprites;
        internal static Texture2D arrowTexture;
        internal static Texture2D recepTexture;

        internal static void addSprite(Sprite spr)
        {
            sprites.Add(spr);
        }
        

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

            // Get textures
            arrowTexture = Content.Load<Texture2D>("downTap");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Load receptors
            for(int i = 0; i < 4; i++)
            {

            }

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
            string songTXT = JsonConvert.SerializeObject(sng);
            File.WriteAllText(@"Storage\test.json", songTXT);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach(Sprite spr in sprites)
            {
                spr.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Sprite spr in sprites)
            {
                _spriteBatch.Draw(
                    spr.Texture,
                    spr.position,
                    spr.crop,
                    Color.White,
                    1f,
                    new Vector2(0, 0),
                    0f,
                    SpriteEffects.None,
                    0f
                    );
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
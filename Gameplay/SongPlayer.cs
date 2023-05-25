﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.Linq;

namespace Coursework.Gameplay
{
    internal class SongPlayer : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private static List<Sprite> sprites;
        internal static Texture2D arrowTexture;
        internal static Texture2D mineTexture;
        internal static Texture2D recepTexture;
        internal static SpriteFont centuryGothic;
        internal static Song audio;

        internal static bool isPlaying;
        internal static string chartFolder;
        internal static int _height;
        internal static int labelFrames;
        internal static List<float> variations;

        // Judgement label
        private static string judgeText;
        private static Color judgeColor;

        internal static void updateJudge(Color color, string text)
        {
            labelFrames = 30;
            judgeText = text;
            judgeColor = color;
        }

        internal static void addSprite(Sprite spr)
            => sprites.Add(spr);

        internal static void removeSprite(Sprite spr)
            => sprites.Remove(spr);
        

        internal SongPlayer(string folder)
        {
            chartFolder = folder;
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

            // Reset all variables
            labelFrames = 0;
            _height = _graphics.PreferredBackBufferHeight;
            isPlaying = false;


            // Initialise the list
            sprites = new List<Sprite>();
            variations = new List<float>();


            // Get textures
            arrowTexture = Content.Load<Texture2D>("downTap");
            mineTexture = Content.Load<Texture2D>("downMine");
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
                                        _height - 200,
                                        (Dir)i,
                                        new Point(0, 0));
            }

            GameHandler.loadSong(chartFolder);
            

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update sprites
            List<Sprite> toRemove = new List<Sprite>();
            foreach(Sprite spr in sprites)
            {
                spr.Update(gameTime);
                if (spr.isDeprecated) toRemove.Add(spr);
            }
            // Remove the deprecated sprites
            sprites = sprites.Except(toRemove).ToList();
            
            if (gameTime.TotalGameTime.TotalSeconds >= 2 && !isPlaying)
            {
                isPlaying = true;
                MediaPlayer.Play(audio);
            }

            // Update input
            Input.Update();
            labelFrames--;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            
            _spriteBatch.Begin(SpriteSortMode.FrontToBack);
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
                    1/ord
                    );
                ord++;
            }
            

            // Judgement
            if (labelFrames > 0)
            {
                float centerX = (GameHandler.arrowColumns[1] + GameHandler.arrowColumns[2]) / 2f;
                Vector2 bound = centuryGothic.MeasureString(judgeText);
                float width = bound.X;

                _spriteBatch.DrawString(centuryGothic, judgeText, new Vector2(centerX - (width / 2f), 500), judgeColor);
            }

            // Health
            _spriteBatch.DrawString(centuryGothic, "HP: " + GameHandler.HP, new Vector2(0, 0), Color.White);
            // Score
            _spriteBatch.DrawString(centuryGothic, "Score: " + GameHandler.score, new Vector2(GameHandler.arrowColumns[3] + 100, 300), Color.White);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }


    }
}
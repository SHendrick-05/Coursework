﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Coursework.Gameplay
{
    internal class SongPlayer : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        /// <summary>
        /// A list of sprites, which is used in drawing.
        /// </summary>
        private static List<Sprite> sprites;
        private static List<Tag> tags;
        // Textures
        internal static Texture2D arrowTexture;
        internal static Texture2D mineTexture;
        internal static Texture2D rectangle;
        internal static Texture2D recepTexture;

        // Fonts
        internal static SpriteFont centuryGothic;
        internal static SpriteFont resultsFont;

        // Sound handling
        internal static SoundEffect mineHit;
        internal static Song audio;

        /// <summary>
        /// How many more frames the judgement label should be displayed for.
        /// </summary>
        internal static int labelFrames;
        internal static bool isPlaying;
        internal static int gameOverFrames;
        internal static string chartFolder;
        internal static int _height;
        internal static bool resultsScreen;



        // Judgement label
        private static string judgeText;
        private static Color judgeColor;

        /// <summary>
        /// Updates the judgement label on a note hit.
        /// </summary>
        /// <param name="color">The color of the label</param>
        /// <param name="text">The text it should display.</param>
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

        internal static void addTag(Tag tag)
            => tags.Add(tag);

        internal static void removeTag(Tag tag)
            => tags.Remove(tag);
        
        internal SongPlayer(string folder)
        {
            chartFolder = folder;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initialise variables and other things.
        /// </summary>
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
            GameHandler.bounds = new Point(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            isPlaying = false;
            resultsScreen = false;
            gameOverFrames = 0;
            GameHandler.variations.Clear();
            GameHandler.score = 0;
            GameHandler.HP = 100;
            GameHandler.speed = 800;
            isPlaying = false;

            Array.Clear(GameHandler.judgements);
            for (int i = 0; i < 4; i++)
            {
                GameHandler.arrows[i].Clear();
            }


            // Initialise the list
            sprites = new List<Sprite>();
            tags = new List<Tag>();
            base.Initialize();
        }

        /// <summary>
        /// Loads the content into the game.
        /// </summary>
        protected override void LoadContent()
        {
            // Get textures
            arrowTexture = Content.Load<Texture2D>("downTap");
            mineTexture = Content.Load<Texture2D>("downMine");
            recepTexture = Content.Load<Texture2D>("downReceptor");
            mineHit = Content.Load<SoundEffect>("explosion");
            //Fonts
            centuryGothic = Content.Load<SpriteFont>("centuryGothic16");
            resultsFont = Content.Load<SpriteFont>("resultsFont");

            rectangle = new Texture2D(GraphicsDevice, 1, 1);
            rectangle.SetData(new[] { Color.White });

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Load receptors
            for(int i = 0; i < 4; i++)
            {
                Receptor rcp = new Receptor(GameHandler.arrowColumns[i],
                                        GameHandler.bounds.Y - 200,
                                        (Dir)i,
                                        new Point(0, 0));
                GameHandler.receptors[i] = rcp;
            }

            GameHandler.loadSong(chartFolder);
        }



        /// <summary>
        /// A function to update the behaviour of the game every frame
        /// </summary>
        /// <param name="gameTime">The running time of the game.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Input.kbState.IsKeyDown(Keys.Space))
                GameHandler.HP = 0;
            // Update sprites and tags
            if (gameOverFrames == 0)
            {
                // Lists of the ones to remove
                List<Sprite> spritesToRemove = new List<Sprite>();
                List<Tag> tagsToRemove = new List<Tag>();

                // Update each sprite
                foreach (Sprite spr in sprites)
                {
                    spr.Update(gameTime);
                    if (spr.isDeprecated) spritesToRemove.Add(spr);
                }
                // Update each tag
                foreach(Tag tag in tags)
                {
                    tag.Update();
                    if (tag.isDeprecated) tagsToRemove.Add(tag);
                }

                // Remove the deprecated sprites and tags
                sprites = sprites.Except(spritesToRemove).ToList();
                tags = tags.Except(tagsToRemove).ToList();
            }
            else
            {
                gameOverFrames--;
                if (gameOverFrames == 0)
                    // Move on to the results screen
                    resultsScreen = true;
            }

            

            if (gameTime.TotalGameTime.TotalSeconds >= GameHandler.timeDelay && !isPlaying)
            {
                    isPlaying = true;
                    MediaPlayer.Play(audio);
            }
            // Update input
            Input.Update();
            labelFrames--;

            // Check HP
            if (GameHandler.HP <= 0 && gameOverFrames == 0)
            {
                GameHandler.HP = 0;
                GameHandler.speed = 0;
                gameOverFrames = 120;
                MediaPlayer.Stop();
            }
            else if (GameHandler.HP > 100)
                GameHandler.HP = 100;
            base.Update(gameTime);
        }

        /// <summary>
        /// A function to draw the sprites on screen every frame
        /// </summary>
        /// <param name="gameTime">The running time of the game.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (resultsScreen)
                DrawResults(gameTime);
            else
                DrawGameplay(gameTime);
        }

        /// <summary>
        /// Draws the results of a chart performance after gameplay has ended
        /// </summary>
        private void DrawResults(GameTime gameTime)
        {
            // Clear the screen
            GraphicsDevice.Clear(Color.DarkSlateGray);
            // Open the sprite drawer
            _spriteBatch.Begin();

            // Get coordinates to use in drawing
            float middle = _graphics.PreferredBackBufferWidth / 2f;
            float titleX = middle - centuryGothic.MeasureString(GameHandler.currentChart.title).X;

            int rectWidth = (int)middle - 100;

            // Variable calculations for the drawing
            int numJudges = GameHandler.judgements.Sum();

            float pctWidth = centuryGothic.MeasureString("(00.00%)").X;

            float judgeCountX = 80 + rectWidth - pctWidth;
            float pctX = 90 + rectWidth - pctWidth;
            int textY = 25 - (int)(resultsFont.MeasureString("Test").Y / 2);


            // Chart title
            _spriteBatch.DrawString(resultsFont, GameHandler.currentChart.title, new Vector2(titleX, 50), Color.White);


            // Create a rectangle for each judgement.
            for (int i = 0; i < 6; i++)
            {
                int baseY = 100 + 100 * i;
                int bound = GameHandler.judgements[i] * rectWidth / numJudges;
                string percent = string.Format("({0:0.00}%)", 100 * GameHandler.judgements[i] / (float)numJudges);

                // Draw the base rectangle
                _spriteBatch.Draw(rectangle, new Rectangle(100, baseY, rectWidth, 50), GameHandler.judgeColors[i] * 0.5f);
                // Fill it in with the appropriate percentage
                _spriteBatch.Draw(rectangle, new Rectangle(100, baseY, bound, 50), GameHandler.judgeColors[i]);
                // Draw judgement text
                _spriteBatch.DrawString(resultsFont, GameHandler.judgeStrings[i], new Vector2(110, baseY + textY), Color.White);
                // Draw the judgement count
                _spriteBatch.DrawString(resultsFont, GameHandler.judgements[i].ToString(), new Vector2(judgeCountX - resultsFont.MeasureString(GameHandler.judgements[i].ToString()).X, baseY + textY), Color.White);
                // Draw the percentage
                _spriteBatch.DrawString(centuryGothic, percent, new Vector2(pctX, baseY + textY), Color.White);
            }

            // Drawing is finished.
            _spriteBatch.End();
        }

        /// <summary>
        /// Draws to the screen during gameplay
        /// </summary>
        private void DrawGameplay(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // Open the sprite drawer.
            _spriteBatch.Begin(SpriteSortMode.FrontToBack);

            // Draw sprites
            float ord = 1;
            foreach (Sprite spr in sprites)
            {
                // Draw the sprite.
                _spriteBatch.Draw(
                    spr.Texture,
                    spr.position,
                    spr.crop,
                    Color.White,
                    spr.rotation,
                    spr.origin,
                    1f, // Scale
                    SpriteEffects.None,
                    1 / ord
                    );
                ord++;
            }

            // Draw tags
            foreach(Tag tag in tags)
            {
                _spriteBatch.Draw(
                    rectangle,
                    tag.bounds,
                    tag.color * tag.opacity);
            }

            // Judgement
            if (labelFrames > 0)
            {
                float centerX = (GameHandler.arrowColumns[1] + GameHandler.arrowColumns[2]) / 2f;
                Vector2 bound = centuryGothic.MeasureString(judgeText);
                float width = bound.X;

                _spriteBatch.DrawString(centuryGothic, judgeText, new Vector2(centerX - (width / 2f), GameHandler.judgeLabelY), judgeColor);
            }

            int rightX = GameHandler.arrowColumns[3] + 100;
            float judgeDiv = centuryGothic.MeasureString("test").Y + 20;


            _spriteBatch.DrawString(resultsFont, (1 / gameTime.ElapsedGameTime.TotalSeconds).ToString(), new Vector2(0, 0), Color.White);

            // Health
            Color hpColor = GameHandler.HP > 40 ? Color.Green : Color.Red;
            _spriteBatch.Draw(rectangle, new Rectangle(50, 50, 5*GameHandler.HP, 50), hpColor);
            // Mean
            if (GameHandler.variations.Count != 0)
            {
                string mean = string.Format("{0:0.00} ms", GameHandler.variations.Average() * 1000);
                _spriteBatch.DrawString(centuryGothic, mean, new Vector2(rightX, 200), Color.White);
            }
                // Score
                _spriteBatch.DrawString(centuryGothic, "Score: " + GameHandler.score, new Vector2(rightX, 300), Color.White);
            // Judgements
            _spriteBatch.DrawString(centuryGothic, "Perfects: " + GameHandler.judgements[0], new Vector2(rightX, 400), Color.White);
            _spriteBatch.DrawString(centuryGothic, "Greats: " + GameHandler.judgements[1], new Vector2(rightX, 400 + judgeDiv), Color.White);
            _spriteBatch.DrawString(centuryGothic, "Goods: " + GameHandler.judgements[2], new Vector2(rightX, 400 + 2 * judgeDiv), Color.White);
            _spriteBatch.DrawString(centuryGothic, "OKs: " + GameHandler.judgements[3], new Vector2(rightX, 400 + 3 * judgeDiv), Color.White);
            _spriteBatch.DrawString(centuryGothic, "Bads: " + GameHandler.judgements[4], new Vector2(rightX, 400 + 4 * judgeDiv), Color.White);
            _spriteBatch.DrawString(centuryGothic, "Misses: " + GameHandler.judgements[5], new Vector2(rightX, 400 + 5 * judgeDiv), Color.White);
            _spriteBatch.End();
        }
    }
}
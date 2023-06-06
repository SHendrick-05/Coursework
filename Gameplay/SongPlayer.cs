using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Linq;

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
            _height = _graphics.PreferredBackBufferHeight;
            isPlaying = false;
            resultsScreen = false;


            // Initialise the list
            sprites = new List<Sprite>();
            
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
                                        _height - 200,
                                        (Dir)i,
                                        new Point(0, 0));
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
            // Update sprites
            if (gameOverFrames == 0)
            {
                List<Sprite> toRemove = new List<Sprite>();
                foreach (Sprite spr in sprites)
                {
                    spr.Update(gameTime);
                    if (spr.isDeprecated) toRemove.Add(spr);
                }
                // Remove the deprecated sprites
                sprites = sprites.Except(toRemove).ToList();
            }
            else
            {
                gameOverFrames--;
                if (gameOverFrames == 0)
                    // Move on to the results screen
                    resultsScreen = true;
            }

            if (gameTime.TotalGameTime.TotalSeconds >= 2 && !isPlaying)
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

            base.Update(gameTime);
        }

        /// <summary>
        /// A function to draw the sprites on screen every frame
        /// </summary>
        /// <param name="gameTime">The running time of the game.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (resultsScreen)
                DrawResults();
            else
                DrawGameplay();
        }

        /// <summary>
        /// Draws the results of a chart performance after gameplay has ended
        /// </summary>
        private void DrawResults()
        {
            // Clear the screen
            GraphicsDevice.Clear(Color.DarkSlateGray);
            // Open the sprite drawer
            _spriteBatch.Begin();

            // Get coordinates to use in drawing
            float middle = _graphics.PreferredBackBufferWidth / 2f;
            float titleX = middle - centuryGothic.MeasureString(GameHandler.currentChart.title).X;

            int rectWidth = (int)middle - 100;

            // Chart title
            _spriteBatch.DrawString(resultsFont, GameHandler.currentChart.title, new Vector2(titleX, 50), Color.White);

            // Draw the base for the note count
            _spriteBatch.Draw(rectangle, new Rectangle(100, 200, rectWidth, 50), Color.DarkTurquoise * 0.5f);
            _spriteBatch.Draw(rectangle, new Rectangle(100, 300, rectWidth, 50), Color.Goldenrod * 0.5f);
            _spriteBatch.Draw(rectangle, new Rectangle(100, 400, rectWidth, 50), Color.Green * 0.5f);
            _spriteBatch.Draw(rectangle, new Rectangle(100, 500, rectWidth, 50), Color.Blue * 0.5f);
            _spriteBatch.Draw(rectangle, new Rectangle(100, 600, rectWidth, 50), Color.HotPink * 0.5f);
            _spriteBatch.Draw(rectangle, new Rectangle(100, 700, rectWidth, 50), Color.DarkRed * 0.5f);

            // Draw the note count itself
            int numJudges = GameHandler.judgements.Sum();
            int perfectBound = GameHandler.judgements[0] * rectWidth / numJudges;
            int greatBound = GameHandler.judgements[1] * rectWidth / numJudges;
            int goodBound = GameHandler.judgements[2] * rectWidth / numJudges;
            int okBound = GameHandler.judgements[3] * rectWidth / numJudges;
            int badBound = GameHandler.judgements[4] * rectWidth / numJudges;
            int missBound = GameHandler.judgements[5] * rectWidth / numJudges;

            // Draw the note count rectangles
            _spriteBatch.Draw(rectangle, new Rectangle(100, 200, perfectBound, 50), Color.DarkTurquoise);
            _spriteBatch.Draw(rectangle, new Rectangle(100, 300, greatBound, 50), Color.Goldenrod);
            _spriteBatch.Draw(rectangle, new Rectangle(100, 400, goodBound, 50), Color.Green);
            _spriteBatch.Draw(rectangle, new Rectangle(100, 500, okBound, 50), Color.Blue);
            _spriteBatch.Draw(rectangle, new Rectangle(100, 600, badBound, 50), Color.HotPink);
            _spriteBatch.Draw(rectangle, new Rectangle(100, 700, missBound, 50), Color.DarkRed);

            // Draw the judgement text
            int textY = 25 - (int)(resultsFont.MeasureString("Test").Y / 2);
            _spriteBatch.DrawString(resultsFont, "Perfect", new Vector2(110, 200 + textY), Color.White);
            _spriteBatch.DrawString(resultsFont, "Great", new Vector2(110, 300 + textY), Color.White);
            _spriteBatch.DrawString(resultsFont, "Good", new Vector2(110, 400 + textY), Color.White);
            _spriteBatch.DrawString(resultsFont, "OK", new Vector2(110, 500 + textY), Color.White);
            _spriteBatch.DrawString(resultsFont, "Bad", new Vector2(110, 600 + textY), Color.White);
            _spriteBatch.DrawString(resultsFont, "Miss", new Vector2(110, 700 + textY), Color.White);

            // Drawing is finished.
            _spriteBatch.End();
        }

        /// <summary>
        /// Draws to the screen during gameplay
        /// </summary>
        private void DrawGameplay()
        {
            GraphicsDevice.Clear(Color.Black);
            // Open the sprite drawer.
            _spriteBatch.Begin(SpriteSortMode.FrontToBack);

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

            // Judgement
            if (labelFrames > 0)
            {
                float centerX = (GameHandler.arrowColumns[1] + GameHandler.arrowColumns[2]) / 2f;
                Vector2 bound = centuryGothic.MeasureString(judgeText);
                float width = bound.X;

                _spriteBatch.DrawString(centuryGothic, judgeText, new Vector2(centerX - (width / 2f), 500), judgeColor);
            }

            int rightX = GameHandler.arrowColumns[3] + 100;
            float judgeDiv = centuryGothic.MeasureString("test").Y + 20;

            // Health
            _spriteBatch.DrawString(centuryGothic, "HP: " + GameHandler.HP, new Vector2(0, 0), Color.White);
            // Mean
            if (GameHandler.variations.Count != 0)
            _spriteBatch.DrawString(centuryGothic, (GameHandler.variations.Average() * 1000).ToString(), new Vector2(rightX, 200), Color.White);
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
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
        internal static Texture2D recepTexture;
        internal static SpriteFont centuryGothic;

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
            centuryGothic = Content.Load<SpriteFont>("centuryGothic16");
            mineHit = Content.Load<SoundEffect>("explosion");

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
                    // Close the application and return a fail.
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

            int rightX = GameHandler.arrowColumns[3] + 100;
            float judgeDiv = centuryGothic.MeasureString("test").Y + 20;

            // Health
            _spriteBatch.DrawString(centuryGothic, "HP: " + GameHandler.HP, new Vector2(0, 0), Color.White);
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
            

            if (resultsScreen)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            base.Draw(gameTime);
        }


    }
}
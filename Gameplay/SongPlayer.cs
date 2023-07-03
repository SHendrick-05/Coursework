﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Linq;
using System;
using NAudio.Wave;

namespace Coursework.Gameplay
{
    internal class songPlayer : Game
    {
        /// <summary>
        /// Used for finding boundaries and various other things.
        /// </summary>
        private GraphicsDeviceManager _graphics;

        /// <summary>
        /// The game's sprite batch. Used for drawing strings and textures.
        /// </summary>
        private SpriteBatch _spriteBatch;

        /// <summary>
        /// A list of sprites, which is used in drawing.
        /// </summary>
        private static List<Sprite> sprites;

        /// <summary>
        /// A list of all judgement feedback tags currently being displayed.
        /// </summary>
        private static List<Tag> tags;

        internal static string songPathLol;
        internal static Uri songLOL;

        /// <summary>
        /// The full texture of a hit arrow. Facing downwards by default.
        /// </summary>
        internal static Texture2D arrowTexture;
        
        /// <summary>
        /// The full texture of a mine. 
        /// </summary>
        internal static Texture2D mineTexture;

        /// <summary>
        /// The full texture for a receptor. Facing downwards by default.
        /// </summary>
        internal static Texture2D recepTexture;

        /// <summary>
        /// A 1x1 rectangle used for drawing rectangular shapes. Can be resized and coloured.
        /// </summary>
        internal static Texture2D rectangle;
        
        // Fonts
        internal static SpriteFont centuryGothic;
        internal static SpriteFont resultsFont;

        /// <summary>
        /// The sound effect that should be played when a mine is hit.
        /// </summary>
        internal static SoundEffect mineHit;

        /// <summary>
        /// The audio of the chart that is being played.
        /// </summary>
        internal static Mp3FileReader audio;

        /// <summary>
        /// The NAudio Song player that will be used for playing songs.
        /// </summary>
        internal static WaveOut audioPlayer;

        /// <summary>
        /// How many more frames the judgement label should be displayed for.
        /// </summary>
        internal static int labelFrames;

        /// <summary>
        /// Respresents if the user is currently in gameplay
        /// </summary>
        internal static bool isPlaying;

        /// <summary>
        /// The amount of frames until the results screen should be displayed. Only applicable when isPlaying is false.
        /// </summary>
        internal static int gameOverFrames;

        /// <summary>
        /// An absolute path to the folder that the chart is contained in.
        /// </summary>
        internal static string chartFolder;

        /// <summary>
        /// Whether the results screen should be displayed instead of gameplay.
        /// </summary>
        internal static bool resultsScreen;

        /// <summary>
        /// The text that is currently being displayed as judgement feedback
        /// </summary>
        private static string judgeText;

        /// <summary>
        /// The colour associated with the judgement feedback being displayed.
        /// </summary>
        private static Color judgeColor;

        /// <summary>
        /// The number of notes per each sample for the average line, in the results screen.
        /// </summary>
        private static int notesPerSample;

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

        /// <summary>
        /// Adds a sprite to the list of sprites. Used when creating new sprites.
        /// </summary>
        /// <param name="spr">The sprite to add</param>
        internal static void addSprite(Sprite spr)
            => sprites.Add(spr);
        
        
        /// <summary>
        /// Adds a judgement feedback tag to the appropriate list. Accessed from GameHandler when a note is hit.
        /// </summary>
        /// <param name="tag">The tag to display</param>
        internal static void addTag(Tag tag)
            => tags.Add(tag);

        /// <summary>
        /// Constructor method for the song player
        /// </summary>
        /// <param name="folder">The absolute path of the folder containing the chart to be played</param>
        internal songPlayer(string folder)
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

            // Clear the GameHandler variables.
            GameHandler.bounds = new Point(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            GameHandler.InitVariables();

            // Clear the variables here.
            audioPlayer = new WaveOut();
            labelFrames = 0;
            gameOverFrames = 0;
            notesPerSample = 10;
            isPlaying = false;
            resultsScreen = false;

            for (int i = 0; i < 4; i++)
            {
                GameHandler.arrows[i].Clear();
            }

            // Initialise the lists
            sprites = new List<Sprite>();
            tags = new List<Tag>();

            // Default init function.
            base.Initialize();
        }

        /// <summary>
        /// Loads the content into the game.
        /// </summary>
        protected override void LoadContent()
        {
            // Load the textures from content file.
            arrowTexture = Content.Load<Texture2D>("downTap");
            mineTexture = Content.Load<Texture2D>("downMine");
            recepTexture = Content.Load<Texture2D>("downReceptor");
            mineHit = Content.Load<SoundEffect>("explosion");

            // Load fonts from the content file.
            centuryGothic = Content.Load<SpriteFont>("centuryGothic16");
            resultsFont = Content.Load<SpriteFont>("resultsFont");

            // Get the 1x1 white rectangle texture.
            rectangle = new Texture2D(GraphicsDevice, 1, 1);
            rectangle.SetData(new[] { Color.White });

            // Initialise spriteBatch.
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

            // Load the chart.
            GameHandler.LoadSong(chartFolder);

            isPlaying = true;
        }



        /// <summary>
        /// A function to update the behaviour of the game every frame
        /// </summary>
        /// <param name="gameTime">The running time of the game.</param>
        protected override void Update(GameTime gameTime)
        {
            // Exit condition.
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                // Stop and dispose the audio player.
                audioPlayer.Stop();
                audioPlayer.Dispose();
                Exit();
            }

            // Remove this when done debugging. This is for testing purposes.
            if (Input.kbState.IsKeyDown(Keys.Space))
                GameHandler.HP = 0;

            // Update sprites and tags
            if (isPlaying)
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
                // Enough time has passed, move on.
                if (gameOverFrames <= 0)
                    // Move on to the results screen
                    resultsScreen = true;
            }

            // The delay is over. Start playing the audio.
            if (gameTime.TotalGameTime.TotalSeconds >= GameHandler.timeDelay 
                && audioPlayer.PlaybackState == PlaybackState.Stopped && isPlaying) // Ensures that this does not happen every frame.
            {
                audioPlayer.Init(audio);
                audioPlayer.Play();
            }

            // Once the song has ended, wait for an equivalent delay before ending gameplay.
            if (gameTime.TotalGameTime.TotalSeconds >= audio.TotalTime.TotalSeconds + 2 * GameHandler.timeDelay)
            {
                isPlaying = false;
                resultsScreen = true;
                GameHandler.speed = 0;
            }

            // Update input
            Input.Update();
            labelFrames--;

            // Check HP
            if (GameHandler.HP <= 0 && isPlaying)
            {
                // Game over, end the game.
                GameHandler.HP = 0;
                gameOverFrames = (int)(GameHandler.timeDelay * 60);
                isPlaying = false;
                audioPlayer.Stop();
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
            int rectWidth = (int)middle - 120;

            // Variable calculations for the drawing
            int numJudges = GameHandler.judgements.Sum();

            float pctWidth = centuryGothic.MeasureString("(00.00%)").X;

            float judgeCountX = 80 + rectWidth - pctWidth;
            float pctX = 90 + rectWidth - pctWidth;
            int textY = 25 - (int)(resultsFont.MeasureString("Test").Y / 2);


            //                                      //
            //  Draw the judgement counts and bars  //
            //                                      //

            // Variables to make rectangle size relative to screen size.
            float boundsY = (_graphics.PreferredBackBufferHeight / 2f) - 120;
            float rectBoundsY = boundsY / 6f;
            float rectSize = (3 * rectBoundsY) / 4;

            // Draw a bounding box.
            Rectangle statsBounds = new Rectangle(100, 100, _graphics.PreferredBackBufferWidth - 200, (int)boundsY);
            _spriteBatch.Draw(rectangle, statsBounds, Color.Black * 0.5f);

            // Draw the rectangle for each judgement type.
            for (int i = 0; i < 6; i++)
            {
                int baseY = 110 + (int)rectBoundsY * i;
                int bound = GameHandler.judgements[i] * rectWidth / numJudges;
                string percent = string.Format("({0:0.00}%)", 100 * GameHandler.judgements[i] / (float)numJudges);

                // Draw the base rectangle
                _spriteBatch.Draw(rectangle, new Rectangle(110, baseY, rectWidth, (int)rectSize), GameHandler.judgeColors[i] * 0.5f);
                // Fill it in with the appropriate percentage
                _spriteBatch.Draw(rectangle, new Rectangle(110, baseY, bound, (int)rectSize), GameHandler.judgeColors[i]);
                // Draw judgement text
                _spriteBatch.DrawString(resultsFont, GameHandler.judgeStrings[i], new Vector2(120, baseY + textY), Color.White);
                // Draw the judgement count
                _spriteBatch.DrawString(resultsFont, GameHandler.judgements[i].ToString(), new Vector2(judgeCountX - resultsFont.MeasureString(GameHandler.judgements[i].ToString()).X, baseY + textY), Color.White);
                // Draw the percentage
                _spriteBatch.DrawString(centuryGothic, percent, new Vector2(pctX, baseY + textY), Color.White);
            }

            //                              //
            // Draw chart and player stats  //
            //                              //

            Vector2 textBase = new Vector2((_graphics.PreferredBackBufferWidth * 0.5f) + 10, 110 + textY);
            Vector2 textDivision = new Vector2(0, rectBoundsY);

            float textHeight = resultsFont.MeasureString("Test").Y;

            _spriteBatch.DrawString(resultsFont, GameHandler.currentChart.title, textBase, Color.White);
            _spriteBatch.DrawString(resultsFont, "Charted by " + GameHandler.currentChart.author, textBase + textDivision, Color.White);
            
            // Draw percentage.

            

            //                      //
            // Draw the note graph  //
            //                      //

            // Draw the judgement list.
            Rectangle judgeBox = new Rectangle
                (100, _graphics.PreferredBackBufferHeight / 2, // Position
                _graphics.PreferredBackBufferWidth - 200, (_graphics.PreferredBackBufferHeight / 2) - 100); // Size

            int judgeMiddle = judgeBox.Height / 2;
            // The judgement box will cover all judgements up to Bad.
            double maxTiming = GameHandler.timeWindows[4];

            // Draw the base.
            _spriteBatch.Draw(rectangle, judgeBox, Color.Black);

            // Draw the perfect line.
            _spriteBatch.Draw(rectangle, new Rectangle(judgeBox.X, judgeBox.Y + judgeMiddle, judgeBox.Width, 2), GameHandler.judgeColors[0] * 0.5f);

            // Draw other judgement lines.
            for (int i = 1; i < 5; i++)
            {
                
                double percentage = GameHandler.timeWindows[i - 1] / maxTiming;
                int offset = (int)(percentage * judgeBox.Height / 2);
                // Get the color of the judgement line
                Color judgeLineColor = GameHandler.judgeColors[i];

                _spriteBatch.Draw(rectangle, new Rectangle(judgeBox.X, judgeBox.Y + judgeMiddle + offset, judgeBox.Width, 2), judgeLineColor * 0.5f);
                _spriteBatch.Draw(rectangle, new Rectangle(judgeBox.X, judgeBox.Y + judgeMiddle - offset, judgeBox.Width, 2), judgeLineColor * 0.5f);
            }


            // A variable for seeing how many divisions are in the entire chart.

            int max = GameHandler.measureDivions * GameHandler.currentChart.measures.Count();
            Vector2 prevPoint = Vector2.Zero;

            // Variables for taking averages of notes.
            int samplePoint = notesPerSample;
            List<int> noteSlice = new List<int>();

            // Draw every note.
            for(int i = 0; i < GameHandler.variations.Count; i++)
            {
                // Timing things.
                (double, double) noteHit = GameHandler.variations[i];
                double progressInSong = noteHit.Item1 / max;
                double Yoffset = noteHit.Item2 / maxTiming;

                // Get the judgement colour of the note
                Color judgeColor = GameHandler.judgeColors[5];
                for(int j = 0; j < 6; j++)
                {
                    if (Math.Abs(noteHit.Item2) <= GameHandler.timeWindows[j])
                    {
                        judgeColor = GameHandler.judgeColors[j];
                        break;
                    }
                }

                // Get the position of the note
                Point position = new Point(
                    judgeBox.X + (int)(judgeBox.Width * progressInSong),
                    judgeBox.Y + judgeMiddle + (int)(judgeBox.Height * Yoffset / 2));
               

                // If the note is too high or too low, place it on the edge.
                if (position.Y < judgeBox.Y) position.Y = judgeBox.Y;
                else if (position.Y > judgeBox.Y + judgeBox.Height) position.Y = judgeBox.Y + judgeBox.Height - 2;
                
                // 2x2 rectangle size.
                Rectangle judgeDotBox = new Rectangle(position, new Point(2, 2));

                // Draw the note.
                _spriteBatch.Draw(rectangle, judgeDotBox, judgeColor);


                // Take averages of the notes, to draw an average line.
                if (i != 0)
                {
                    if (--samplePoint == 0)
                    {
                        // At this point, add a new point for the average line.
                        position.Y = (int)noteSlice.Average();

                        // Connect it to the line.
                        DrawLine(prevPoint, position.ToVector2());
                        prevPoint = position.ToVector2();

                        // Reset the variable and clear the sample.
                        samplePoint = notesPerSample;
                        noteSlice.Clear();
                    }
                    else
                    {
                        // Add the note to the sample.
                        noteSlice.Add(position.Y);
                    }
                }
                else prevPoint = position.ToVector2();
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
            foreach (Tag tag in tags)
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

            string fpsString = string.Format("{0:00.0} FPS", 1 / gameTime.ElapsedGameTime.TotalSeconds);
            _spriteBatch.DrawString(resultsFont, fpsString, new Vector2(0, 0), Color.White);

            // Health
            Color hpColor = GameHandler.HP > 40 ? Color.Green : Color.Red;
            _spriteBatch.Draw(rectangle, new Rectangle(50, 50, 5*GameHandler.HP, 50), hpColor);

            // Mean
            if (GameHandler.variations.Count != 0)
            {
                string mean = string.Format("{0:0.00} ms", GameHandler.variations.Select(x => x.Item2).Average() * 1000);
                _spriteBatch.DrawString(centuryGothic, mean, new Vector2(rightX, 200), Color.White);
            }

            // Draw the accuracy.
            string accuracy = string.Format("{0:00.00}%", 100 * GameHandler.accuracy);
            _spriteBatch.DrawString(centuryGothic, accuracy, new Vector2(rightX, 250), Color.White);

            // Score
            _spriteBatch.DrawString(centuryGothic, "Score: " + GameHandler.score, new Vector2(rightX, 300), Color.White);
            
            // Judgement labels
            for (int i = 0; i < 6; i++)
            {
                _spriteBatch.DrawString(centuryGothic,
                    GameHandler.judgeStrings[i] + ": " + GameHandler.judgements[i],
                    new Vector2(rightX, 400 + i * judgeDiv),
                    Color.White);
            }

            // Tag centre
            int baseX = (GameHandler.arrowColumns[1] + GameHandler.arrowColumns[2]) / 2;
            _spriteBatch.Draw(rectangle, new Rectangle(baseX - 1, GameHandler.tagY, 2, GameHandler.tagSize.Y), Color.White);

            // End drawing
            _spriteBatch.End();
        }

        /// <summary>
        /// Draws a straight white line, 1 pixel thick, between two points.
        /// </summary>
        /// <param name="start">The point that the line should start at</param>
        /// <param name="end">The point that the line should finish at.</param>
        internal void DrawLine(Vector2 start, Vector2 end)
        {
            _spriteBatch.Draw(
                rectangle,
                start,
                null,
                Color.White,
                (float)Math.Atan2(end.Y - start.Y, end.X - start.X), // Get the gradient of the line.
                new Vector2(0f, (float)rectangle.Height / 2),        // Rotate around the centre of the line.
                new Vector2(Vector2.Distance(start, end), 1f),       // Scale the line to the distance between the two points.
                SpriteEffects.None,
                0f);
        }
    }
}
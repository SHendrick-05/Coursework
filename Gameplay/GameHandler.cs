using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Coursework.Gameplay
{
    internal static class GameHandler
    {
        internal static Chart currentChart;
        // The X positions of each arrow on the screen.
        internal static int[] arrowColumns = new int[4]
        {
            600, 700, 800, 900
        };
        // The keys the user has to press to hit arrows.
        internal static Keys[] hitKeys = new Keys[4]
        {
            Keys.A, Keys.S, Keys.L, Keys.OemSemicolon
        };
        // Timing windows for judgement boundaries
        internal static double[] timeWindows = new double[6]
        {
            0.022, // Perfect
            0.045, // Great
            0.090, // Good
            0.135, // OK
            0.180,  // Bad
            0.200
        };
        // An array of lists, divided by column
        internal static List<Arrow>[] arrows = new List<Arrow>[4]
        {
            new List<Arrow>(), new List<Arrow>(), new List<Arrow>(), new List<Arrow>()
        };
        // How fast the arrows should fall. (pixels per second)
        internal static double speed = 300;
        internal static double pixelsPerMeasure;
        // The score of the user
        internal static int score;
        // The health of the user
        internal static int HP;

        // Creates an arrow and adds it to the list.
        internal static void loadArrow(int Y, Dir dir, Point spriteCrop)
        {
            Hit arrow = new(Y, dir, spriteCrop);
            arrows[(int)dir].Add(arrow);
        }

        internal static void loadMine(int Y, Dir dir, Point spriteCrop)
        {
            Mine mine = new(Y, dir, spriteCrop);
            arrows[(int)dir].Add(mine);
        }

        internal static void loadHold(int Y, Dir dir, Point spriteCrop)
        {

        }

        /// <summary>
        /// The entry point for handling hits of any arrow type, including notes, mines and holds.
        /// </summary>
        /// <param name="arrow">The arrow that has been hit</param>
        /// <param name="distance">The pixel distance from the receptor</param>
        internal static void ArrowHit(Arrow arrow, float distance)
        {
            Type arrowType = arrow.GetType();
            // Note hit
            if (arrowType == typeof(Hit))
                HitNote(arrow as Hit, distance);
            // Mine hit
            else if (arrowType == typeof(Mine))
                MineHit(arrow as Mine);

        }
        /// <summary>
        /// A function that handles when an note is hit, and awards an appropriate score
        /// </summary>  
        /// <param name="arrow">The arrow class that has been hit</param>
        /// <param name="distance">The pixel distance from the receptor</param>
        /// <exception cref="Exception">Invalid judgement</exception>
        internal static void HitNote(Hit arrow, float distance)
        {
            // Get the time taken
            double time = distance / speed;
            // Find the appropriate judgement window
            int judgement = 5;
            for(int i = 0; i < 5; i++)
            {
                if (timeWindows[i] >= time)
                {
                    judgement = i;
                    break;
                }
            }
            // Award the points
            switch (judgement)
            {
                case 0: // Perfect
                    HP += 20;
                    SongPlayer.updateJudge(Color.Teal, "Perfect");
                    score += 300;
                    break;
                case 1: // Great
                    SongPlayer.updateJudge(Color.Green, "Great");
                    score += 200;
                    break;
                case 2: // Good
                    SongPlayer.updateJudge(Color.Blue, "Good");
                    score += 150;
                    break;
                case 3: // OK
                    SongPlayer.updateJudge(Color.Yellow, "OK");
                    score += 100;
                    break;
                case 4: // Bad
                    score += 50;
                    SongPlayer.updateJudge(Color.Red, "Bad");
                    break;
                case 5: // Miss
                    SongPlayer.updateJudge(Color.DarkRed, "Miss");
                    break;
                default:
                    throw new Exception();
            }
            // Remove the arrow.
            arrow.Deprecate();
        }

        internal static void MineHit(Mine mine)
        {
            HP -= 20;
            // Play the SFX
            var boom = SongPlayer.mineHit.CreateInstance();
            boom.Play();
            // Remove the mine
            mine.Deprecate();
        }


        /// <summary>
        /// Loads a chart from a folder path, playing the song and inserting the arrows.
        /// </summary>
        /// <param name="path">The folder of the chart.</param>
        internal static void loadSong(string path)
        {
            // Load the audio
            var uri = new Uri(path+@"\audio.mp3", UriKind.Relative);
            SongPlayer.audio = Song.FromUri(path + @"\audio.mp3", uri);

            // Load the chart
            string chartText = File.ReadAllText(path + @"\chart.json");
            Chart chart = JsonConvert.DeserializeObject<Chart>(chartText);

            // Assume 4/4.
            double measuresPerSecond = (chart.BPM) / (4 * 60.0);
            pixelsPerMeasure = speed / measuresPerSecond;
            double jumpGap = pixelsPerMeasure / 16;

            // The position of the receptor is height - 200, so the first note will hit 2 seconds after.
            double offsetPixels = chart.offset * 0.001 * speed;
            int Y = (int)Math.Round(SongPlayer._height - 200 - 2 * speed - offsetPixels);
            bool[] holds = new bool[4];
            // Loop over the measures in the song
            foreach (songNoteType[,] measure in chart.measures)
            {
                for (int j = 0; j < 16; j++)
                {
                    // Iterate over each column
                    for (int i = 0; i < 4; i++)
                    {
                        songNoteType note = measure[j, i];
                        // Load a hold body
                        if (holds[i])
                        {

                        }
                        switch(note)
                        {
                            // Load nothing
                            case songNoteType.NONE:
                                break;
                            // Load a hit arrow
                            case songNoteType.HIT:
                                loadArrow(Y, (Dir)i, new Point(0, 0));
                                break;
                            // Load a mine
                            case songNoteType.MINE:
                                loadMine(Y, (Dir)i, new Point(0, 0));
                                break;
                            /// Load a hold note start
                            case songNoteType.HOLDSTART:
                                holds[i] = true;
                                break;
                            // Load a hold note tail
                            case songNoteType.HOLDEND:
                                holds[i] = false;
                                break;
                            default:
                                break;
                        }
                    }
                    // Move up the Y, as we are moving on to the next division.
                    Y -= (int)Math.Round(jumpGap);
                }
            }
        }
    }
}

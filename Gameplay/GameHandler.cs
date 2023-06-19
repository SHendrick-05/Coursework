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
            0.011, // Perfect
            0.0225, // Great
            0.045, // Good
            0.0675, // OK
            0.090,  // Bad
            0.100 // Miss
        };
        // An array of lists, divided by column
        internal static List<Arrow>[] arrows = new List<Arrow>[4]
        {
            new List<Arrow>(), new List<Arrow>(), new List<Arrow>(), new List<Arrow>()
        };
        internal static Receptor[] receptors = new Receptor[4];
        /// <summary>
        /// How many pixels the notes should fall each second.
        /// </summary>
        internal static double speed = 800;
        internal static double pixelsPerMeasure;
        // How finely a measure is divided into notes
        internal static int measureDivions = 960;
        internal static float timeDelay = 3;
        // The score of the user
        internal static int score;
        // The health of the user
        internal static int HP = 100;
        /// <summary>
        /// A list of all hit notes, given by the time difference from the actual note time.
        /// </summary>
        internal static List<double> variations = new List<double>();
        // A list of the amount of judgements of each type
        internal static int[] judgements = new int[6];
        // The bounds of the window
        internal static Point bounds;
        /// <summary>
        /// Creates an arrow and adds it to the list
        /// </summary>
        internal static void loadArrow(int Y, Dir dir, Point spriteCrop)
        {
            Hit arrow = new(Y, dir, spriteCrop);
            arrows[(int)dir].Add(arrow);
        }

        /// <summary>
        /// Creates a mine and adds it to the list.
        /// </summary>
        internal static void loadMine(int Y, Dir dir, Point spriteCrop)
        {
            Mine mine = new(Y, dir, spriteCrop);
            arrows[(int)dir].Add(mine);
        }

        internal static void loadHold(int Y, Dir dir, Point spriteCrop)
        {
            throw new NotImplementedException();
            // TODO: Add hold notes.
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
            // Add this judgement to the lists.
            variations.Add(time);
            judgements[judgement]++;
            // Award the relevant points
            switch (judgement)
            {
                case 0: // Perfect
                    HP += 20;
                    SongPlayer.updateJudge(Color.Turquoise, "Perfect");
                    score += 300;
                    break;
                case 1: // Great
                    SongPlayer.updateJudge(Color.Goldenrod, "Great");
                    score += 200;
                    break;
                case 2: // Good
                    SongPlayer.updateJudge(Color.Green, "Good");
                    score += 150;
                    break;
                case 3: // OK
                    SongPlayer.updateJudge(Color.Blue, "OK");
                    score += 100;
                    break;
                case 4: // Bad
                    score += 50;
                    SongPlayer.updateJudge(Color.HotPink, "Bad");
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

        /// <summary>
        /// Event that occurs whenever a mine is hit
        /// </summary>
        /// <param name="mine">The mine that has been hit</param>
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
            currentChart = chart;

            // Assume 4/4.
            double measuresPerSecond = (chart.BPM) / (4 * 60.0);
            pixelsPerMeasure = speed / measuresPerSecond;
            double jumpGap = pixelsPerMeasure / measureDivions;

            // The position of the receptor is height - 200, so the first note will hit 2 seconds after.
            double offsetPixels = chart.offset * 0.001 * speed;
            int baseY = (int)Math.Round(bounds.Y - 200 - (timeDelay * speed) - offsetPixels);
            bool[] holds = new bool[4];
            // Loop over the measures in the song
            foreach (Dictionary<int, songNoteType>[] measure in chart.measures)
            {
                // Loop over every column
                for(int i = 0; i < 4; i++)
                {
                    foreach(KeyValuePair<int, songNoteType> note in measure[i])
                    {
                        // Get the Y position of the note
                        int noteY = baseY - (int)Math.Round(note.Key * jumpGap);
                        
                        switch(note.Value)
                        {
                            // Load a hit arrow
                            case songNoteType.HIT:
                                // Get the correct colour
                                int colourCrop;
                                if (note.Key % 240 == 0) colourCrop = 0; // 1 beat
                                else if (note.Key % 120 == 0) colourCrop = 1; // 1/2 beat
                                else if (note.Key % 80 == 0) colourCrop = 2; // 1/3 beat
                                else if (note.Key % 60 == 0) colourCrop = 3; // 1/4 beat
                                else if (note.Key % 40 == 0) colourCrop = 4; // 1/6 beat
                                else if (note.Key % 30 == 0) colourCrop = 5; // 1/8 beat
                                else if (note.Key % 20 == 0) colourCrop = 6; // 1/12 beat
                                else colourCrop = 7; // Other interval
                                loadArrow(noteY, (Dir)i, new Point(0, colourCrop));
                                break;
                            // Load a mine
                            case songNoteType.MINE:
                                loadMine(noteY, (Dir)i, new Point(0, 0));
                                break;
                            // Begin a LN
                            case songNoteType.HOLDSTART:
                                holds[i] = true;
                                break;
                            // End a LN
                            case songNoteType.HOLDEND:
                                holds[i] = false;
                                break;
                            // Nothing there.
                            default:
                                break;
                        }
                    }
                }

                // Set the base to the start of the next measure.
                baseY -= (int)Math.Round(pixelsPerMeasure);
            }
        }
    }
}

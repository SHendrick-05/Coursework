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
        /// <summary>
        /// The chart that is currently being played.
        /// </summary>
        internal static Chart currentChart;

        /// <summary>
        /// The X positions of each column on the screen, from left to right.
        /// </summary>
        internal static int[] arrowColumns = new int[4]
        {
            600, 700, 800, 900
        };

        /// <summary>
        /// The keys the user has to hit for each column, from left to right.
        /// </summary>
        internal static Keys[] hitKeys = new Keys[4]
        {
            Keys.A, Keys.S, Keys.L, Keys.OemSemicolon
        };

        /// <summary>
        /// The timing window boundaries, in seconds, for each type of judgement.
        /// </summary>
        internal static double[] timeWindows = new double[6]
        {
            0.011,  // Perfect
            0.0225, // Great
            0.045,  // Good
            0.0675, // OK
            0.090,  // Bad
            0.100   // Miss
        };

        /// <summary>
        /// The colour to be associated with each judgement type.
        /// </summary>
        internal static Color[] judgeColors = new Color[6]
        {
                Color.DarkTurquoise,// Perfect
                Color.Goldenrod,    // Great
                Color.Green,        // Good
                Color.Blue,         // OK
                Color.HotPink,      // Bad
                Color.DarkRed       // Miss
        };

        /// <summary>
        /// The text to be associated with each judgement type.
        /// </summary>
        internal static string[] judgeStrings = new string[6]
        {
                "Perfect",  // Perfect
                "Great",    // Great
                "Good",     // Good
                "OK",       // OK
                "Bad",      // Bad
                "Miss"      // Miss
        };

        /// <summary>
        /// The amount of points to be awarded for each judgement type.
        /// </summary>
        internal static int[] judgePoints = new int[6]
        {
            300,    // Perfect
            200,    // Great
            150,    // Good
            100,    // OK
            50,     // Bad
            0       // Miss
        };

        /// <summary>
        /// The size of an arrow.
        /// </summary>
        internal static Point arrowSize = new Point(64, 64);

        /// <summary>
        /// Every note/mine/hold that has been loaded will be in this array. Separated by column.
        /// </summary>
        internal static List<Arrow>[] arrows = new List<Arrow>[4]
        {
            new List<Arrow>(), new List<Arrow>(), new List<Arrow>(), new List<Arrow>()
        };

        

        /// <summary>
        /// The four receptors, from left to right.
        /// </summary>
        internal static Receptor[] receptors = new Receptor[4];

        /// <summary>
        /// The width and height of each judgement feedback tag.
        /// </summary>
        internal static Point tagSize = new Point(5, 20);

        /// <summary>
        /// The Y position of every judgement feedback tag.
        /// </summary>
        internal static int tagY = 500;

        /// <summary>
        /// The Y position of the judgement label.
        /// </summary>
        internal static int judgeLabelY = 600;

        /// <summary>
        /// How long each judgement feedback tag should be displayed for, in frames.
        /// </summary>
        internal static int tagFrames = 120;

        /// <summary>
        /// How many pixels the notes should fall each second.
        /// </summary>
        internal static double speed = 800;

        /// <summary>
        /// The height of each measure, in pixels.
        /// </summary>
        internal static double pixelsPerMeasure;

        /// <summary>
        /// How many sub-divisions are possible for each measure.
        /// </summary>
        internal static int measureDivions = 960;

        /// <summary>
        /// The time, in seconds, of delay between the application starting and the song starting.
        /// </summary>
        internal static float timeDelay = 3;

        /// <summary>
        /// How many points the user has scored.
        /// </summary>
        internal static int score;

        /// <summary>
        /// The health points of the user, from 0 to 100. If this hits 0, the user has failed.
        /// </summary>
        internal static int HP = 100;

        /// <summary>
        /// A list of all hit notes, given by the time difference from the actual note time.
        /// </summary>
        internal static List<double> variations = new List<double>();

        /// <summary>
        /// The amount of each class of judgement the user has scored during gameplay.
        /// </summary>
        internal static int[] judgements = new int[6];

        /// <summary>
        /// The width and height of the application bounds.
        /// </summary>
        internal static Point bounds;

        /// <summary>
        /// Creates a hit arrow and adds it to the list
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

        /// <summary>
        /// Creates a hold note. Not done yet.
        /// </summary>
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
        internal static void HitNote(Hit arrow, float distance)
        {
            // Get the time taken, in seconds.
            double time = distance / speed;
            // Find the appropriate judgement window
            int judgement = 5;
            for(int i = 0; i < 5; i++)
            {
                // Use the absolute value, so late and early judgements are treated equally.
                if (timeWindows[i] >= Math.Abs(time))
                {
                    judgement = i;
                    break;
                }
            }
            // Add this judgement to the lists.
            variations.Add(time);
            judgements[judgement]++;
            
            // If a perfect was hit, restore HP.
            if (judgement == 0)
                HP += 20;
            // If a note was missed, the player loses HP.
            else if (judgement == 5)
                HP -= 10;

            // Award the appropriate amount of points.
            score += judgePoints[judgement];

            // Display the judgement visually.
            Color judgeColor = judgeColors[judgement];
            SongPlayer.updateJudge(judgeColor, judgeStrings[judgement]);
            double offset = time * 1000;
            showTag(judgeColor, (int)Math.Round(offset));
            
            
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
        /// Creates a judgement feedback tag, and displays it on screen.
        /// </summary>
        /// <param name="color">The judgement color of the tag.</param>
        /// <param name="offset">How many pixels from the centre the tag should be displayed.</param>
        internal static void showTag(Color color, int offset)
        {
            int baseX = (arrowColumns[1] + arrowColumns[2] + arrowSize.X) / 2;
            Tag tag = new Tag(new Point(baseX + offset, tagY), tagSize, tagFrames, color);
            SongPlayer.addTag(tag);
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

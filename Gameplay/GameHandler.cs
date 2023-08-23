using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NAudio.Wave;

namespace Coursework.Gameplay
{
    /// <summary>
    /// The static class for handling most gameplay operations and calculations.
    /// </summary>
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
            0.0225,  // Perfect
            0.045, // Great
            0.090,  // Good
            0.135, // OK
            0.180,  // Bad
            0.200   // Miss
        };

        /// <summary>
        /// The timing window boundary for an LN.
        /// </summary>
        internal static double holdWindow = 0.250;

        /// <summary>
        /// The universal time window for hitting a mine.
        /// </summary>
        internal static double mineWindow = 0.075;

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
                "Marvellous",  // Perfect
                "Perfect",    // Great
                "Great",     // Good
                "Good",       // OK
                "Bad",      // Bad
                "Miss"      // Miss
        };

        /// <summary>
        /// The amount of points to be awarded for each judgement type.
        /// </summary>
        internal static int[] judgePoints = new int[6]
        {
            400,    // Perfect
            380,    // Great
            300,    // Good
            200,    // OK
            100,     // Bad
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
        /// The width and height of each judgement feedback tag.
        /// </summary>
        internal static Point tagSize = new Point(5, 20);

        /// <summary>
        /// The four receptors, from left to right.
        /// </summary>
        internal static Receptor[] receptors = new Receptor[4];

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
        /// The time, in seconds, of delay before the song starts, and before results screen after either failure or the song ends.
        /// </summary>
        internal static float timeDelay = 2;

        /// <summary>
        /// How many points the user has scored.
        /// </summary>
        internal static int score;

        /// <summary>
        /// The accuracy of gameplay, as a proportion, between 0 and 1, where 1 is perfect.
        /// </summary>
        internal static double accuracy { get
            {
                // If there are notes to base an accuracy off, then perform the calculation.
                if (judgements.Sum() > 0)
                {
                    // Divides by the maximum possible points
                    return (double)score/ (judgePoints[0] * judgements.Sum());
                }
                // No notes have been hit yet, just return 100%.
                else return 1;
            } }

        /// <summary>
        /// The health points of the user, from 0 to 100. If this hits 0, the user has failed.
        /// </summary>
        internal static int HP = 100;

        /// <summary>
        /// A list of all hit notes, given by the time difference from the actual note time. Given as a list of tuples (time in song, time offset hit).
        /// </summary>
        internal static List<(double, double)> variations = new List<(double, double)>();

        /// <summary>
        /// The amount of each class of judgement the user has scored during gameplay.
        /// </summary>
        internal static int[] judgements = new int[6];

        /// <summary>
        /// How many LN tails were hit successfully during gameplay.
        /// </summary>
        internal static int LNOK = 0;

        /// <summary>
        /// How many LN tails were missed during gameplay.
        /// </summary>
        internal static int LNNG = 0;

        /// <summary>
        /// The width and height of the application bounds.
        /// </summary>
        internal static Point bounds;

        /// <summary>
        /// Creates a hit arrow and adds it to the list
        /// </summary>
        internal static void LoadArrow(int Y, Dir dir, Point spriteCrop, int measureDiv, int measure)
        {
            Hit arrow = new(Y, dir, spriteCrop, measureDiv, measure);
            arrows[(int)dir].Add(arrow);
        }

        /// <summary>
        /// Creates a mine and adds it to the list.
        /// </summary>
        internal static void LoadMine(int Y, Dir dir, Point spriteCrop, int measureDiv, int measure)
        {
            Mine mine = new(Y, dir, spriteCrop, measureDiv, measure);
            arrows[(int)dir].Add(mine);
        }

        /// <summary>
        /// Creates a hold note.
        /// </summary>
        internal static void LoadHold(int startY, int endY, Dir dir, Point spriteCrop, int sMeasureDiv, int sMeasure, int eMeasureDiv, int eMeasure)
        {
            Hold hold = new(startY, endY, dir, spriteCrop, sMeasureDiv, sMeasure, eMeasureDiv, eMeasure);
            arrows[(int)dir].Add(hold);
        }

        /// <summary>
        /// The entry point for handling hits of any arrow type, including notes, mines and holds.
        /// </summary>
        /// <param name="arrow">The arrow that has been hit</param>
        /// <param name="distance">The pixel distance from the receptor</param>
        /// <param name="end">A boolean value representing whether the LN is being held or released</param>
        internal static void ArrowHit(Arrow arrow, float distance, bool end = false)
        {
            Type arrowType = arrow.GetType();
            // Note hit
            if (arrowType == typeof(Hit))
                HitNote(arrow as Hit, distance);
            // Mine hit
            else if (arrowType == typeof(Mine))
            {
                if (Math.Abs(distance / speed) < mineWindow)
                    MineHit(arrow as Mine);
            }
            // LN hit
            else if(arrowType == typeof(Hold))
            {
                LNHit(arrow as Hold, distance, end);
            }
        }

        /// <summary>
        /// A function that handles when LNs are hit, both the start and end.
        /// </summary>
        /// <param name="LN">The LN that has been held or released</param>
        /// <param name="distance">The pixel distance from the receptor</param>
        /// <param name="end">A boolean value representing whether the LN is being held or released</param>
        internal static void LNHit(Hold LN, float distance, bool end )
        {
            // If end, award a judgement and deprecate the LN
            if (end) 
            {
                awardLNJudgement(distance);
                LN.Deprecate();
            }
            // If start, award a judgement and hide the hit part.
            else
            {
                awardJudgement(LN.measure * measureDivions + LN.measureDiv, distance);
                LN.clearTexture();
            }
        }

        /// <summary>
        /// Handles the tail hits of an LN
        /// </summary>
        /// <param name="distance">The pixel distance from the end.</param>
        internal static void awardLNJudgement(float distance)
        {
            double time = distance / speed;
            if (time > holdWindow)
            {
                LNNG++;
            }
            else
                LNOK++;
        }

        /// <summary>
        /// A function that takes a judgement and awards a score.
        /// </summary>
        /// <param name="divisionCount">How many measure divisions (including full measures) into the song the note was hit</param>
        /// <param name="distance">The distance from the recetor the note was hit at.</param>
        internal static void awardJudgement(int divisionCount, float distance)
        {
            // Get the time taken, in seconds.
            double time = distance / speed;
            // Find the appropriate judgement window
            int judgement = 5;
            for (int i = 0; i < 5; i++)
            {
                // Use the absolute value, so late and early judgements are treated equally.
                if (timeWindows[i] >= Math.Abs(time))
                {
                    judgement = i;
                    break;
                }
            }

            // Add this judgement to the lists.
            variations.Add((divisionCount, time));
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
            songPlayer.updateJudge(judgeColor, judgeStrings[judgement]);
            double offset = time * 1000;
            ShowTag(judgeColor, (int)Math.Round(offset));
        }

        /// <summary>
        /// A function that handles when an note is hit.
        /// </summary>  
        /// <param name="arrow">The arrow class that has been hit</param>
        /// <param name="distance">The pixel distance from the receptor</param>
        internal static void HitNote(Hit arrow, float distance)
        {
            // Handle the judgement.
            awardJudgement(arrow.measure * measureDivions + arrow.measureDiv, distance);
            
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
            songPlayer.mineHit.Play();
            // Remove the mine
            mine.Deprecate();
        }

        /// <summary>
        /// Creates a judgement feedback tag, and displays it on screen.
        /// </summary>
        /// <param name="color">The judgement color of the tag.</param>
        /// <param name="offset">How many pixels from the centre the tag should be displayed.</param>
        internal static void ShowTag(Color color, int offset)
        {
            int baseX = (arrowColumns[1] + arrowColumns[2]) / 2;
            Tag tag = new Tag(new Point(baseX + offset, tagY), tagSize, tagFrames, color);
            songPlayer.addTag(tag);
        }

        /// <summary>
        /// Loads a chart from a folder path, playing the song and inserting the arrows.
        /// </summary>
        /// <param name="path">The folder of the chart.</param>
        internal static void LoadSong(string path)
        {
            // Load the audio
            songPlayer.audio = new Mp3FileReader(path + @"\audio.mp3");

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
            (int, int, int)[] startMeasures = new (int, int, int)[4];

            // Loop over the measures in the song
            for(int j = 0; j < chart.measures.Count; j++)
            {
                Dictionary<int, songNoteType>[] measure = chart.measures[j]; ;
                // Loop over every column
                for(int i = 0; i < 4; i++)
                {
                    foreach(KeyValuePair<int, songNoteType> note in measure[i])
                    {
                        // Get the Y position of the note
                        int noteY = baseY - (int)Math.Round(note.Key * jumpGap);

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

                        switch (note.Value)
                        {
                            // Load a hit arrow
                            case songNoteType.HIT:
                                LoadArrow(noteY, (Dir)i, new Point(0, colourCrop), note.Key, j);
                                break;

                            // Load a mine
                            case songNoteType.MINE:
                                LoadMine(noteY, (Dir)i, new Point(0, 0), note.Key, j);
                                break;

                            // Begin a LN
                            case songNoteType.HOLDSTART:
                                holds[i] = true;
                                startMeasures[i] = new(noteY, note.Key, j);
                                break;

                            // End a LN
                            case songNoteType.HOLDEND:
                                holds[i] = false;
                                LoadHold(startMeasures[i].Item1, noteY, (Dir)i, new Point(0, colourCrop), startMeasures[i].Item2, startMeasures[i].Item3, note.Key, j);
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


        /// <summary>
        /// Initialises gameplay variables to their default values.
        /// </summary>
        internal static void InitVariables()
        {
            // Set variables to initial values.
            HP = 100;
            score = 0;
            variations.Clear();
            currentChart = null;
            judgements = new int[6] {0, 0, 0, 0, 0, 0};
            LNOK = 0;
            LNNG = 0;


            // Get the user's preferred speed. If the player is not logged in, use the default speed of 800.
            if (Users.loggedInUser != null)
            {
                speed = Users.loggedInUser.Speed;
            }
            else speed = 800;

            // Clear all arrows.
            for (int i = 0; i < 4; i++)
            {
                arrows[i].Clear();
            }
        }
    }
}

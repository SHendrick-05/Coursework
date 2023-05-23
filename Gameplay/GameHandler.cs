using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        internal static int score;

        // Creates an arrow and adds it to the list.
        internal static void loadArrow(int Y, Dir dir, Point spriteCrop)
        {
            Arrow arrow = new(Y, dir, spriteCrop);
            arrows[(int)dir].Add(arrow);
        }

        internal static void loadMine(int Y, Dir dir, Point spriteCrop)
        {
            
        }

        internal static void arrowHit(Arrow arrow, float distance)
        {
            double time = distance / speed;
            int judgement = 5;
            for(int i = 0; i < 5; i++)
            {
                if (timeWindows[i] >= time)
                {
                    judgement = i;
                    break;
                }
            }
            switch (judgement)
            {
                case 0: // Perfect
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
            arrow.Deprecate();
        }

        internal static void loadSong(string path)
        {
            // Load the audio
            var uri = new Uri(path+@"\audio.mp3", UriKind.Relative);
            SongPlayer.audio = Song.FromUri(path + @"\audio.mp3", uri);

            // Load the chart
            string chartText = File.ReadAllText(path + @"\chart.json");
            Chart chart = JsonConvert.DeserializeObject<Chart>(chartText);

            // 
            double measuresPerSecond = chart.BPM / 60.0;
            pixelsPerMeasure = speed / measuresPerSecond;
            double jumpGap = pixelsPerMeasure / 16;


            // The position of the receptor is height - 200, so the first note will hit 2 seconds after.
            double offsetPixels = chart.offset * 0.001 * speed;
            int Y = (int)Math.Round(SongPlayer._height - 200 - 2 * speed - offsetPixels);

            // Loop over the measures in the song
            foreach (songNoteType[,] measure in chart.measures)
            {
                for (int j = 0; j < 16; j++)
                {
                    // Iterate over each column
                    for (int i = 0; i < 4; i++)
                    {
                        songNoteType note = measure[j, i];
                        switch(note)
                        {
                            case songNoteType.NONE:
                                break;
                            case songNoteType.HIT:
                                loadArrow(Y, (Dir)i, new Point(0, 0));
                                break;
                            case songNoteType.MINE:
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

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Coursework
{
    /// <summary>
    /// Static class handling the management of scores.
    /// </summary>
    internal static class Scores
    {
        /// <summary>
        /// The relative path to the file where scores are stored.
        /// </summary>
        static string path = @"Storage\scores.json";

        /// <summary>
        /// The percentage accuracies needed for each letter grade.
        /// </summary>
        internal static double[] gradeBoundaries = new double[]
        {
            0.9975, // AAA
            0.93, // AA
            0.8, // A
            0.7, // B
            0.6 // C
            // Below 60% is a D.
        };

        /// <summary>
        /// The dictionary of all scores, sorted by chart ID.
        /// </summary>
        public static Dictionary<uint, List<Score>> scoreDict;

        /// <summary>
        /// Adds a new score to the dictionary, before saving.
        /// </summary>
        /// <param name="score">The score to add.</param>
        internal static void AddScore(Score score)
        {
            if (scoreDict.ContainsKey(score.chartID))
            {
                scoreDict[score.chartID].Add(score);
            }
            else
            {
                scoreDict.Add(score.chartID, new List<Score>() { score });
            }
            SaveScores();
            
        }

        /// <summary>
        /// Save the current scores to the .json file.
        /// </summary>
        internal static void SaveScores()
        {
            string text = JsonConvert.SerializeObject(scoreDict);
            File.WriteAllText(path, text);
        }

        /// <summary>
        /// Loads all scores from the file, and creates a file if it doesn't exist.
        /// </summary>
        internal static void LoadScores()
        {
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                scoreDict = JsonConvert.DeserializeObject<Dictionary<uint, List<Score>>>(text);
            }
            else
            {
                scoreDict = new Dictionary<uint, List<Score>>();
                SaveScores();
            }
        }
 
        /// <summary>
        /// A static constructor to initialise the score list.
        /// </summary>
        static Scores()
        {
            LoadScores();
        }
    }

    /// <summary>
    /// A class representing an individual score.
    /// </summary>
    public class Score
    {
        /// <summary>
        /// The username of the person who set the score.
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// The ID of the chart the score was set on.
        /// </summary>
        public uint chartID { get; set; }
        /// <summary>
        /// A list of the amount of each type of judgement.
        /// </summary>
        public int[] Judgements { get; set; }
        /// <summary>
        /// The accuracy, as a double from 0 to 1.
        /// </summary>
        public double Accuracy { get; set; }
        /// <summary>
        /// A bool representing whether the chart was completely fully without failing.
        /// </summary>
        public bool Passed { get; set; }
        /// <summary>
        /// The letter grade corresponding to the score.
        /// </summary>
        public Grade grade
        {
            get
            {
                if (!Passed) return Grade.F;
                else
                    for (int i = 0; i < 5; i++)
                    {
                        if (Accuracy > Scores.gradeBoundaries[i])
                            return (Grade)i;
                    }
                return Grade.D;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public Score(string user, uint ID, int[] judgements, double accuracy, bool passed)
        {
            User = user;
            Judgements = judgements;
            Accuracy = accuracy;
            chartID = ID;
            Passed = passed;
        }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Coursework
{
    internal static class Scores
    {
        internal static string scorePath = @"Storage\scores.json";

        internal static List<Score> scoreList;

        internal static void AddScore(Score score)
        {

        }

        // Converts the dictionary into a json string, and then saves it
        internal static void SaveScores()
        {
            string serialisedScores = JsonConvert.SerializeObject(scoreList, Formatting.Indented);
            File.WriteAllText(scorePath, serialisedScores);
        }
        // Reads the json from the file, and converts it into a dictionary
        internal static void LoadScores()
        {
            string serialisedScores = File.ReadAllText(scorePath);
            // To ensure the cast to dynamic will work, make sure the user does not have any access to modify scores.json
            scoreList = JsonConvert.DeserializeObject<dynamic>(serialisedScores);
        }

        // Init the scoreList
        static Scores()
        {
            if (File.Exists(scorePath))
            {
                LoadScores();
            }
            else
            {
                scoreList = new List<Score>();
                SaveScores();
            }
        }
    }
    internal class Score
    {
        internal string User { get; set; }
        internal Score(string user)
        {
            User = user;
        }
    }
}

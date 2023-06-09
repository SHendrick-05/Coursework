using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Coursework
{
    internal static class Scores
    {

        internal static Dictionary<uint, List<Score>> scoreDict;

        internal static void AddScore(Chart chart, Score score)
        {
            if (scoreDict.ContainsKey(chart.ID))
            {
                scoreDict[chart.ID].Add(score);
            }
            else
            {
                scoreDict.Add(chart.ID, new List<Score>() { score });
            }
            
        }


        // Init the scoreList
        static Scores()
        {
            scoreDict = new Dictionary<uint, List<Score>>();
        }
    }
    internal class Score
    {
        internal string User { get; set; }
        internal int[] Judgements { get; set; }
        internal float Accuracy { get; set; }
        internal Score(string user)
        {
            User = user;
            Judgements = new int[6];
        }
    }
}

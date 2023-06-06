using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    internal static class Charts
    {
        internal static Chart loadChart(string path)
        {
            throw new NotImplementedException();
        }
        internal static void saveChart(Chart song)
        {

        }
    }
    /// <summary>
    /// A class representing each mapped song in the game.
    /// </summary>
    public class Chart
    {
        public string title;
        /// <summary>
        /// The beats per minute of the song.
        /// </summary>
        public double BPM;
        /// <summary>
        /// The offset of the song, in milliseconds.
        /// </summary>
        public double offset;
        /// <summary>
        /// A list of all the notes in the song, broken down into measures.
        /// </summary>
        public List<Dictionary<int, songNoteType>[]> measures;
        /// <summary>
        /// The username of the author of the chart.
        /// </summary>
        public string author;
        public Chart()
        {
            measures = new List<Dictionary<int, songNoteType>[]>();
        }
    }
}

// Measure = 960 long
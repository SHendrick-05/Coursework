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
        public List<songNoteType[,]> measures;
        public Chart()
        {
            measures = new List<songNoteType[,]>();
        }
    }
}

// Measure = 4x16 array [i,j], where i is the position in the measure, and j is the column (Dir)
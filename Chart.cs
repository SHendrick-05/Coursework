using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace Coursework
{
    /// <summary>
    /// A class representing each mapped song in the game.
    /// </summary>
    public class Chart
    {
        /// <summary>
        /// A list of all Chart IDs.
        /// </summary>
        public static List<uint> IDs;

        /// <summary>
        /// A unique identifier for the song.
        /// </summary>
        public uint ID;

        /// <summary>
        /// The title of the song.
        /// </summary>
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
        /// An absolute path to the folder containing the image and audio.
        /// </summary>
        public string folderPath;

        /// <summary>
        /// A list of all the notes in the song, broken down into measures. A measure divides up to 960 times.
        /// </summary>
        public List<Dictionary<int, songNoteType>[]> measures;

        /// <summary>
        /// The username of the author of the chart.
        /// </summary>
        public string author;
        
        /// <summary>
        /// The constructor function, which will generate an empty list of measures.
        /// </summary>
        public Chart()
        {
            measures = new List<Dictionary<int, songNoteType>[]>();
            Random rd = new Random();
            do
            {
                ID = (uint)rd.Next(1000000);
            } while (IDs.Contains(ID));
            IDs.Add(ID);
        }
    }
}

// Measure = 960 long
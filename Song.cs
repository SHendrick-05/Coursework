using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    public class Song
    {
        public string name;
        public string description;
        public double BPM;
        public List<songNoteType[,]> measures;
        public Song()
        {
            measures = new List<songNoteType[,]>();
        }
    }
}

// Measure = 4x16 array [i,j], where i is the position in the measure, and j is the column (Dir)
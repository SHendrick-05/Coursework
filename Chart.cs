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
    public class Chart
    {
        public string title;
        public string description;
        public double BPM;
        public List<songNoteType[,]> measures;
        public Chart()
        {
            measures = new List<songNoteType[,]>();
        }
    }
}

// Measure = 4x16 array [i,j], where i is the position in the measure, and j is the column (Dir)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    /// <summary>
    /// Enum representing the direction an arrow or receptor is facing.
    /// </summary>
    enum Dir
    {
        LEFT,
        DOWN,
        UP,
        RIGHT
    }

    /// <summary>
    /// Differential enum used for loading and saving charts.
    /// </summary>
    public enum songNoteType
    {
        NONE,
        HIT,
        MINE,
        HOLDSTART,
        HOLDEND
    }

    /// <summary>
    /// Reprenting the difficulty of the chart
    /// </summary>
    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD
    }
}

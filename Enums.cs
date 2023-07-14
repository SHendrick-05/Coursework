namespace Coursework
{
    /// <summary>
    /// Enum representing the direction an arrow or receptor is facing.
    /// </summary>
    enum Dir
    {
        /// <summary>
        /// 0.5PI rad
        /// </summary>
        LEFT,

        /// <summary>
        /// 0 rad
        /// </summary>
        DOWN,

        /// <summary>
        /// PI rad
        /// </summary>
        UP,

        /// <summary>
        /// -0.5PI rad
        /// </summary>
        RIGHT
    }

    /// <summary>
    /// Differential enum used for loading and saving charts.
    /// </summary>
    public enum songNoteType
    {
        /// <summary>
        /// A hit arrow, that should be pressed once.
        /// </summary>
        HIT,

        /// <summary>
        /// A mine arrow, that needs to be avoided.
        /// </summary>
        MINE,

        /// <summary>
        /// The start of a hold body, where the key must be held down for the entire duration. This is where the key should be pressed.
        /// </summary>
        HOLDSTART,

        /// <summary>
        /// The end of a hold body, this is where the key should be released.
        /// </summary>
        HOLDEND
    }

    /// <summary>
    /// Reprenting the difficulty of the chart
    /// </summary>
    public enum Difficulty
    {
        /// <summary>
        /// A chart that is easy to play, for people newer to the game. This difficulty will generally have slower streams.
        /// </summary>
        EASY,

        /// <summary>
        /// A medium chart, this difficulty will tend to have faster streams, with 1/4 notes.
        /// </summary>
        MEDIUM,

        /// <summary>
        /// A hard chart, for experienced players, where chords are introduced as part of a jumpstream.
        /// </summary>
        HARD
    }
}

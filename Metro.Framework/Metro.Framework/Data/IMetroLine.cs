namespace Metro.Framework.Data
{
    /// <summary>
    /// Common properties for all metro line types (readonly)
    /// </summary>
    public interface IMetroLine
    {
        /// <summary>
        /// Name of the metro line
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Source station
        /// </summary>
        string SourceStation { get; }

        /// <summary>
        /// Destination Station
        /// </summary>
        string DestinationStation { get; }

        /// <summary>
        /// Whether this line has Saturday service
        /// </summary>
        bool SaturdayService { get; }

        /// <summary>
        /// Whether this line has Sunday/Holiday service
        /// </summary>
        bool SundayHolidayService { get; }

        /// <summary>
        /// Year line went into service
        /// </summary>
        int YearOfOperation { get; }
    }

    /// <summary>
    /// Common properties for all metro line types (writeable)
    /// </summary>
    public interface IMetroLineWriteable
    {
        /// <summary>
        /// Name of the metro line
        /// </summary>
        string Name { set; }

        /// <summary>
        /// Source station
        /// </summary>
        string SourceStation { set; }

        /// <summary>
        /// Destination Station
        /// </summary>
        string DestinationStation { set; }

        /// <summary>
        /// Whether this line has Saturday service
        /// </summary>
        bool SaturdayService { set; }

        /// <summary>
        /// Whether this line has Sunday/Holiday service
        /// </summary>
        bool SundayHolidayService { set; }

        /// <summary>
        /// Year line went into service
        /// </summary>
        int YearOfOperation { set; }
    }
}

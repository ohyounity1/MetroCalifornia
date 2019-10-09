namespace Metro.Framework.Data
{
    /// <summary>
    /// Implementation of readonly <see cref="IMetroLine"/>
    /// </summary>
    public abstract class MetroLineDetails : IMetroLine
    {
        /// <summary>
        /// <see cref="IMetroLine.DestinationStation"/>
        /// </summary>
        public string DestinationStation
        {
            get;
        }

        /// <summary>
        /// <see cref="IMetroLine.Name"/>
        /// </summary>
        public string Name
        {
            get;
        }

        /// <summary>
        /// <see cref="IMetroLine.SaturdayService"/>
        /// </summary>
        public bool SaturdayService
        {
            get;
        }

        /// <summary>
        /// <see cref="IMetroLine.SourceStation"/>
        /// </summary>
        public string SourceStation
        {
            get;
        }

        /// <summary>
        /// <see cref="IMetroLine.SundayHolidayService"/>
        /// </summary>
        public bool SundayHolidayService
        {
            get;
        }

        /// <summary>
        /// <see cref="IMetroLine.YearOfOperation"/>
        /// </summary>
        public int YearOfOperation
        {
            get;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MetroLineDetails"/>
        /// </summary>
        /// <param name="name">Line name</param>
        /// <param name="destinationStation">Destination station</param>
        /// <param name="sourceStation">Source station</param>
        /// <param name="saturdayService">Saturday Service?</param>
        /// <param name="sundayService">Sunday/Holiday Service?</param>
        /// <param name="yearOfOperation">Year of Operation</param>
        public MetroLineDetails(string name,
            string destinationStation,
            string sourceStation, 
            bool saturdayService,
            bool sundayService,
            int yearOfOperation)
        {
            Name = name;
            SourceStation = sourceStation;
            DestinationStation = destinationStation;
            SaturdayService = saturdayService;
            SundayHolidayService = sundayService;
            YearOfOperation = yearOfOperation;
        }
    }

    /// <summary>
    /// Implementation of read/write <see cref="IMetroLine"/> / <see cref="IMetroLineWriteable"/>
    /// </summary>
    public abstract class MetroLineDetailsReaderHelper : IMetroLine, IMetroLineWriteable
    {
        /// <summary>
        /// <see cref="IMetroLineWriteable.DestinationStation"/>
        /// </summary>
        public string DestinationStation
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="IMetroLineWriteable.Name"/>
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="IMetroLineWriteable.SaturdayService"/>
        /// </summary>
        public bool SaturdayService
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="IMetroLineWriteable.SourceStation"/>
        /// </summary>
        public string SourceStation
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="IMetroLineWriteable.SundayHolidayService"/>
        /// </summary>
        public bool SundayHolidayService
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="IMetroLineWriteable.YearOfOperation"/>
        /// </summary>
        public int YearOfOperation
        {
            get;
            set;
        }
    }
}

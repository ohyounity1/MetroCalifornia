using System.Collections.Generic;

namespace Metro.Data
{
    /// <summary>
    /// Represents a metro station
    /// </summary>
    public class MetroStationDetails : IMetroStationDetails
    {
        /// <summary>
        /// Name of the station
        /// </summary>
        public string StationName { get; }

        /// <summary>
        /// Does this train get served by express trains?
        /// </summary>
        public bool IsExpressStation { get; }

        /// <summary>
        /// Lines that service this station
        /// </summary>
        //public IEnumerable<MetroLineDetails> ServingLines { get; }

        /// <summary>
        /// Open on Saturday?
        /// </summary>
        public bool SaturdayService { get; }

        /// <summary>
        /// Open on Sunday/Holidays?
        /// </summary>
        public bool SundayHolidayService { get; }

        /// <summary>
        /// Has disabled access?
        /// </summary>
        public bool IsAccessible { get; }

        /// <summary>
        /// Parking is available?
        /// </summary>
        public bool HasParking { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MetroStationDetails"/>
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="isExpressStation"></param>
        /// <param name="servingLines"></param>
        /// <param name="saturdayService"></param>
        /// <param name="sundayHolidayService"></param>
        /// <param name="isAccessible"></param>
        /// <param name="hasParking"></param>
        public MetroStationDetails(string stationName,
            bool isExpressStation,
            //IEnumerable<MetroLineDetails> servingLines,
            bool saturdayService,
            bool sundayHolidayService,
            bool isAccessible,
            bool hasParking)
        {
            StationName = stationName;
            IsExpressStation = isExpressStation;
            //ServingLines = servingLines;
            SaturdayService = saturdayService;
            SundayHolidayService = sundayHolidayService;
            IsAccessible = IsAccessible;
            HasParking = hasParking;
        }
    }
}

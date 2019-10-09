using System.Collections.Generic;

namespace Metro.Data
{
    public interface IMetroStationDetails
    {
        /// <summary>
        /// Name of the station
        /// </summary>
        string StationName { get; }

        /// <summary>
        /// Does this train get served by express trains?
        /// </summary>
        bool IsExpressStation { get; }

        /// <summary>
        /// Lines that service this station
        /// </summary>
        //IEnumerable<MetroLineDetails> ServingLines { get; }

        /// <summary>
        /// Open on Saturday?
        /// </summary>
        bool SaturdayService { get; }

        /// <summary>
        /// Open on Sunday/Holidays?
        /// </summary>
        bool SundayHolidayService { get; }

        /// <summary>
        /// Has disabled access?
        /// </summary>
        bool IsAccessible { get; }

        /// <summary>
        /// Parking is available?
        /// </summary>
        bool HasParking { get; }
    }
}

using System;

using BaseReadonly = Metro.Framework.Data.MetroLineDetails;
using BaseWriteonly = Metro.Framework.Data.MetroLineDetailsReaderHelper;

namespace Metro.MetroLink.Data
{
    /// <summary>
    /// Implementation of <see cref="IMetroLinkLine"/>
    /// </summary>
    public class MetroLinkDetails : BaseReadonly, IMetroLinkLine
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MetroLinkDetails"/>
        /// </summary>
        /// <param name="lineEndTime">line end time</param>
        /// <param name="lineStartTime">line start time</param>
        /// <param name="trainType">Train type</param>
        /// <param name="lineImage">line image</param>
        /// <param name="name">Line name</param>
        /// <param name="destinationStation">Destination station</param>
        /// <param name="sourceStation">Source station</param>
        /// <param name="saturdayService">Saturday service</param>
        /// <param name="sundayService">Sunday service</param>
        /// <param name="yearOfOperation">Year of Operation</param>
        public MetroLinkDetails(DateTime lineEndTime,
            DateTime lineStartTime,
            TrainType trainType,
            LineImage lineImage,
            string name, 
            string destinationStation,
            string sourceStation,
            bool saturdayService, 
            bool sundayService, 
            int yearOfOperation) : base(name, destinationStation, sourceStation, saturdayService, sundayService, yearOfOperation)
        {
            LineEndTime = lineEndTime;
            LineImage = lineImage;
            TrainType = trainType;
            LineStartTime = lineStartTime;
        }

        /// <summary>
        /// <see cref="IMetroLinkLine.LineEndTime"/>
        /// </summary>
        public DateTime LineEndTime
        {
            get;
        }
        /// <summary>
        /// <see cref="IMetroLinkLine.LineImage"/>
        /// </summary>
        public LineImage LineImage
        {
            get;
        }
        /// <summary>
        /// <see cref="IMetroLinkLine.TrainType"/>
        /// </summary>
        public TrainType TrainType
        {
            get;
        }
        /// <summary>
        /// <see cref="IMetroLinkLine.LineStartTime"/>
        /// </summary>
        public DateTime LineStartTime
        {
            get;
        }
    }

    /// <summary>
    /// Implementation of <see cref="IMetroLinkLineWriteable"/> and <see cref="IMetroLinkLine"/> useful for storing data as it is read in
    /// and then can be converted to <see cref="MetroLinkDetails"/>
    /// </summary>
    public class MetroLinkDetailsReaderHelper : BaseWriteonly, IMetroLinkLineWriteable, IMetroLinkLine
    {
        /// <summary>
        /// <see cref="IMetroLinkLineWriteable.LineEndTime"/>
        /// </summary>
        public DateTime LineEndTime
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="IMetroLinkLineWriteable.LineImage"/>
        /// </summary>
        public LineImage LineImage
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="IMetroLinkLineWriteable.LineStartTime"/>
        /// </summary>
        public DateTime LineStartTime
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="IMetroLinkLineWriteable.TrainType"/>
        /// </summary>
        public TrainType TrainType
        {
            get;
            set;
        }

        /// <summary>
        /// Convert from a <see cref="MetroLinkDetailsReaderHelper"/> to <see cref="MetroLinkDetails"/>
        /// </summary>
        /// <param name="source">Source data information</param>
        public static explicit operator MetroLinkDetails(MetroLinkDetailsReaderHelper source)
        {
            // Create details object
            return new MetroLinkDetails(
                source.LineEndTime,
                source.LineStartTime,
                source.TrainType,
                source.LineImage,
                source.Name,
                source.DestinationStation,
                source.SourceStation,
                source.SaturdayService,
                source.SundayHolidayService,
                source.YearOfOperation);
        }
    }
}

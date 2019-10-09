using System.Windows.Media;

using BaseReadonly = Metro.Framework.Data.MetroLineDetails;
using BaseWriteonly = Metro.Framework.Data.MetroLineDetailsReaderHelper;

namespace Modules.Metro.MetroLines.Data
{
    /// <summary>
    /// Represents a metro line
    /// </summary>
    public class MetroLineDetails : BaseReadonly, IMetroLine
    {
        /// <summary>
        /// <see cref="IMetroLine.LineColor"/>
        /// </summary>
        public Color LineColor { get; }

        /// <summary>
        /// <see cref="IMetroLine.LineLetter"/>
        /// </summary>
        public char LineLetter { get; }

        /// <summary>
        /// <see cref="IMetroLine.PrincipalDirection"/>
        /// </summary>
        public LineType PrincipalDirection { get; }
        
        /// <summary>
        /// <see cref="IMetroLine.ExpressService"/>
        /// </summary>
        public bool ExpressService { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MetroLineDetails"/>
        /// </summary>
        /// <param name="name">Name of line</param>
        /// <param name="lineColor">Line color</param>
        /// <param name="lineLetter">Line letter</param>
        /// <param name="sourceStation">Source station</param>
        /// <param name="destinationStation">Destination station</param>
        /// <param name="saturdayService">Saturday service?</param>
        /// <param name="sundayHolidayService">Sunday/Holiday service?</param>
        /// <param name="yearOfOperation">Year of operation</param>
        /// <param name="principalDirection">Principal direction of line</param>
        /// <param name="expressLine">Is this an express line?</param>
        public MetroLineDetails(string name, 
            Color lineColor, 
            char lineLetter,
            string sourceStation, 
            string destinationStation,
            bool saturdayService, 
            bool sundayHolidayService,
            int yearOfOperation,
            LineType principalDirection,
            bool expressLine) : base(name, destinationStation, sourceStation, saturdayService, sundayHolidayService, yearOfOperation)
        {
            LineColor = lineColor;
            LineLetter = lineLetter;
            PrincipalDirection = principalDirection;
            ExpressService = expressLine;
        }
    }

    /// <summary>
    /// Extension of <see cref="BaseWriteonly"/> and implements <see cref="IMetroLine"/> / <see cref="IMetroLineWritable"/>
    /// </summary>
    public class MetroLineDetailsReaderHelper : BaseWriteonly, IMetroLine, IMetroLineWritable
    {
        /// <summary>
        /// <see cref="IMetroLineWritable.ExpressService"/>
        /// </summary>
        public bool ExpressService
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="IMetroLineWritable.LineColor"/>
        /// </summary>
        public Color LineColor
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="IMetroLineWritable.LineLetter"/>
        /// </summary>
        public char LineLetter
        {
            get;
            set;
        }

        /// <summary>
        /// <see cref="IMetroLineWritable.PrincipalDirection"/>
        /// </summary>
        public LineType PrincipalDirection
        {
            get;
            set;
        }

        /// <summary>
        /// Convert from <see cref="MetroLineDetailsReaderHelper"/> to <see cref="MetroLineDetails"/>
        /// </summary>
        /// <param name="source"></param>
        public static explicit operator MetroLineDetails(MetroLineDetailsReaderHelper source)
        {
            return new MetroLineDetails(source.Name, 
                source.LineColor, 
                source.LineLetter, 
                source.SourceStation, 
                source.DestinationStation, 
                source.SaturdayService, 
                source.SundayHolidayService, 
                source.YearOfOperation, 
                source.PrincipalDirection, 
                source.ExpressService);
        }
    }
}

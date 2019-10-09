using System.Windows.Media;
using Framework.Patterns.Publish;
using System.ComponentModel;
using Modules.Metro.MetroLines.Data;

namespace Modules.Metro.MetroLines.ViewModel
{
    /// <summary>
    /// Implementation of read / write <see cref="IMetroLine"/> / <see cref="IMetroLineWritable"/> for bindings
    /// Implements <see cref="INotifyListener"/> for <see cref="Notify{T}"/>
    /// </summary>
    public class MetroLineDetailsBindable : IMetroLine, IMetroLineWritable, INotifyListener
    {
        /// <summary>
        /// Destination station
        /// </summary>
        private readonly Notify<string> _destinationStation;
        /// <summary>
        /// Source station
        /// </summary>
        private readonly Notify<string> _sourceStation;
        /// <summary>
        /// Line Color
        /// </summary>
        private readonly Notify<Color> _lineColor;
        /// <summary>
        /// Line letter
        /// </summary>
        private readonly Notify<char> _lineLetter;
        /// <summary>
        /// Line Name
        /// </summary>
        private readonly Notify<string> _name;
        /// <summary>
        /// Saturday Service?
        /// </summary>
        private readonly Notify<bool> _saturdayService;
        /// <summary>
        /// Sunday/Holiday Service?
        /// </summary>
        private readonly Notify<bool> _sundayHolidayService;
        /// <summary>
        /// Year of operation
        /// </summary>
        private readonly Notify<int> _yearOfOperation;
        /// <summary>
        /// Principal direction of line
        /// </summary>
        private readonly Notify<LineType> _principalDirection;
        /// <summary>
        /// Is this an express train?
        /// </summary>
        private readonly Notify<bool> _expressService;

        /// <summary>
        /// <see cref="IMetroLine.DestinationStation"/>
        /// </summary>
        public string DestinationStation
        {
            get { return _destinationStation.Value; }
            set { _destinationStation.Value = value; }
        }

        /// <summary>
        /// <see cref="IMetroLine.LineColor"/>
        /// </summary>
        public Color LineColor
        {
            get { return _lineColor.Value; }
            set { _lineColor.Value = value; }
        }

        /// <summary>
        /// <see cref="IMetroLine.LineLetter"/>
        /// </summary>
        public char LineLetter
        {
            get { return _lineLetter.Value; }
            set { _lineLetter.Value = value; }
        }

        /// <summary>
        /// <see cref="IMetroLine.Name"/>
        /// </summary>
        public string Name
        {
            get { return _name.Value; }
            set { _name.Value = value; }
        }

        /// <summary>
        /// <see cref="IMetroLine.SaturdayService"/>
        /// </summary>
        public bool SaturdayService
        {
            get { return _saturdayService.Value; }
            set { _saturdayService.Value = value; }
        }

        /// <summary>
        /// <see cref="IMetroLine.SourceStation"/>
        /// </summary>
        public string SourceStation
        {
            get { return _sourceStation.Value; }
            set { _sourceStation.Value = value; }
        }

        /// <summary>
        /// <see cref="IMetroLine.SundayHolidayService"/>
        /// </summary>
        public bool SundayHolidayService
        {
            get { return _sundayHolidayService.Value; }
            set { _sundayHolidayService.Value = value; }
        }

        /// <summary>
        /// <see cref="IMetroLine.YearOfOperation"/>
        /// </summary>
        public int YearOfOperation
        {
            get { return _yearOfOperation.Value; }
            set { _yearOfOperation.Value = value; }
        }

        /// <summary>
        /// <see cref="IMetroLine.PrincipalDirection"/>
        /// </summary>
        public LineType PrincipalDirection
        {
            get { return _principalDirection.Value; }
            set { _principalDirection.Value = value; }
        }

        /// <summary>
        /// <see cref="IMetroLine.ExpressService"/>
        /// </summary>
        public bool ExpressService
        {
            get { return _expressService.Value; }
            set { _expressService.Value = value; }
        }

        /// <summary>
        /// <see cref="INotifyPropertyChanged.PropertyChanged"/>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// <see cref="INotifyListener.PropertyHasChanged(string)"/>
        /// </summary>
        /// <param name="propertyName"></param>
        public void PropertyHasChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MetroLineDetailsBindable"/>
        /// </summary>
        public MetroLineDetailsBindable()
        {
            _destinationStation = new Notify<string>(nameof(DestinationStation), this);
            _expressService = new Notify<bool>(nameof(ExpressService), this);
            _lineColor = new Notify<Color>(nameof(LineColor), this);
            _lineLetter = new Notify<char>(nameof(LineLetter), this);
            _name = new Notify<string>(nameof(Name), this);
            _principalDirection = new Notify<LineType>(nameof(PrincipalDirection), this);
            _saturdayService = new Notify<bool>(nameof(SaturdayService), this);
            _sourceStation = new Notify<string>(nameof(SourceStation), this);
            _sundayHolidayService = new Notify<bool>(nameof(SundayHolidayService), this);
            _yearOfOperation = new Notify<int>(nameof(YearOfOperation), this);
        }

        /// <summary>
        /// Converts from <see cref="MetroLineDetails"/> to a bindable version <see cref="MetroLineDetailsBindable"/>
        /// </summary>
        /// <param name="source">Source object</param>
        public static explicit operator MetroLineDetailsBindable(MetroLineDetails source)
        {
            return new MetroLineDetailsBindable()
            {
                DestinationStation = source.DestinationStation,
                ExpressService = source.ExpressService,
                LineColor = source.LineColor,
                LineLetter = source.LineLetter,
                Name = source.Name,
                PrincipalDirection = source.PrincipalDirection,
                SaturdayService = source.SaturdayService,
                SourceStation = source.SourceStation,
                SundayHolidayService = source.SundayHolidayService,
                YearOfOperation = source.YearOfOperation
            };
        }
    }
}

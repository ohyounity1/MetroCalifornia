using System;
using System.Collections.Generic;
using System.Windows.Media;
using Framework.Data.Serialize.CSV;
using Framework.Patterns.Container;
using Framework.Patterns.Exception;
using Modules.Metro.MetroLines.Data;

namespace Modules.Metro.MetroLines.Model
{
    /// <summary>
    /// Reads out <see cref="MetroLineDetails"/> from a CSV file using <see cref="CSVSerializer{T}"/>
    /// </summary>
    public class MetroLineDetailsReader : CSVSerializer<MetroLineDetails>
    {
        /// <summary>
        /// Locations of the headers
        /// </summary>
        private readonly IList<string> _headerLocations = new List<string>();

        /// <summary>
        /// <see cref="CSVSerializer{T}.ConfigureHeader(IEnumerable{string})"/>
        /// </summary>
        /// <param name="headers">The list of headers from the top of the CSV file</param>
        protected override void ConfigureHeader(IEnumerable<string> headers)
        {
            // Populate list of headers
            headers.ForEach((i) => _headerLocations.Add(i));
        }

        /// <summary>
        /// <see cref="CSVSerializer{T}.ReadLine(IEnumerable{string}, IList{T})"/>
        /// </summary>
        /// <param name="line">Current comma separated row</param>
        /// <param name="newData">Where to put new instance of <see cref="MetroLineDetails"/></param>
        protected override void ReadLine(IEnumerable<string> line, IList<MetroLineDetails> newData)
        {
            var itemIndex = 0;
            // Use temp helper class
            var newMetroLine = new MetroLineDetailsReaderHelper();
            // Read out item from each column in this line
            foreach(var lineData in line)
            {
                // Validate the item index
                if(itemIndex < _headerLocations.Count)
                {
                    // Line up the column with the current position we are in
                    var currentHeader = _headerLocations[itemIndex];
                    // Which column is this?
                    switch (currentHeader)
                    {
                        // Name column
                        case nameof(MetroLineDetails.Name):
                            newMetroLine.Name = lineData;
                            break;
                        // Destination station column
                        case nameof(MetroLineDetails.DestinationStation):
                            newMetroLine.DestinationStation = lineData;
                            break;
                        // Line color column
                        case nameof(MetroLineDetails.LineColor):
                            // Do a bit of intermediate conversion
                            var intermediateColor = System.Drawing.ColorTranslator.FromHtml(lineData);
                            newMetroLine.LineColor = Color.FromArgb(intermediateColor.A, intermediateColor.R, intermediateColor.G, intermediateColor.B);
                            break;
                        // Line letter column
                        case nameof(MetroLineDetails.LineLetter):
                            newMetroLine.LineLetter = lineData[0];
                            break;
                        // Service type columns
                        case nameof(MetroLineDetails.SaturdayService):
                        case nameof(MetroLineDetails.SundayHolidayService):
                        case nameof(MetroLineDetails.ExpressService):
                            var boolValue = false;
                            if (bool.TryParse(lineData, out boolValue))
                            {
                                if (currentHeader == nameof(MetroLineDetails.SaturdayService))
                                    newMetroLine.SaturdayService = boolValue;
                                else if (currentHeader == nameof(MetroLineDetails.SundayHolidayService))
                                    newMetroLine.SundayHolidayService = boolValue;
                                else
                                    newMetroLine.ExpressService = boolValue;
                                break;
                            }
                            // If this failed, throw an exception as true/false not formatted correctly
                            throw new Exception<IncorrectCSVBoolValueFormatting>(new IncorrectCSVBoolValueFormatting(currentHeader, lineData));
                        // Source station column
                        case nameof(MetroLineDetails.SourceStation):
                            newMetroLine.SourceStation = lineData;
                            break;
                        // Year of operation column
                        case nameof(MetroLineDetails.YearOfOperation):
                            newMetroLine.YearOfOperation = Convert.ToInt32(lineData);
                            break;
                        // Direction column
                        case nameof(MetroLineDetails.PrincipalDirection):
                            LineType lineType = LineType.EastWest;
                            // Try to parse out the enum value
                            if (Enum.TryParse(lineData, out lineType))
                            {
                                newMetroLine.PrincipalDirection = lineType;
                                break;
                            }
                            // Throw exception if this failed
                            throw new Exception<IncorrectCSVEnumValueFormatting>(new IncorrectCSVEnumValueFormatting(typeof(LineType), currentHeader, lineData));
                        default:
                            throw new Exception<UnrecognizedCSVHeaderProperty>(new UnrecognizedCSVHeaderProperty(currentHeader));
                    }
                }
                ++itemIndex;
            }
            // Add new item
            newData.Add((MetroLineDetails)newMetroLine);
        }
    }
}

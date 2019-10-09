using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Framework.Data.Serialize.CSV
{
    /// <summary>
    /// Serializer for CSV files, which implements interface <see cref="IInOutSerializer"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CSVSerializer<T> : IInOutSerializer
    {
        private readonly IList<string> _headerLocations = new List<string>();

        /// <summary>
        /// Override to setup the location of the headers so the reader can know which value goes with which property
        /// </summary>
        /// <param name="headers">The list of headers at the top of the CSV file</param>
        protected abstract void ConfigureHeader(IEnumerable<string> headers);
        /// <summary>
        /// Override to read in a line, called after <see cref="CSVSerializer{T}.ConfigureHeader(IEnumerable{string})"/>
        /// </summary>
        /// <param name="line">A common separated data set</param>
        /// <param name="data">Convert line to <see cref="T"/> and place the new instance of <see cref="T"/> in this list</param>
        protected abstract void ReadLine(IEnumerable<string> line, IList<T> data);

        /// <summary>
        /// <see cref="IInSerializer.Load(TextReader)"/>
        /// </summary>
        /// <param name="reader">The source of the data</param>
        /// <returns>true for success, false for failure</returns>
        public bool Load(TextReader reader)
        {
            // Create list for the data items in the csv file
            var newData = new List<T>();
            // Read out the csv file
            using (var csvLoader = new TextFieldParser(reader))
            {
                // Configure the reader to use , as the delimiter
                csvLoader.TextFieldType = FieldType.Delimited;
                csvLoader.SetDelimiters(",");
                var headerLine = true;
                // Read all lines
                while (!csvLoader.EndOfData)
                {
                    // First line is the header
                    var fields = csvLoader.ReadFields();
                    if(headerLine)
                    {
                        // Call subclass so they can know which column goes with which piece of data
                        ConfigureHeader(fields);
                        headerLine = false;
                    }
                    else
                    {
                        // Now read all the data lines
                        ReadLine(fields, newData);
                    }
                }
            }
            // Store the list
            Data = newData;
            return true;
        }
        /// <summary>
        /// <see cref="IOutSerializer.Save(TextWriter)"/>
        /// </summary>
        /// <param name="writer">Where to store the CSV data</param>
        /// <returns>true for success, false for failure</returns>
        public bool Save(TextWriter writer)
        {
            // Not implemented right now, not saving to CSV files
            return true;
        }
        /// <summary>
        /// Data source
        /// </summary>
        public IEnumerable<T> Data
        {
            get;
            set;
        }
    }
}

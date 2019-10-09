using System.Windows.Media;
using BaseReadonly = Metro.Framework.Data.IMetroLine;
using BaseWriteonly = Metro.Framework.Data.IMetroLineWriteable;

namespace Modules.Metro.MetroLines.Data
{
    /// <summary>
    /// Line destination direction
    /// </summary>
    public enum LineType
    {
        NorthSouth,// Mainly north-south venue
        EastWest,// Main east-west venue
        Circle // Line goes in a circle
    }

    /// <summary>
    /// Extends <see cref="BaseReadonly"/>
    /// </summary>
    public interface IMetroLine : BaseReadonly
    {
        /// <summary>
        /// Color of the line
        /// </summary>
        Color LineColor { get; }

        /// <summary>
        /// Line letter
        /// </summary>
        char LineLetter { get; }

        /// <summary>
        /// The principal route direction
        /// </summary>
        LineType PrincipalDirection { get; }

        /// <summary>
        /// Express line
        /// </summary>
        bool ExpressService { get; }
    }

    /// <summary>
    /// Extends <see cref="BaseWriteonly"/>
    /// </summary>
    public interface IMetroLineWritable : BaseWriteonly
    {
        /// <summary>
        /// Color of the line
        /// </summary>
        Color LineColor { set; }

        /// <summary>
        /// Line letter
        /// </summary>
        char LineLetter { set; }

        /// <summary>
        /// Principal direction of route
        /// </summary>
        LineType PrincipalDirection { set; }

        /// <summary>
        /// Express service?
        /// </summary>
        bool ExpressService { set; }
    }
}

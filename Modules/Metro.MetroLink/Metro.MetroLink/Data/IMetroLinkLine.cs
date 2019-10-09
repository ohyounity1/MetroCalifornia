using System;
using BaseReadonly = Metro.Framework.Data.IMetroLine;
using BaseWriteonly = Metro.Framework.Data.IMetroLineWriteable;

namespace Metro.MetroLink.Data
{
    /// <summary>
    /// List of image types
    /// </summary>
    public enum LineImage
    {
        SunImage, // Sun image
        SaquaroImage, // Cactus image
        MountainImage, // Mountain image
        CoyoteImage, // Coyote image
        PalmsImage // Palm tree image
    }

    /// <summary>
    /// List of train types
    /// </summary>
    public enum TrainType
    {
        Diesel, // Diesel only locomotive
        ElectricOverhead, // Electric overhead locomotive
        Electric3rdRail, // 3rd rail carriages
        ElectricOverheadDiesel, // Electric overhead up to a point, then diesel
        Electric3rdRailDiesel // 3rd rail to a point, then diesel
    }

    /// <summary>
    /// Extends <see cref="BaseReadonly"/> to add metro link specific properties
    /// </summary>
    public interface IMetroLinkLine : BaseReadonly
    {
        /// <summary>
        /// Type of line image
        /// </summary>
        LineImage LineImage { get; }
        /// <summary>
        /// Train type
        /// </summary>
        TrainType TrainType { get; }
        /// <summary>
        /// Line start time
        /// </summary>
        DateTime LineStartTime { get; }
        /// <summary>
        /// Line end time
        /// </summary>
        DateTime LineEndTime { get; }
    }

    /// <summary>
    /// Extends <see cref="BaseWriteonly"/> to add metro link specific properties
    /// </summary>
    public interface IMetroLinkLineWriteable : BaseWriteonly
    {
        /// <summary>
        /// Line image
        /// </summary>
        LineImage LineImage { set; }
        /// <summary>
        /// Train type
        /// </summary>
        TrainType TrainType { set; }
        /// <summary>
        /// Line start time
        /// </summary>
        DateTime LineStartTime { set; }
        /// <summary>
        /// Line end time
        /// </summary>
        DateTime LineEndTime { set; }
    }
}

using System;
using Framework.Data.Serialize.JSON;
using Framework.Patterns.Enum;
using Framework.Patterns.Exception;
using Modules.Metro.MetroLines.Data;
using Newtonsoft.Json.Linq;

namespace Modules.Metro.MetroLines.Model
{
    internal static class LineTypeExtensions
    {
        public static LineType ToLineType(this string source)
        {
            LineType result = LineType.EastWest;
            if (!Enum.TryParse(source, out result))
                throw new Exception<InvalidCastException>(new InvalidCastException());
            return result;
        }

        public static string String(this LineType source)
        {
            return EnumExtensions.GetName(source);
        }
    }

    public class MetroLineJSONSerializationStrategy : JSONSerializer<MetroLineDetails>
    {
        protected override bool LoadJObject(JObject jObject)
        {
            var helper = new MetroLineDetailsReaderHelper();
            jObject.Read(nameof(MetroLineDetails.Name), (t) => (string)t, (v) => helper.Name = v);
            jObject.Read(nameof(MetroLineDetails.LineLetter), (t) => (char)t, (v) => helper.LineLetter = v);
            jObject.Read(nameof(MetroLineDetails.SourceStation), (t) => (string)t, (v) => helper.SourceStation = v);
            jObject.Read(nameof(MetroLineDetails.DestinationStation), (t) => (string)t, (v) => helper.DestinationStation = v);
            jObject.Read(nameof(MetroLineDetails.SaturdayService), (t) => (bool)t, (v) => helper.SaturdayService = v);
            jObject.Read(nameof(MetroLineDetails.SundayHolidayService), (t) => (bool)t, (v) => helper.SundayHolidayService = v);
            jObject.Read(nameof(MetroLineDetails.YearOfOperation), (t) => (int)t, (v) => helper.YearOfOperation = v);
            jObject.Read(nameof(MetroLineDetails.ExpressService), (t) => (bool)t, (v) => helper.ExpressService = v);

            var color = jObject.Read(nameof(MetroLineDetails.LineColor), (t) => (JObject)t);
            helper.LineColor = color.ToColor();

            var direction = jObject.Read(nameof(MetroLineDetails.PrincipalDirection), (t) => (string)t);
            helper.PrincipalDirection = direction.ToLineType();

            Source = (MetroLineDetails)helper;

            return true;
        }

        protected override bool Serialize(JObject jObject)
        {
            jObject.Add(nameof(MetroLineDetails.Name), Source.Name);
            jObject.Add(nameof(MetroLineDetails.LineLetter), Source.LineLetter);
            jObject.Add(nameof(MetroLineDetails.SourceStation), Source.SourceStation);
            jObject.Add(nameof(MetroLineDetails.DestinationStation), Source.DestinationStation);
            jObject.Add(nameof(MetroLineDetails.SaturdayService), Source.SaturdayService);
            jObject.Add(nameof(MetroLineDetails.SundayHolidayService), Source.SundayHolidayService);
            jObject.Add(nameof(MetroLineDetails.LineColor), Source.LineColor.ToJObject());
            jObject.Add(nameof(MetroLineDetails.YearOfOperation), Source.YearOfOperation);
            jObject.Add(nameof(MetroLineDetails.PrincipalDirection), Source.PrincipalDirection.String());
            jObject.Add(nameof(MetroLineDetails.ExpressService), Source.ExpressService);
            return true;
        }
    }

    
}

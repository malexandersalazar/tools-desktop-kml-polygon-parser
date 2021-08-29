using KMLParser.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KMLParser.Encoders
{
    public static class PolygonGeometryDataTypeEncoder
    {
        public static string Encode(IEnumerable<Coordinate> points)
        {
            var stringBuilder = new StringBuilder("geography::STPolyFromText('POLYGON((");
            foreach (var point in points)
                stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0} {1},", point.X, point.Y);
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append("))', 4326)");
            return stringBuilder.ToString();
        }
    }
}
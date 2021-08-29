using KMLParser.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace KMLParser.Encoders
{
    public class JSONPointsEncoder
    {
        public static string Encode(IEnumerable<Coordinate> points)
        {
            return JsonConvert.SerializeObject(points, Formatting.None);
        }
    }
}
using Newtonsoft.Json;
using System.Windows;

namespace KMLParser
{
    public partial class App : Application
    {
        public App()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Culture = System.Globalization.CultureInfo.InvariantCulture,
                Formatting = Formatting.None
            };
        }
    }
}
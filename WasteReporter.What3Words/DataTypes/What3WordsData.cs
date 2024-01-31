using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable
namespace WasteReporter.What3Words.DataTypes
{
    public class What3WordsData : Record<What3WordsData>
    {
        public (double, double) Coordinates { get; private set; }

        public string Words { get; private set; }

        public string MapsOnW3WUrl { get; private set; }

        public string MapsOnGoogleUrl { get; private set; }

        private What3WordsData((double, double) coordinates, string words, string mapw3wUrl, string mapGoogleUrl)
        {
            Coordinates = coordinates;
            Words = words;
            MapsOnW3WUrl = mapw3wUrl;
            MapsOnGoogleUrl = mapGoogleUrl;
        }

        public static What3WordsData New((double, double) coordinates, string words, string mapw3wUrl, string mapGoogleUrl)
            => new(coordinates, words, mapw3wUrl, mapGoogleUrl);
    }
}

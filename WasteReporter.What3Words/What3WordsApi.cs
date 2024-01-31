using System.Threading.Tasks;
using WasteReporter.What3Words.DataTypes;
using what3words.dotnet.wrapper;
using what3words.dotnet.wrapper.models;
using what3words.dotnet.wrapper.request;
using what3words.dotnet.wrapper.response;

namespace WasteReporter.What3Words
{
    public class What3WordsApi
    {
        private static string What3WordsApiKey = "XSQC8KXF";
        
        public What3WordsV3 What3WordsService { get; }

        public What3WordsApi()
        {
            What3WordsService = new What3WordsV3(What3WordsApiKey);
        }

        public async Task<What3WordsData> ConvertCoordinatesTo3WA(double lat, double lon)
        {
            var req = await What3WordsService.ConvertTo3WA(new Coordinates(lat, lon)).RequestAsync();

            return ConvertToDataType(req);
        }

        private static What3WordsData ConvertToDataType(APIResponse<Address> req)
        {
            return What3WordsData.New((req.Data.Coordinates.Lat, req.Data.Coordinates.Lng), req.Data.Words, req.Data.Map, string.Empty);
        }

        public async Task<What3WordsData> Convert3WAToCoordinates(string words)
        {
            var req = await What3WordsService.ConvertToCoordinates(words).RequestAsync();

            return ConvertToDataType(req);
        }
    }
}
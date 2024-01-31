using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using WasteReporter.What3Words;

namespace WasteReporter.App.ViewModels
{
    public class ReportLitterViewModel : BaseViewModel
    {
        public List<CountyCouncil> CountyCouncils { get; private set; }

        public List<string> AreaTypes { get; }
        public string LocationCoords { get; set; }

        public ReportLitterViewModel()
        {
            Title = "Report Litter";
            RetrieveCoordinatesCommand = new Command(async () => await GetCurrentLocation());

            CountyCouncils = new List<CountyCouncil> 
            {
                new CountyCouncil {Id = 1, Name = "Caerphilly County Council", Enabled = true },
                new CountyCouncil {Id = 1, Name = "Newport County Council", Enabled = false },
                new CountyCouncil {Id = 1, Name = "Cardiff County Council", Enabled = false }
            };

            AreaTypes = new List<string>
            {
                "Front Street",
                "Rear Lane",
                "Footpath",
                "Car Park",
                "Playground",
                "Bus Shelter",
                "Park"           
            };

            LocationCoords = "Lat 51.222011, Lon 0.152311)";

        }

        public ICommand RetrieveCoordinatesCommand { get; }

        CancellationTokenSource cts;

        async Task GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    var service = new What3WordsApi();
                    var huh = await service.ConvertCoordinatesTo3WA(location.Latitude, location.Longitude);
                    LocationCoords = huh.ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }

    public class CountyCouncil
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Enabled { get; set; }
    }
}
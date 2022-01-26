using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MyWayAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapFirstTry : ContentPage
    {
        private Placemark placemark = new Placemark
        {
            CountryName = "Israel",
            
            Locality = "Hod Hasharon"
        };

        public MapFirstTry()
        {
            InitializeComponent();
        }

       

        async void Button_Clicked1(System.Object sender, System.EventArgs e)
        {
            await Map.OpenAsync(47.6529, -122.1422, new MapLaunchOptions
            {
                Name = "Not Microsoft Campus",
                NavigationMode = NavigationMode.Driving
            });
        }

       

        ////// google maps
        //private readonly Geocoder _geocoder = new Geocoder();


        //public MapFirstTry()
        //{
        //    InitializeComponent();
        //}

        //async void Map_MapClicked(System.Object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        //{
        //   // await DisplayAlert("Coordinates", $"Lat: {e.Position.Latitude}, Long: {e.Position.Longitude}", "OK");

        //    var addresses = await _geocoder.GetAddressesForPositionAsync(e.Position);

        //    await DisplayAlert("Address", addresses.FirstOrDefault()?.ToString(), "OK");

        //    var positions = await _geocoder.GetPositionsForAddressAsync("Hod Hasharon, Israel");

        //   // await DisplayAlert("Position", $"Lat: {positions.First().Latitude}, Long: {positions.First().Longitude}", "OK");

        //    myMap.MoveToRegion(MapSpan.FromCenterAndRadius(positions.First(), Distance.FromKilometers(1)));
        //}

    }
}
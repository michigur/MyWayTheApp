using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyWayAPP.Models;
using MyWayAPP.Views;
using System.Collections.Generic;
using MyWayAPP.Services;

namespace MyWayAPP
{
    public class Constants
    {
        //Generate Google Api Key at: https://console.cloud.google.com/ for Places API, Directions API, Maps SDK For android!
        //Generate Bing Api Key at: https://www.bingmapsportal.com/
        public const string GoogleApiKey = "AIzaSyCz8nXSYXgR0nfzko2h6dJlvtYt3M0LFwM";
        public const string BingApiKey = "YOUR BING API KEY";
    }

    public partial class App : Application
    { 
        public static bool IsDevEnv
        {
            get
            {
                return false; //change this before release!
            }
        }

        //The current logged in user
        public Client CurrentUser { get; set; }

        //The list of cars
        public List<Car> Cars { get; set; }

        public Car CurrentCar { get; set; }
        public App()
        {
            InitializeComponent();
            GoogleMapsApiService.Initialize(Constants.GoogleApiKey);
            Device.SetFlags(new[] { "MediaElement_Experimental", "Brush_Experimental" });
            Page p = new LandingPage();
            MainPage = new NavigationPage(p);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

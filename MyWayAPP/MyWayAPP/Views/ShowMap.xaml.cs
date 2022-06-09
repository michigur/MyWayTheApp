using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyWayAPP.ViewModels;
using MyWayAPP.Helpers;
using Xamarin.Forms.Maps;
using MyWayAPP.Models;
using Xamarin.CommunityToolkit.Extensions;

namespace MyWayAPP.Views
{



    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowMap : ContentPage 
    {
        public ShowMap()
        {
            ShowMapViewModel vm = new ShowMapViewModel();
            vm.OnUpdateMapEvent += OnUpdateMap;
            this.BindingContext = vm;
            InitializeComponent();

        }




        public void OnUpdateMap()
        {

            //Clear all routes and pins from the map
            map.MapElements.Clear();

            ShowMapViewModel vm = (ShowMapViewModel)this.BindingContext;

            //Create two pins for origin and destination and add them to the map
            Pin pin1 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(vm.RouteOrigin.Latitude, vm.RouteOrigin.Longitude),
                Label = vm.RouteOrigin.Name,
                Address = ""
            };
            map.Pins.Add(pin1);
            Pin pin2 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(vm.RouteDestination.Latitude, vm.RouteDestination.Longitude),
                Label = vm.RouteDestination.Name,
                Address = ""
            };
            map.Pins.Add(pin2);

            //Move the map to show the environment of the origin place! with radius of 5 KM... should be changed
            //according to the specific needs
            MapSpan span = MapSpan.FromCenterAndRadius(pin1.Position, Distance.FromKilometers(5));
            map.MoveToRegion(span);

            //Create the polyline between origin and destination
            GoogleDirection directions = vm.RouteDirections;
            Xamarin.Forms.Maps.Polyline path = new Xamarin.Forms.Maps.Polyline()
            {
                StrokeColor = Xamarin.Forms.Color.Blue,
                StrokeWidth = 15
            };
            //run through each leg of the route, then, through each step
            foreach (Leg leg in directions.Routes[0].Legs)
            {
                foreach (Step step in leg.Steps)
                {
                    var p = step.Polyline;
                    //Decode all positions of the line in this specific step!
                    IEnumerable<Position> positions = PolylineHelper.Decode(p.Points);

                    //Add the positions to the line
                    foreach (Position pos in positions)
                    {
                        path.Geopath.Add(pos);
                    }

                }
            }
            //Add the line to the map!
            map.MapElements.Add(path);

        }



        private void Button_Clicked3(object sender, EventArgs e)
        {

            Navigation.ShowPopup(new PriceViewPopUp()
            {
                IsLightDismissEnabled = false
            });
        }




        //public ObservableCollection<Menu1> MenuItems { get; set; }



        //private async void Show()
        //{

        //    _ = TitleTxt.FadeTo(0);
        //    _ = MenuItemsView.FadeTo(1);
        //    await MainMenuView.RotateTo(0, 300, Easing.BounceOut);
        //}

        //private async void Hide()
        //{
        //    _ = TitleTxt.FadeTo(1);
        //    _ = MenuItemsView.FadeTo(0);
        //    await MainMenuView.RotateTo(-90, 300, Easing.BounceOut);
        //}

        //private void ShowMenu(object sender, EventArgs e)
        //{
        //    Show();
        //}

        //private void MenuTapped(object sender, EventArgs e)
        //{
        //    TitleTxt.Text = ((sender as StackLayout).BindingContext as Menu1).Title;
        //    Hide();
        //}


        private void Button_Clicked(object sender, EventArgs e)
        {
            ContentPage p = new LandingPage();
            Navigation.PushAsync(p);
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            ContentPage p = new ProfilePage();
            Navigation.PushAsync(p);
        }

        //private void Button_Clicked2(object sender, EventArgs e)
        //{
        //    ////ContentPage p = new ShowMap();
        //    ////Navigation.PushAsync(p);
        //}





    }



    public class Menu1
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public ContentPage page { get; set; }
    }


}
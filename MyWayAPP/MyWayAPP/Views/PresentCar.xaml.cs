using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.UI.Views;
using MyWayAPP.ViewModels;
using MyWayAPP.Helpers;
using Xamarin.Forms.Maps;
using MyWayAPP.Models;

namespace MyWayAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PresentCar : ContentPage
    {


        private string origin;

        private string destination;

        private string carLocation;

        public PresentCar(string Origin, string Destination)
        {
            PresentCarViewModel vm = new PresentCarViewModel(Origin,Destination);
            vm.CarLocationEvent += OncarLocationUpdate;
            vm.OnUpdateMapEvent += OnUpdateMap;
            this.BindingContext = vm;
            carElement = null;
            InitializeComponent();
            this.origin = Origin;
            this.destination = Destination;
            App theApp = (App)App.Current;
            Car currentCar = theApp.CurrentCar;
            this.carLocation = currentCar.CarCurrentLocation;
        }

       

        private Circle carElement;
        public void OncarLocationUpdate(double longitude, double latitude)
        {
            Position position = new Position(latitude, longitude);
            if (carElement == null)
            {
                carElement = new Circle()
                {
                    Radius = Distance.FromMeters(100),
                    FillColor = Color.Orange,
                };
                myMap.MapElements.Add(carElement);
            }
            carElement.Center = position;
        }


        
        public void OnUpdateMap()
        {
            App theApp = (App)App.Current;
            Car currentCar = theApp.CurrentCar;

            //Clear all routes and pins from the map
            myMap.MapElements.Clear();

            PresentCarViewModel vm = (PresentCarViewModel)this.BindingContext;

            //Create two pins for origin and destination and add them to the map
            Pin pin1 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(vm.RouteOrigin.Latitude, vm.RouteOrigin.Longitude),
                Label = vm.RouteOrigin.Name,
                Address = ""
            };
            myMap.Pins.Add(pin1);


            Pin pin2 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(vm.RouteDestination.Latitude, vm.RouteDestination.Longitude),
                Label = vm.RouteDestination.Name,
                Address = ""
            };
            myMap.Pins.Add(pin2);

            Pin pin3 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(vm.RouteCarLocation.Latitude, vm.RouteCarLocation.Longitude),
                Label = vm.RouteCarLocation.Name,
                Address = ""
            };
            myMap.Pins.Add(pin3);



            //Move the map to show the environment of the origin place! with radius of 5 KM... should be changed
            //according to the specific needs
            MapSpan span = MapSpan.FromCenterAndRadius(pin1.Position, Distance.FromKilometers(5));
            myMap.MoveToRegion(span);

            //Create the polyline between origin and destination
            GoogleDirection Cardirections = vm.CarRouteDirections;
            Xamarin.Forms.Maps.Polyline path = new Xamarin.Forms.Maps.Polyline()
            {
                StrokeColor = Xamarin.Forms.Color.Coral,
                StrokeWidth = 15
            };
            //run through each leg of the route, then, through each step
            foreach (Leg leg in Cardirections.Routes[0].Legs)
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

            GoogleDirection ClientRouteDirections = vm.ClientRouteDirections;
           
            //run through each leg of the route, then, through each step
            foreach (Leg leg in ClientRouteDirections.Routes[0].Legs)
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
            myMap.MapElements.Add(path);

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}
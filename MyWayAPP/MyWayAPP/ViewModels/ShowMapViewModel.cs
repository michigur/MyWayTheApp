using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MyWayAPP.Services;
using MyWayAPP.Helpers;
using MyWayAPP.Views;
using MyWayAPP.Models;
//using Android.Content.Res;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms.GoogleMaps;
using System.Threading.Tasks;

namespace MyWayAPP.ViewModels
{
    class ShowMapViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        CarRoutteType crt = new CarRoutteType()
        {  
            CarRoutteName = "route",
            CarRoutteTypeId = 1
        };

        public string driveTime;
        public string DriveTime
        {
            get => this.driveTime;
            set
            {
                this.driveTime = "16 min";
                OnPropertyChanged("DriveTime");
            }
        }

        public string carLocation;
        public string CarLocation
        {
            get => this.carLocation;
            set
            {
                this.carLocation = value;
                OnPropertyChanged("carLocation");
            }
        }

        public string drivePrice;
        public string DrivePrice
        {
            get => this.drivePrice;
            set
            {
                this.driveTime = "30 Shekels";
                OnPropertyChanged("DrivePrice");
            }
        }


        private string origin;
        public string Origin
        {
            get => this.origin;
            set
            {
                this.origin = value;
                OnPropertyChanged("Origin");
            }
        }

        private string destination;
        public string Destination
        {
            get => this.destination;
            set
            {
                this.destination = value;
                OnPropertyChanged("Destination");
            }
        }

        public GooglePlace RouteOrigin { get; private set; }
        public GooglePlace RouteDestination { get; private set; }
        public GoogleDirection RouteDirections { get; private set; }

        public ICommand Go => new Command(OnGo);
        public async void OnGo()
        {
            try
            {
                List<Car> cars = await this.Loadcars((App)App.Current);
                
                GoogleMapsApiService service = new GoogleMapsApiService();
               
                GooglePlaceAutoCompleteResult originPlaces = await service.GetPlaces(Origin);
                GooglePlaceAutoCompleteResult destPlaces = await service.GetPlaces(Destination);
                //extract the exact first google place for origin and destination
                
                GooglePlace place1 = await service.GetPlaceDetails(originPlaces.AutoCompletePlaces[0].PlaceId);
                GooglePlace place2 = await service.GetPlaceDetails(destPlaces.AutoCompletePlaces[0].PlaceId);
                //get directions to move from origin to destination
                GoogleDirection direction = await service.GetDirections($"{place1.Latitude}", $"{place1.Longitude}", $"{place2.Latitude}", $"{place2.Longitude}");
                //update the properties so the main page class will have access to the information and fire the event to update the map
                RouteOrigin = place1;
                RouteDestination = place2;
                RouteDirections = direction;
                if (OnUpdateMapEvent != null)
                    OnUpdateMapEvent();


                App theApp = (App)App.Current;

                MyWayAPIProxy proxy = MyWayAPIProxy.CreateProxy();
                RoutteCar u = new RoutteCar
                {
                    RouteDeputureLocation = Origin,
                    RouteArrivalLocation = destination,
                    RouteDeputureTime = DateTime.Now,
                    RouteArrivalTime = DateTime.Now,
                    CarRoutteTypeId = 1,
                    CarId = 5,
                    ClientId = theApp.CurrentUser.ClientId,
                    Car = theApp.CurrentCar,
                    Client = theApp.CurrentUser,
                    CarRoutteType = crt
                };

                bool isReturned = await proxy.RegisterRoute(u);

                if (isReturned == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Sign Up Failed!", "Invalid input", "OK");

                }
                else
                {
                   
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("cant find route");
            }
            
            
        }



        public ShowMapViewModel()
        {

            App theApp = (App)App.Current;
            Car currentUser = theApp.CurrentCar;

            if (currentUser != null)
            {
                this.carLocation = currentUser.CarCurrentLocation;
            }

        }

        public async Task<List<Car>> Loadcars(App theApp)
        {
            MyWayAPIProxy proxy = MyWayAPIProxy.CreateProxy();
            theApp.Cars = await proxy.GetCarsAsync();
            theApp.CurrentCar = theApp.Cars[0];
            return theApp.Cars;
        }


        public ICommand Pay => new Command(pay);
        void pay()
        {

            Page p = new PresentCar();
            App.Current.MainPage = p;

        }

        public ICommand Profile => new Command(profile);
        void profile()
        {

            Page p = new ProfilePage();
            App.Current.MainPage = p;

        }


        public ICommand Logout => new Command(logout);
        void logout()
        {
            App theApp = (App)Application.Current;
            theApp.CurrentUser = null;
            Page p = new LandingPage();
            App.Current.MainPage = p;

        }

        public event Action OnUpdateMapEvent;




    }
}

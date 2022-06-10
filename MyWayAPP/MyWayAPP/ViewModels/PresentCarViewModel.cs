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
    class PresentCarViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        private string origin;

        private string destination;

        private string carLocation;


        //define event to update car location on the map
        public event Action<double, double> CarLocationEvent;
        //define connecgtion to hub
        LocationProxy hubProxy;
        #region Currentlocation
        private string currentlocation;
        public string Currentlocation
        {
            get => currentlocation;
            set
            {
                currentlocation = value;
                OnPropertyChanged("CarCurrentLocation");
            }
        }
        #endregion
        public ICommand InCar => new Command(IsinCar);
        void IsinCar()
        {
            Application.Current.MainPage.DisplayAlert("Have a nice ride!", "when you have arrived at your destination please confirm so in the 'Ride Ended' button","OK" );
        }

        public ICommand NevigateToCardView => new Command(Gotomap);
        void Gotomap()
        {
            //SendArriveToDestination();
            Page p = new CreditCardView();
            App.Current.MainPage = p;

        }
        private Client currentUser;
        private Car currentCar;
        public PresentCarViewModel(string Origin , string Destination)
        {
            App theApp = (App)App.Current;
            this.currentCar = theApp.CurrentCar;
            this.currentUser = theApp.CurrentUser;
            hubProxy = new LocationProxy();
            //ConnectToProxy();
            hubProxy.RegisterToupdateCarLocation(SetCarLocation);
            this.carLocation = currentCar.CarCurrentLocation;
            this.origin = Origin;
            this.destination = Destination;
            OnGo();

        }



        public async void ConnectToProxy()
        {
            await hubProxy.Connect(currentCar.CarId);
        }
        public void SetCarLocation(double longitude, double latitude)
        {
            if (CarLocationEvent != null)
                CarLocationEvent(longitude, latitude);
        }
        public async void SendOnBoard()
        {
            await hubProxy.SendOnBoard(currentCar.CarId, currentUser.ClientId);
        }

        public async void SendArriveToDestination()
        {
            await hubProxy.SendArriveToDestination(currentCar.CarId);
            await hubProxy.Disconnect(currentCar.CarId);

        }

       

        public GooglePlace RouteOrigin { get; private set; }
        public GooglePlace RouteDestination { get; private set; }
        public GooglePlace RouteCarLocation { get; private set; }
        public GoogleDirection ClientRouteDirections { get; private set; }
        public GoogleDirection CarRouteDirections { get; private set; }

        public event Action OnUpdateMapEvent;

       
        public async void OnGo()
        {
            try
            {
               

                GoogleMapsApiService service = new GoogleMapsApiService();

                GooglePlaceAutoCompleteResult originPlaces = await service.GetPlaces(origin);
                GooglePlaceAutoCompleteResult destPlaces = await service.GetPlaces(destination);
                GooglePlaceAutoCompleteResult carPlace = await service.GetPlaces(carLocation);
                //extract the exact first google place for origin and destination

                GooglePlace place1 = await service.GetPlaceDetails(originPlaces.AutoCompletePlaces[0].PlaceId);
                GooglePlace place2 = await service.GetPlaceDetails(destPlaces.AutoCompletePlaces[0].PlaceId);
                GooglePlace place3 = await service.GetPlaceDetails(carPlace.AutoCompletePlaces[0].PlaceId);
                //get directions to move from origin to destination
                GoogleDirection Clientdirection = await service.GetDirections($"{place1.Latitude}", $"{place1.Longitude}", $"{place2.Latitude}", $"{place2.Longitude}");
                GoogleDirection Cardirection = await service.GetDirections($"{place3.Latitude}", $"{place3.Longitude}", $"{place1.Latitude}", $"{place1.Longitude}");
                //update the properties so the main page class will have access to the information and fire the event to update the map
                RouteOrigin = place1;
                RouteDestination = place2;
                RouteCarLocation = place3;
                ClientRouteDirections = Clientdirection;
                CarRouteDirections = Cardirection;
                if (OnUpdateMapEvent != null)
                    OnUpdateMapEvent();


                App theApp = (App)App.Current;



               // ConnectToProxy();


            }
            catch (Exception e)
            {
                Console.WriteLine("cant find route");
            }


        }












    }
}

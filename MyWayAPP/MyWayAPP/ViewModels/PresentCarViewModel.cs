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


        public ICommand NevigateToCardView => new Command(Gotomap);
        void Gotomap()
        {
            Page p = new CreditCardView();
            App.Current.MainPage = p;

        }
        private Client currentUser;
        private Car currentCar;
        public PresentCarViewModel()
        {
            App theApp = (App)App.Current;
            this.currentCar = theApp.CurrentCar;
            this.currentUser = theApp.CurrentUser;
            hubProxy = new LocationProxy();
            ConnectToProxy();
            hubProxy.RegisterToupdateCarLocation(SetCarLocation);
            

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

    }
}

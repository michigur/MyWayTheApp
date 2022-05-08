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


        public PresentCarViewModel()
        {
            App theApp = (App)App.Current;
            Car currentUser = theApp.CurrentCar;
            if (currentUser != null)
            {
                this.Currentlocation = currentUser.CarCurrentLocation;
            }


        }
    }
}

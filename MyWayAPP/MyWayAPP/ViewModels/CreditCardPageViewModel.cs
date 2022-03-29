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

namespace MyWayAPP.ViewModels
{
    class CreditCardPageViewModel : INotifyPropertyChanged
    {

        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string CardExpirationDate { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        public ICommand gotomap => new Command(Gotomap);
        void Gotomap()
        {
            Page p = new ShowMap();
            App.Current.MainPage = p;

        }

    }
}

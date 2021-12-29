using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyWayAPP.Services;
using MyWayAPP.Views;
using MyWayAPP.Models;
using Xamarin.Essentials;
using System.Linq;

namespace MyWayAPP.ViewModels
{
    class TabPageSampleViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        public ICommand SubmitCommand { protected set; get; }
        //public TabPageSampleViewModel()
        //{
        //    SubmitCommand = new Command(OnSubmit2);
        //}

        //public async void OnSubmit2()
        //{
            
        //    Page p = new MapFirstTry();
        //        App.Current.MainPage = p;

        //}
    }
}

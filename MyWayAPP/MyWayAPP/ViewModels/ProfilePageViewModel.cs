using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using MyWayAPP.Services;
using MyWayAPP.Models;
using Xamarin.Essentials;
using System.Linq;
using MyWayAPP.Views;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
namespace MyWayAPP.ViewModels
{
    class ProfilePageViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion




        #region FirstName
        private string name;

        public string FName
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("FName");
            }
        }
        #endregion

        #region UserName
        private string userName;
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        #endregion


        #region Email
        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        #endregion


        #region BirthDate
        private DateTime birthDate;
        public DateTime Birthday
        {
            get => birthDate;
            set
            {
                birthDate = value;
                OnPropertyChanged("Birthday");
            }
        }
        #endregion



        #region Gender
        private string gender;
        public string Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }
        #endregion




        public ProfilePageViewModel()
        {
            App theApp = (App)App.Current;
            Client currentUser = theApp.CurrentUser;
            if (currentUser != null)
            {
                this.Email = currentUser.ClientsEmail;
                this.UserName = currentUser.ClientsUsername;
                this.FName = currentUser.ClientName;
                //this.LastName = currentUser.LastName;
                this.Birthday = currentUser.ClientsBirthDay;
                this.Gender = currentUser.ClientsGenedr;
            }

            
        }



        public ICommand NevigateToUpdate => new Command(ToUpdate);
        void ToUpdate()
        {

            Page p = new Update();
            App.Current.MainPage = p;
        }


        public ICommand ShowMap => new Command(showMap);
        void showMap()
        {

            Page p = new ShowMap();
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



    }
}

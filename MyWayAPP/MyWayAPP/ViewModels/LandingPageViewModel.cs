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
    class LandingPageViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public ICommand NevigateToSignUp => new Command(ToSignIn);
        void ToSignIn()
        {

            Page p = new Register();
            App.Current.MainPage = p;
        }

        public ICommand NevigateToLogIn => new Command(ToLogIn);
        void ToLogIn()
        {

            Page p = new LogInPage();
            App.Current.MainPage = p;
        }
        public LandingPageViewModel()
        {
            Onboardings = GetOnboarding();
        }


        public List<Onboarding> Onboardings { get; set; }
        private List<Onboarding> GetOnboarding()
        {
            return new List<Onboarding>
            {
                new Onboarding {Heading ="sample heading", Caption="sample caption"},
                 new Onboarding {Heading ="sample heading2", Caption="sample caption2"},
                  new Onboarding {Heading ="sample heading3", Caption="sample caption3"}
            };
        }





    }

    public class Onboarding
    {
        public string Heading { get; set; }
        public string Caption { get; set; }
    }
}

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
using System.Collections.ObjectModel;


namespace MyWayAPP.ViewModels
{

    public class Menu
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public ContentPage page { get; set; }
    }




    class Page1SampleViewModel : INotifyPropertyChanged
    {


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public Page1SampleViewModel()
        {
            MenuItems = GetMenus();
        }

        public ObservableCollection<Menu> MenuItems { get; set; }


        public ObservableCollection<Menu> GetMenus()
        {
            return new ObservableCollection<Menu>
            {
                new Menu { Title = "PROFILE", Icon = "accountOutline.png", page = new ProfilePage() },
                new Menu { Title = "ROUTE", Icon = "carHatchback.png" , page = new ShowMap()},
                new Menu { Title = "SIGN OUT", Icon = "logout.png", page = new LandingPage() }
            };
        }

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
        //    TitleTxt.Text = ((sender as StackLayout).BindingContext as Menu).Title;
        //    Hide();
        //}

        //public ICommand NevigateToPage => new Command(GoToPage);
       
        //void GoToPage(object sender)
        //{
        //    ContentPage p = ((sender as StackLayout).BindingContext as Menu).page;
        //    App.Current.MainPage = p;
        //}


    }
}

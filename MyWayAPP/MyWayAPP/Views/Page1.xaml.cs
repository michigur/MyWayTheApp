using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyWayAPP.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MyWayAPP.Views;

namespace MyWayAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            MenuItems = GetMenus();
            this.BindingContext = this;
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

        private async void Show()
        {

            _ = TitleTxt.FadeTo(0);
            _ = MenuItemsView.FadeTo(1);
            await MainMenuView.RotateTo(0, 300, Easing.BounceOut);
        }

        private async void Hide()
        {
            _ = TitleTxt.FadeTo(1);
            _ = MenuItemsView.FadeTo(0);
            await MainMenuView.RotateTo(-90, 300, Easing.BounceOut);
        }

        private void ShowMenu(object sender, EventArgs e)
        {
            Show();
        }

        private void MenuTapped(object sender, EventArgs e)
        {
            TitleTxt.Text = ((sender as StackLayout).BindingContext as Menu).Title;
            Hide();
        }
        private void GoToPage(object sender, EventArgs e)
        {
            ContentPage p = ((sender as StackLayout).BindingContext as Menu).page;
            Navigation.PushAsync(p);
        }


    }

    public class Menu
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public ContentPage page { get; set; }
    }
}
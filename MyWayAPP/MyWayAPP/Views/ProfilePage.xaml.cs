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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            this.BindingContext = new ProfilePageViewModel();
            InitializeComponent();
        }




        //public ObservableCollection<Menuu> MenuItems { get; set; }



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
        //    TitleTxt.Text = ((sender as StackLayout).BindingContext as Menuu).Title;
        //    Hide();
        //}


        private void Button_Clicked(object sender, EventArgs e)
        {
            ContentPage p = new LandingPage();
            Navigation.PushAsync(p);
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            //ContentPage p = new ProfilePage();
            //Navigation.PushAsync(p);
        }

        private void Button_Clicked2(object sender, EventArgs e)
        {
            ContentPage p = new ShowMap();
            Navigation.PushAsync(p);
        }

    }


    //public class Menuu
    //{
    //    public string Title { get; set; }
    //    public string Icon { get; set; }
    //    public ContentPage page { get; set; }
    //}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;
using MyWayAPP.ViewModels;

namespace MyWayAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            LandingPageViewModel context = new LandingPageViewModel();
            this.BindingContext = context;
            InitializeComponent();
            
        }

       
    }
}
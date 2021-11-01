using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyWayAPP.ViewModels;

namespace MyWayAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            LogInViewModel context = new LogInViewModel();
            this.BindingContext = context;
            InitializeComponent();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.UI.Views;
using MyWayAPP.ViewModels;
using MyWayAPP.Helpers;
using Xamarin.Forms.Maps;


namespace MyWayAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PriceViewPopUp : Popup
    {
        public PriceViewPopUp()
        {
            ShowMapViewModel vm = new ShowMapViewModel();
           
            this.BindingContext = vm;
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }
    }
}
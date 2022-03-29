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
    public partial class CreditCardView : ContentPage
    {
        public CreditCardView()
        {
            InitializeComponent();
            this.BindingContext = new CreditCardPageViewModel();
            
            

           
          
        }
    }
}
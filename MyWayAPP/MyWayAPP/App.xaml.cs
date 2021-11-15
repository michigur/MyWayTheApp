using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyWayAPP.Models;
using MyWayAPP.Views;
using System.Collections.Generic;

namespace MyWayAPP
{
    public partial class App : Application
    {
        public static bool IsDevEnv
        {
            get
            {
                return false; //change this before release!
            }
        }

        //The current logged in user
        public Client CurrentUser { get; set; }

        //The list of phone types
       


        public App()
        {
            InitializeComponent();

            MainPage = new MapFirstTry();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

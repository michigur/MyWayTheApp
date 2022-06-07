using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWayAPP.Services;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using MyWayAPP.Models;

namespace MyWayAPP.Models
{
    class ConectedCar:Car
    {

        //private LocationProxy Proxy;

        //public ConectedCar()
        //{
        //    //Open connection to delivery proxy
        //    this.Proxy = new LocationProxy();
        //    Device.StartTimer(TimeSpan.FromSeconds(10), () => OnTimer());
        //    ConnectToServer();
        //}



        //private async void ConnectToServer()
        //{
        //    int? RouteID = 0;
        //    await this.Proxy.Connect(RouteID);
        //}



        //private bool OnTimer()
        //{
        //    var location = GetLocation();

        //    return true;
        //}


        //private async Task<bool> GetLocation()
        //{
        //    try
        //    {
        //        var location = await Geolocation.GetLastKnownLocationAsync();

        //        if (location != null)
        //        {


        //            await this.Proxy.UpdateLocation(CarId ,location.Latitude.ToString(), location.Longitude.ToString());
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Unable to get location
        //    }
        //    return true;
        //}


    }
}

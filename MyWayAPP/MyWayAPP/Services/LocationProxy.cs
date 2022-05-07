using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyWayAPP.Services
{
    class LocationProxy
    {

        private const string CLOUD_URL = "http://10.0.2.2:9380/mywayAPI"; //API url when going on the cloud
        private const string CLOUD_PHOTOS_URL = "http://10.0.2.2:9380/Images/";
        private const string DEV_ANDROID_EMULATOR_URL = "http://10.0.2.2:9380/mywayAPI"; //API url when using emulator on android
        private const string DEV_ANDROID_PHYSICAL_URL = "http://192.168.1.14:9380/mywayAPI"; //API url when using physucal device on android
        private const string DEV_WINDOWS_URL = "https://localhost:44312/mywayAPI"; //API url when using windoes on development
        private const string DEV_ANDROID_EMULATOR_PHOTOS_URL = "http://10.0.2.2:9380/Images/"; //API url when using emulator on android
        private const string DEV_ANDROID_PHYSICAL_PHOTOS_URL = "http://192.168.1.14:9380/Images/"; //API url when using physucal device on android
        private const string DEV_WINDOWS_PHOTOS_URL = "https://localhost:44312/Images/"; //API url when using windoes on development

        private readonly HubConnection hubConnection;
        public LocationProxy()
        {
            string Url = GetUrl();
            hubConnection = new HubConnectionBuilder().WithUrl(Url).Build();

        }


        private string GetUrl()
        {
            if (App.IsDevEnv)
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    if (DeviceInfo.DeviceType == DeviceType.Virtual)
                    {
                        return DEV_ANDROID_EMULATOR_URL;
                    }
                    else
                    {
                        return DEV_ANDROID_PHYSICAL_URL;
                    }
                }
                else
                {
                    return DEV_WINDOWS_URL;
                }
            }
            else
            {
                return CLOUD_URL;
            }
        }



        //Connect gets a list of groups the user belongs to!
        public async Task Connect(int? RouteID)
        {
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("OnConnect", RouteID);
        }


        public async Task Disconnect(int? RouteID)
        {
            await hubConnection.InvokeAsync("OnDisconnect", RouteID);
            await hubConnection.StopAsync();

        }

        public async Task UpdateLocation(int? CarID, string latitude, string longitude)
        {

            await hubConnection.InvokeAsync("UpdateDeliveryLocation", CarID, latitude, longitude);

        }

        //this method register a method to be called upon receiving a message
        public void RegisterToUpdateOrderStatus(Action<string, string> UpdateOrderStatus)
        {
            hubConnection.On("UpdateOrderStatus", UpdateOrderStatus);
        }
        //this method register a method to be called upon receiving a message from specific group
        public void RegisterToUpdateDeliveryLocation(Action<string, string> UpdateDeliveryLocation)
        {
            hubConnection.On("UpdateDeliveryLocation", UpdateDeliveryLocation);
        }
    }
}

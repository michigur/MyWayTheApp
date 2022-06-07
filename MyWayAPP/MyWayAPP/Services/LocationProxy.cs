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

        private const string CLOUD_URL = "http://10.0.2.2:9380/locations"; //API url when going on the cloud
        private const string DEV_ANDROID_EMULATOR_URL = "http://10.0.2.2:9380/locations"; //API url when using emulator on android
        private const string DEV_ANDROID_PHYSICAL_URL = "http://192.168.1.14:9380/locations"; //API url when using physucal device on android
        private const string DEV_WINDOWS_URL = "https://localhost:44312/locations"; //API url when using windoes on development
        
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
        public async Task Connect(int carID)
        {
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("OnConnect", carID);
        }


        public async Task Disconnect(int carID)
        {
            await hubConnection.InvokeAsync("OnDisconnect", carID);
            await hubConnection.StopAsync();

        }

        //This message is sent by the customer to the car, so the car can start driving
        public async Task SendOnBoard(int carID, int clientId)
        {
            await hubConnection.InvokeAsync("SendOnBoard", carID, clientId);
        }

        public async Task SendArriveToDestination(int carID)
        {
            await hubConnection.InvokeAsync("SendArriveToDestination", carID);
        }
        public async Task SendLocation(int CarID, double longitude, double latitude)
        {
            await hubConnection.InvokeAsync("SendLocation", CarID, longitude, latitude);
        }
        

        public void RegisterToUpdateOnBoard(Action<int> UpdateOnBoard)
        {
            hubConnection.On("UpdateOnBoard", UpdateOnBoard);
        }

        public void RegisterToupdateCarLocation(Action<double, double> UpdateLocation)
        {
            hubConnection.On("UpdateCarLocation", UpdateLocation);
        }
        public void RegisterToArrive(Action<int> UpdateArriveToDestination)
        {
            hubConnection.On("UpdateArriveToDestination", UpdateArriveToDestination);
        }
        

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MyWayAPP.Services
{
    public interface IlocationService
    {

        Task Connect(int CarID);
        //Task Connect(string groupName);
        Task Disconnect(int CarID);
        //Task Disconnect(string groupName);
        Task SendOnBoard(int CarID, int CLIENTId);
        Task SendLocation(int CarID, double longitude, double latitude);
        Task SendArriveToDestination(int CarID);
        void RegisterToOnBoard(Action<int> UpdateOnBoard);
      
        void RegisterToLocation(Action<double, double> UpdateLocation);
        void RegisterToArrive(Action UpdateLocation);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyWayAPP.Models
{
    public partial class ClientInCar
    {
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public int StatusId { get; set; }
        public bool ClientOnBoard { get; set; }

        public virtual Car car { get; set; }
        public virtual Client client { get; set; }
        
    }
}

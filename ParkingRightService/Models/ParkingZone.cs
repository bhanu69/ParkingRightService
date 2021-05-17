using System;
using System.Collections.Generic;

namespace ParkingRightService.Models
{
    public class ParkingZone : MetaData
    {
        public int id { get; set; }

        public String Zone { get; set; }

        public ICollection<ParkingRequest> ParkingRequests { get; set; }
    }
}

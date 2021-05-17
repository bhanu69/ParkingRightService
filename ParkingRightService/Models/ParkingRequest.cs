using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRightService.Models
{
    public class ParkingRequest : MetaData
    {
        public int id { get; set; }

        public String LicensePlateNumber { get; set; }       

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public String Amount { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Guid ParkingRightID { get; set; }

        public int ParkingZoneId { get; set; }
        public ParkingZone parkingZone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRightService.Models
{
    public class User : MetaData
    {
        public int Id { get; set; }

        public String FullName { get; set; }

        public String Email { get; set; }

        public String UserType { get; set; }

        public ICollection<ParkingRequest> ParkingRequests { get; set; }

    }
}

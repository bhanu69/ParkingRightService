using ParkingRightService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRightService.Repository
{
   public interface IParkingRequestRepository
    {
        List<ParkingRequest> GetData();
        bool AddNewrequest(ParkingRequest _prequest);
    }
}

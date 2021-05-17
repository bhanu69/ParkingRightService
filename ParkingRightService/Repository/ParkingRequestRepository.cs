using Microsoft.EntityFrameworkCore;
using ParkingRightService.DBContext;
using ParkingRightService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingRightService.Repository
{
    public class ParkingRequestRepository : IParkingRequestRepository
    {
        private readonly ParkingDBContext _dbContext;       

        public ParkingRequestRepository(ParkingDBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public List<ParkingRequest> GetData()
        {
            return _dbContext.ParkingRequest.Include(s=>s.User).Include(a=>a.parkingZone).ToList();
        }

        public bool AddNewrequest(ParkingRequest _prequest)
        {
            _dbContext.Add(_prequest);
            _dbContext.SaveChanges();
            return true;
        }
    }
}

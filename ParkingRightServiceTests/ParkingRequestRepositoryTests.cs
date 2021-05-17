using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ParkingRightService.DBContext;
using ParkingRightService.Models;
using ParkingRightService.Repository;
using System;
using System.Collections.Generic;

namespace ParkingRightServiceTests
{
    public class ParkingRequestRepositoryTests
    {
                   [Test]
        public void Get_ParkingrequestData_Whenexists()
        {

            //Arragnge
            var options = new DbContextOptionsBuilder<ParkingDBContext>()
           .UseInMemoryDatabase(databaseName: "ParkingDatabase")
           .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ParkingDBContext(options))
            {
                context.ParkingRequest.Add(new ParkingRequest
                {
                    id = 1,
                    LicensePlateNumber = "BGH-123",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Amount = "100",
                    UserId = 1,
                    ParkingRightID = new Guid(),
                    ParkingZoneId = 1,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = null,
                    CreatedBy = 1,
                    LastModifiedBy = null,
                    IsActive = true
                });
                context.SaveChanges();
            }
            // Use a clean instance of the context to run the test Act
            using (var context = new ParkingDBContext(options))
            {
                ParkingRequestRepository ParkingRepository = new ParkingRequestRepository(context);
                List<ParkingRequest> Parking = ParkingRepository.GetData();
    
                     Assert.AreEqual(1, Parking.Count);
            }

            
        }

    }
}
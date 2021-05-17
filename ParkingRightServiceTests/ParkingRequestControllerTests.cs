using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ParkingRightService.Controllers;
using ParkingRightService.Models;
using ParkingRightService.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingRightServiceTests
{
    class ParkingRequestControllerTests
    {

        [Test]
        public async Task Controller_Given_Content_Should_Return_Ok_post()
        {
            //Arrange
            var input = new ParkingRequest
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
            };

          
            var mockParkingRequestRepository = new Mock<IParkingRequestRepository>();
            var mockLogger = new Mock<Microsoft.Extensions.Logging.ILogger<ParkingRequestController>>();
            // Act
            mockParkingRequestRepository.Setup(p => p.AddNewrequest(input)).Returns(true);
            var _controller = new ParkingRequestController(mockParkingRequestRepository.Object, mockLogger.Object);
            var result =await  _controller.Post(input);
            OkObjectResult okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.AreEqual(input.ParkingRightID, okResult.Value);
        }
    }
}

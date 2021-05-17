using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkingRightService.Models;
using ParkingRightService.Repository;
using System;
using System.Threading.Tasks;

namespace ParkingRightService.Controllers
{
    /// <summary>
    /// used to get and update parking request details
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingRequestController : ControllerBase
    {
        private readonly IParkingRequestRepository _prepository;
        private readonly ILogger _logger;
       
        public ParkingRequestController(IParkingRequestRepository prepository, ILogger<ParkingRequestController> logger)
        {
            this._prepository = prepository;
            this._logger = logger;
        }

        /// <summary>
        /// This method is used to get available parking request information
        /// </summary>
        /// <param name="prepository"></param>
        [HttpGet]
        // GET: ParkingRequestController
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation("Log message in the get() method");
                var ListOfRequests = await Task.Run(() => _prepository.GetData()); 
                return new  OkObjectResult( ListOfRequests);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error,ex, "Error");
                return new BadRequestObjectResult(ex);
            }
        }
        /// <summary>
        /// This method is used to add new parking request information
        /// </summary>
        /// <param name="prepository"></param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ParkingRequest parking)
        {
            try
            {
                parking.ParkingRightID = Guid.NewGuid();
                parking.CreatedBy = 1;
                parking.CreatedDate = DateTime.Now;
                parking.IsActive = true;

                await Task.Run(() => _prepository.AddNewrequest(parking));
                return new OkObjectResult(parking.ParkingRightID);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, "Error");
                return new BadRequestObjectResult(ex);
            }
        }
    }
}

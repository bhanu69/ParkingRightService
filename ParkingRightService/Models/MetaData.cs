using System;

namespace ParkingRightService.Models
{
    public class MetaData
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public long CreatedBy { get; set; }
        public long? LastModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

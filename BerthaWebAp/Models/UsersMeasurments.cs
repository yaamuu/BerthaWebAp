using System;
using System.Collections.Generic;

namespace BerthaWebAp.Models
{
    public partial class UsersMeasurments
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public DateTime Date { get; set; }
        public double BloodPressure { get; set; }
        public double Pulse { get; set; }
        public double Temperature { get; set; }

        public Location Location { get; set; }
        public Users User { get; set; }
    }
}

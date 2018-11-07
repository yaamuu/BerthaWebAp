using System;
using System.Collections.Generic;

namespace BerthaWebAp.Models
{
    public partial class LocationMeasurments
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string AirCondition { get; set; }
        public double Co2 { get; set; }
        public double No2 { get; set; }
        public double So2 { get; set; }
        public DateTime Date { get; set; }

        public Location Location { get; set; }
    }
}

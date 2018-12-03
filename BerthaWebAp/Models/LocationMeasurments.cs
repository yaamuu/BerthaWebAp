using System;
using System.Collections.Generic;

namespace BerthaWebAp.Models
{
    public partial class LocationMeasurments
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string AirCondition { get; set; }
        public string temperature { get; set; }
        public string pressure { get; set; }
        public string humidity { get; set; }
        public DateTime Date { get; set; }

        public Location Location { get; set; }
    }
}

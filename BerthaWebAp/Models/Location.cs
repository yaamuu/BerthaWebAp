using System;
using System.Collections.Generic;

namespace BerthaWebAp.Models
{
    public partial class Location
    {
        public Location()
        {
            LocationMeasurments = new HashSet<LocationMeasurments>();
            UsersMeasurments = new HashSet<UsersMeasurments>();
        }

        public int Id { get; set; }
        public string Location1 { get; set; }
        public string Coordinates { get; set; }

        public ICollection<LocationMeasurments> LocationMeasurments { get; set; }
        public ICollection<UsersMeasurments> UsersMeasurments { get; set; }
    }
}

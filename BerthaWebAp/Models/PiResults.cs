using System;
using System.Collections.Generic;

namespace BerthaWebAp.Models
{
    public partial class PiResults
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}

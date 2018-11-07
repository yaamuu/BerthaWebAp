using System;
using System.Collections.Generic;

namespace BerthaWebAp.Models
{
    public partial class Users
    {
        public Users()
        {
            UsersMeasurments = new HashSet<UsersMeasurments>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<UsersMeasurments> UsersMeasurments { get; set; }
    }
}

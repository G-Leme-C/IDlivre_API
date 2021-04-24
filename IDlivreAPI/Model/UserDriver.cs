using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IDlivreAPI.Model
{
    public class UserDriver
    {
        public int Id { get; set; }

        [Required]
        public string DriversLicense { get; set; }

        [Required]
        public string VehicleDescription { get; set; }
        public string CO2ReducedPerKm { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}

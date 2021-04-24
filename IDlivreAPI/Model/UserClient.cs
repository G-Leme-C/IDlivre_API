using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IDlivreAPI.Model
{
    public class UserClient
    {
        public int Id { get; set; }
        public string RG { get; set; }

        [Required]
        public string CPF { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IDlivreAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Telefone { get; set; }

        [JsonIgnore]
        public UserClient UserClient { get; set; }

        [JsonIgnore]
        public UserDriver UserDriver { get; set; }
    }
}

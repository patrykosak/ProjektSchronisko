using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSchronisko.Models
{
    public class VolunteerUser : IdentityUser
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }
        public int Age { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(150)]
        public string City { get; set; }
        [MaxLength(12)]
        public string PostalCode { get; set; }
    }
}

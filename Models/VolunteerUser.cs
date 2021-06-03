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
        [Required(ErrorMessage = "Należy wypełnić to pole!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Należy wypełnić to pole!")]
        [MaxLength(100, ErrorMessage = "Należy wypełnić to pole!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Należy wypełnić to pole!")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Należy wypełnić to pole!")]
        [MaxLength(200)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Należy wypełnić to pole!")]
        [MaxLength(150)]
        public string City { get; set; }
        [Required(ErrorMessage = "Należy wypełnić to pole!")]
        [MaxLength(12)]
        public string PostalCode { get; set; }
    }
}

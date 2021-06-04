using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSchronisko.Models
{
    public class ReportAnimal
    {
        [Key]
        public Guid IdReport { get; set; }
        [Required(ErrorMessage = "Należy wybrać typ zgłoszenia!")]
        [Display(Name = "Typ zgłoszenia")]
        public TypeReport TypeReport { get; set; }
        public String AdderId { get; set; }
        [MaxLength(10000)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Należy podać miasto!")]
        [MaxLength(100)]
        [Display(Name = "Miasto")]
        public string City { get; set; }
        [Required(ErrorMessage = "Należy podać ulicę!")]
        [MaxLength(100)]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime AddDate { get; set; }
        [Required(ErrorMessage = "Proszę podać imię!")]
        [MaxLength(40)]
        [Display(Name = "Imię")]
        public string AnimalName { get; set; }
        public string PhotoPath { get; set; }

    }
}

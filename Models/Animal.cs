using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSchronisko.Models
{
    public class Animal
    {
        [Key]
        public Guid IdAnimal { get; set; }
        [MaxLength(40)]
        [Display(Name="Imię")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Gatunek")]
        public TypeAnimal TypeAnimale { get; set; }
        [Display(Name = "Wiek")]
        public Age AgeAnimal { get; set; }
        public String AdderId { get; set; }
        [Display(Name = "Rasa")]
        public Race RaceAnimal { get; set; }
        [Display(Name = "Data dodania")]
        public DateTime AddDate { get; set; }
        [Display(Name = "Zdjęcie")]
        public string PhotoPath { get; set; }
        [Display(Name = "Link do zdjęcia")]
        public string PhotoPathURL { get; set; }

    }
}

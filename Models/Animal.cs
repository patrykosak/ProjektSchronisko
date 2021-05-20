using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSchronisko.Models
{
    public class Animal
    {
        public Guid IdAnimal { get; set; }
        public string Name { get; set; }
        public TypeAnimal TypeAnimale { get; set; }
        public Age AgeAnimal { get; set; }
        public Guid AdderId { get; set; }
        public Race RaceAnimal { get; set; }
    }
}

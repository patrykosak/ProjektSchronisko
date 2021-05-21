using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.Animals
{
    public class IndexModel : PageModel
    {
        private readonly ProjektSchronisko.AppData.AnimalsContext _context;

        public IndexModel(ProjektSchronisko.AppData.AnimalsContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string TypeSort { get; set; }
        public string AgeSort { get; set; }
        public string RaceSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<Animal> Animal { get;set; }
        public string SearchTerm { get; set; }
        public TypeAnimal type { get; set; }
        public Age age { get; set; }
        public Race race { get; set; }
        public async Task OnGetAsync(string sortOrder, string SearchTerm, TypeAnimal type, Age age, Race race)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            TypeSort = sortOrder == "Type" ? "type_desc" : "Type";
            AgeSort = sortOrder == "Age" ? "age_desc" : "Age";
            RaceSort = sortOrder == "Race" ? "race_desc" : "Race";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            IQueryable<Animal> animalIQ = from s in _context.Animals
                                          select s;

            switch (sortOrder)
            {
                case "name_desc":
                    animalIQ = animalIQ.OrderByDescending(s => s.Name);
                    break;
                case "Type":
                    animalIQ = animalIQ.OrderBy(s => s.TypeAnimale);
                    break;
                case "type_desc":
                    animalIQ = animalIQ.OrderByDescending(s => s.TypeAnimale);
                    break;
                case "Age":
                    animalIQ = animalIQ.OrderBy(s => s.AgeAnimal);
                    break;
                case "age_desc":
                    animalIQ = animalIQ.OrderByDescending(s => s.AgeAnimal);
                    break;
                case "Race":
                    animalIQ = animalIQ.OrderBy(s => s.RaceAnimal);
                    break;
                case "race_desc":
                    animalIQ = animalIQ.OrderByDescending(s => s.RaceAnimal);
                    break;
                case "Date":
                    animalIQ = animalIQ.OrderBy(s => s.AddDate);
                    break;
                case "date_desc":
                    animalIQ = animalIQ.OrderByDescending(s => s.AddDate);
                    break;
                default:
                    animalIQ = animalIQ.OrderBy(s => s.AddDate);
                    break;
            }
            if (string.IsNullOrEmpty(SearchTerm))
                Animal = await animalIQ.AsNoTracking().ToListAsync();
            else {
                Animal = animalIQ.ToList().Where(e => e.Name.ToUpper().Contains(SearchTerm.ToUpper()) &&
                e.AgeAnimal.Equals(age)&&
                e.RaceAnimal.Equals(race)&&
                e.TypeAnimale.Equals(type)
                ).ToList();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.Reports
{
    public class ReportAboutLossOfPetModel : PageModel
    {
        private readonly AnimalsContext _context;
        public IEnumerable<ReportAnimal> ReportsAnimal { get; set; }
        public string SearchTerm { get; set; }

        public ReportAboutLossOfPetModel(AnimalsContext context)
        {
            _context = context;
        }

        public void OnGet(string SearchTerm)
        {
            var queryLossOfPet = _context.ReportAnimal
                .Where(r => r.TypeReport == TypeReport.LossOfPet);

            if (string.IsNullOrEmpty(SearchTerm))
                ReportsAnimal = queryLossOfPet.ToList();
            else
            {
                var queryLossOfPetWithSearchTerm = queryLossOfPet
                    .Where(r => r.City.ToLower().Contains(SearchTerm.ToLower()));
                ReportsAnimal = queryLossOfPetWithSearchTerm.ToList();
            }
        }
    }
}

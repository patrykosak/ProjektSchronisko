using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.Reports
{
    [Authorize]
    public class ReportsModel : PageModel
    {
        private readonly AnimalsContext _context;
        public IEnumerable<ReportAnimal> ReportsAnimal { get; set; }
        public string SearchTerm { get; set; }
        public ReportsModel(AnimalsContext context)
        {
            _context = context;
        }
        public void OnGet(string SearchTerm)
        {
            if (string.IsNullOrEmpty(SearchTerm))
                ReportsAnimal = _context.ReportAnimal.ToList();
            else
            {
                var queryPetWithSearchTerm = _context.ReportAnimal
                    .Where(r => r.City.ToLower().Contains(SearchTerm.ToLower()));
                ReportsAnimal = queryPetWithSearchTerm.ToList();
            }
        }
    }
}

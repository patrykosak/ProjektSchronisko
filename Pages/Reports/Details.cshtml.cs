using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.Reports
{
    public class DetailsModel : PageModel
    {
        private readonly AnimalsContext _context;
        public ReportAnimal ReportAnimal { get; set; }

        public DetailsModel(AnimalsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReportAnimal = await _context.ReportAnimal.FirstOrDefaultAsync(m => m.IdReport == id);

            if (ReportAnimal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.WorkHoursAndDays
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ProjektSchronisko.AppData.AnimalsContext _context;

        public DeleteModel(ProjektSchronisko.AppData.AnimalsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WorkHours WorkHours { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkHours = await _context.WorkHours.FirstOrDefaultAsync(m => m.Id == id);

            if (WorkHours == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkHours = await _context.WorkHours.FindAsync(id);

            if (WorkHours != null)
            {
                _context.WorkHours.Remove(WorkHours);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.WorkHoursAndDays
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ProjektSchronisko.AppData.AnimalsContext _context;
        private readonly UserManager<VolunteerUser> _userManager;

        public CreateModel(ProjektSchronisko.AppData.AnimalsContext context, UserManager<VolunteerUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WorkHours WorkHours { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
               // WorkHours.VolonteerId = (Guid)_userManager.GetUserId(User);
                return Page();
            }

            _context.WorkHours.Add(WorkHours);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

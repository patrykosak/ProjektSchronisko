using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.WorkHoursAndDays
{
    [Authorize(Roles = "Volunteer")]
    public class DetailsModel : PageModel
    {
        private readonly AnimalsContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DetailsModel(AnimalsContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public Guid VolunteerId { get; private set; }
        public bool ItIsYourShift { get; private set; }
        public WorkHours WorkHours { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkHours = await _context.WorkHours.FirstOrDefaultAsync(m => m.Id == id);

            ItIsYourShift = Guid.Parse(_userManager.GetUserId(User)) == WorkHours.VolonteerId;

            if (WorkHours == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

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

namespace ProjektSchronisko.Pages.Reports
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly AnimalsContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public DeleteModel(AnimalsContext context, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public ReportAnimal ReportAnimal { get; set; }

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
        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReportAnimal = await _context.ReportAnimal.FindAsync(id);

            if (ReportAnimal != null)
            {
                _context.ReportAnimal.Remove(ReportAnimal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ReportAboutLossOfPet");
        }
    }
}

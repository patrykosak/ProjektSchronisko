
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.WorkHoursAndDays
{
    public class CreateModel : PageModel
    {
        private readonly AnimalsContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CreateModel(AnimalsContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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
                    return Page();
            if(_signInManager.IsSignedIn(User))
                WorkHours.VolonteerId = Guid.Parse(_userManager.GetUserId(User));

            _context.WorkHours.Add(WorkHours);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

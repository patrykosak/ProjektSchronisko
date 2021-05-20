using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.Animals
{
    public class CreateModel : PageModel
    {
        private readonly ProjektSchronisko.AppData.AnimalsContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(ProjektSchronisko.AppData.AnimalsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Animal.AdderId = _userManager.GetUserId(User);
            _context.Animals.Add(Animal);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

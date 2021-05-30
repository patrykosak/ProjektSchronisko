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
    public class DeleteModel : PageModel
    {
        private readonly ProjektSchronisko.AppData.AnimalsContext _context;

        public DeleteModel(ProjektSchronisko.AppData.AnimalsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Animal Animal { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Animal = await _context.Animals.FirstOrDefaultAsync(m => m.IdAnimal == id);

            if (Animal == null)
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

            Animal = await _context.Animals.FindAsync(id);

            if (Animal != null)
            {
                Animal.ifAdopted = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

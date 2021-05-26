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
    public class DetailsModel : PageModel
    {
        private readonly ProjektSchronisko.AppData.AnimalsContext _context;

        public DetailsModel(ProjektSchronisko.AppData.AnimalsContext context)
        {
            _context = context;
        }

        public Animal Animal { get; set; }
        public Boolean ifShow { get; set; } = false;
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
    }
}

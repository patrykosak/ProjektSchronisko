using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Web.Helpers;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.Animals
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly AnimalsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EditModel(AnimalsContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Animal Animal { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Photo != null)
            {
                var FileUpload = Path.Combine(_webHostEnvironment.WebRootPath, "Images", Photo.FileName);
                using (var Fs = new FileStream(FileUpload, FileMode.Create))
                {
                    Animal.PhotoPath = Photo.FileName;
                    await Photo.CopyToAsync(Fs);
                }
                _context.Attach(Animal).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(Animal.IdAnimal))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else {
                _context.Attach(Animal).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./ReportAboutLossOfPet");
        }

        private bool AnimalExists(Guid id)
        {
            return _context.Animals.Any(e => e.IdAnimal == id);
        }
    }
}

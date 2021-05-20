using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    public class EditModel : PageModel
    {
        private readonly ProjektSchronisko.AppData.AnimalsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHostingEnvironment _IHostingEnvironment;
        public EditModel(ProjektSchronisko.AppData.AnimalsContext context, IWebHostEnvironment webHostEnvironment, IHostingEnvironment IHostingEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _IHostingEnvironment = IHostingEnvironment;
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

            var FileUpload = Path.Combine(_IHostingEnvironment.WebRootPath, "Images", Photo.FileName);
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

            return RedirectToPage("./Index");
        }

        private bool AnimalExists(Guid id)
        {
            return _context.Animals.Any(e => e.IdAnimal == id);
        }
    }
}

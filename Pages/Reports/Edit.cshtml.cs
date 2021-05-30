using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.Reports
{
    public class EditModel : PageModel
    {
        private readonly AnimalsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public EditModel(AnimalsContext context, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public ReportAnimal ReportAnimal { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            ReportAnimal = await _context.ReportAnimal.FirstOrDefaultAsync(m => m.IdReport == id);

            if (ReportAnimal == null)
                return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            
            if (Photo != null)
            {
                var FileUpload = Path.Combine(_webHostEnvironment.WebRootPath, "Images", Photo.FileName);
                using (var Fs = new FileStream(FileUpload, FileMode.Create))
                {
                    ReportAnimal.PhotoPath = Photo.FileName;
                    await Photo.CopyToAsync(Fs);
                }
            }
            _context.Attach(ReportAnimal).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./ReportAboutLossOfPet");
        }
    }
}

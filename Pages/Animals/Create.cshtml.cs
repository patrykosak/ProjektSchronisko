using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.Animals
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly AnimalsContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(AnimalsContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public IFormFile Photo { get; set; }

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
            if (_signInManager.IsSignedIn(User))
                Animal.AdderId = _userManager.GetUserId(User);
            Animal.AddDate = DateTime.Now;
            if (Photo != null)
            {
                var FileUpload = Path.Combine(_webHostEnvironment.WebRootPath, "Images", Photo.FileName);
                using (var Fs = new FileStream(FileUpload, FileMode.Create))
                {
                    Animal.PhotoPath = "/Images/"+Photo.FileName;
                    await Photo.CopyToAsync(Fs);
                }
                Animal.ifAdopted = false;
                _context.Animals.Add(Animal);
            }
            
            else
            {
                _context.Animals.Add(Animal);
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

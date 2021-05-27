using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Areas.Identity.Pages.Account.Manage
{
    public class ReportsModel : PageModel
    {
        private readonly AnimalsContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportsModel(AnimalsContext context, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<ReportAnimal> ReportsAnimal { get; set; }
        
        public void OnGet()
        {
            if (!_signInManager.IsSignedIn(User))
                throw new Exception();

            var query = _context.ReportAnimal
                .Where(r => r.AdderId == _userManager.GetUserId(User))
                .OrderBy(r => r.AddDate);

            ReportsAnimal = query.ToList();
        }
    }
}

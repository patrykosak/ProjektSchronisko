using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.WorkHoursAndDays
{
    [Authorize(Roles = "Volunteer")]
    public class IndexModel : PageModel
    {
        private readonly AnimalsContext _animalContext;
        private readonly UserManager<IdentityUser> _userManager;
        public IndexModel(AnimalsContext animalContext,
            UserManager<IdentityUser> userManager)
        {
            _animalContext = animalContext;
            _userManager = userManager;
        }

        public Guid VolunteerId { get; private set; }
        public IList<WorkHours> WorkHours { get;set; }

        public async Task OnGetAsync()
        {
            VolunteerId = Guid.Parse(_userManager.GetUserId(User));

            var query = from a in _animalContext.WorkHours
                        orderby a.From 
                        select a;

            WorkHours = await query.ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.WorkHoursAndDays
{
    public class IndexModel : PageModel
    {
        private readonly ProjektSchronisko.AppData.AnimalsContext _context;

        public IndexModel(ProjektSchronisko.AppData.AnimalsContext context)
        {
            _context = context;
        }

        public IList<WorkHours> WorkHours { get;set; }

        public async Task OnGetAsync()
        {
            WorkHours = await _context.WorkHours.ToListAsync();
        }
    }
}

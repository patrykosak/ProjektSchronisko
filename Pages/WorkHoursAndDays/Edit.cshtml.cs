﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.WorkHoursAndDays
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ProjektSchronisko.AppData.AnimalsContext _context;

        public EditModel(ProjektSchronisko.AppData.AnimalsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WorkHours WorkHours { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkHours = await _context.WorkHours.FirstOrDefaultAsync(m => m.Id == id);

            if (WorkHours == null)
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

            _context.Attach(WorkHours).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkHoursExists(WorkHours.Id))
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

        private bool WorkHoursExists(Guid id)
        {
            return _context.WorkHours.Any(e => e.Id == id);
        }
    }
}

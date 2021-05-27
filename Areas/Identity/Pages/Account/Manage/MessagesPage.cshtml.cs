using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Areas.Identity.Pages.Account.Manage
{
    public class MessagesPageModel : PageModel
    {
        private readonly AnimalsContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IEnumerable<Message> Messages { get; set; }
        public Guid UserId { get; private set; }

        public MessagesPageModel(AnimalsContext context, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
           _context = context;
           _userManager = userManager;
           _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            UserId = Guid.Parse(_userManager.GetUserId(User));

            var conversation = await _context.Conversations
                .Include(m => m.Messages)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (conversation == null)
                return NotFound();

            Messages = conversation.Messages
                .OrderBy(m => m.AddDate);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            if (!ModelState.IsValid)
                return Page();

            var conversation = await _context.Conversations.FirstOrDefaultAsync(c => c.Id == id);
            if (conversation == null)
                return NotFound();

            

            return Page();
        }
    }
}

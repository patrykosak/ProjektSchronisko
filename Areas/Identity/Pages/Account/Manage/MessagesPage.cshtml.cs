using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [BindProperty]
        [Required]
        [MaxLength(1000)]
        [Display(Name = "Wiadomoœæ")]
        public string Message { get; set; }
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
                .OrderByDescending(m => m.AddDate);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
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
                .OrderByDescending(m => m.AddDate);

            if (!ModelState.IsValid)
                return Page();

            Message newMessage = new Message()
            {
                From = Guid.Parse(_userManager.GetUserId(User)),
                AddDate = DateTime.Now,
                MessageU = Message,
                ConversationId = conversation.Id
            };
            await _context.Messages.AddAsync(newMessage);
            await _context.SaveChangesAsync();

            Messages = conversation.Messages
                .OrderByDescending(m => m.AddDate);

            return Page();
        }
    }
}

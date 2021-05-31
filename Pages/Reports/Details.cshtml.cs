using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.Reports
{
    public class DetailsModel : PageModel
    {
        private readonly AnimalsContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
        [Required]
        [MaxLength(1000)]
        [Display(Name = "Wiadomoœæ")]
        public string Message { get; set; }
        public ReportAnimal ReportAnimal { get; set; }

        public DetailsModel(AnimalsContext context, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();
            
            ReportAnimal = await _context.ReportAnimal.FirstOrDefaultAsync(m => m.IdReport == id);

            if (ReportAnimal == null)
                return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (!_signInManager.IsSignedIn(User))
                return Redirect("/Identity/Account/Login");
            
            ReportAnimal = await _context.ReportAnimal.FirstOrDefaultAsync(m => m.IdReport == id);
            if (ReportAnimal == null)
                return NotFound();

            if (!ModelState.IsValid)
                return Page();

            var conversation = _context.Conversations
                .FirstOrDefault(u => (u.User1Id == Guid.Parse(_userManager.GetUserId(User)) && u.User2Id == Guid.Parse(ReportAnimal.AdderId))
                || (u.User1Id == Guid.Parse(ReportAnimal.AdderId) && u.User2Id == Guid.Parse(_userManager.GetUserId(User))));

            if (conversation == null)
            {
                Conversation newConversation = new Conversation
                {
                    User1Id = Guid.Parse(_userManager.GetUserId(User)),
                    User2Id = Guid.Parse(ReportAnimal.AdderId),
                    AddDate = DateTime.Now,
                    Messages = new List<Message>()
                    {
                        new Message()
                        {
                            From = Guid.Parse(_userManager.GetUserId(User)),
                            AddDate = DateTime.Now,
                            MessageU = Message
                        }
                    }
                };
                await _context.Conversations.AddAsync(newConversation);
            }
            else
            {
                Message newMessage = new Message()
                {
                    From = Guid.Parse(_userManager.GetUserId(User)),
                    AddDate = DateTime.Now,
                    MessageU = Message,
                    ConversationId = conversation.Id
                };
                await _context.Messages.AddAsync(newMessage);
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./ReportAboutLossOfPet");
        }
    }
}

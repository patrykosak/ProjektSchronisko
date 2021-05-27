using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Areas.Identity.Pages.Account.Manage
{
    public class ConversationsPageModel : PageModel
    {
        private readonly AnimalsContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IEnumerable<Conversation> Conversations { get; set; }
        public string SearchTerm { get; set; }

        public ConversationsPageModel(AnimalsContext context, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void OnGet(string SearchTerm)
        {
            var queryBase = _context.Conversations
                .Where(u => u.User1Id == Guid.Parse(_userManager.GetUserId(User)) || u.User2Id == Guid.Parse(_userManager.GetUserId(User)));

            if (string.IsNullOrEmpty(SearchTerm))
                Conversations = queryBase.OrderByDescending(u => u.AddDate).ToList();
            else
            {
                // TO DO !!!!! (dodanie Emaila. i daty)
                Conversations = queryBase
                    .OrderByDescending(u => u.AddDate)
                    .ToList();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages
{
    public class AdoptedAnimalsModel : PageModel
    {
        private readonly AppData.AnimalsContext _context;
        public IEnumerable<Animal> Animals { get; set; }

        public AdoptedAnimalsModel(AppData.AnimalsContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Animals = _context.Animals.Where(e => e.ifAdopted == true);
        }
    }
}

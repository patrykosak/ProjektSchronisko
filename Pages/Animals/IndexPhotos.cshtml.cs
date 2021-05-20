using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.Animals
{ 
    public class IndexPhotosModel : PageModel
    {
        private readonly AppData.AnimalsContext _context;
        public IEnumerable<Animal> Animals { get; set; }

    public IndexPhotosModel(AppData.AnimalsContext context)
    {
            _context = context;
    }

    public void OnGet()
    {
            Animals = _context.Animals.ToList();
        }
}
}


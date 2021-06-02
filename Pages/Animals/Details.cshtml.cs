using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IronPdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;

namespace ProjektSchronisko.Pages.Animals
{
    public class DetailsModel : PageModel
    {
        private readonly ProjektSchronisko.AppData.AnimalsContext _context;

        public DetailsModel(ProjektSchronisko.AppData.AnimalsContext context)
        {
            _context = context;
        }

        public Animal Animal { get; set; }
        public Boolean ifShow { get; set; } = false;
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Animal = await _context.Animals.FirstOrDefaultAsync(m => m.IdAnimal == id);

            if (Animal == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(Guid? id) {

            if(id == null) {
                return NotFound();
            }

            Animal = _context.Animals.FirstOrDefault(m => m.IdAnimal == id);

            if(Animal == null) {
                return NotFound();
            }

            CreatePdfExample();
            var rootPath = Directory.GetCurrentDirectory();

            string fileName = "Sample.pdf";

            var filePath = $"{rootPath}/wwwroot/pdf/{fileName}";

            var fileExists = System.IO.File.Exists(filePath);
            if(!fileExists) {
                return NotFound();
            }
            var contentProvider = new FileExtensionContentTypeProvider();
            contentProvider.TryGetContentType(fileName, out string contentType);

            var fileContents = System.IO.File.ReadAllBytes(filePath);
            //
            return File(fileContents, contentType, fileName);
        }
        void CreatePdfExample() {
            var renderer = new HtmlToPdf();

            // tworzymy prosty template oraz ścieżkę zapisu pliku
            string template = "<h1>Nasz pierwszy NIEPDF</h1>";
            string path = "wwwroot/pdf/Sample.pdf";

            var PDF = renderer.RenderHtmlAsPdf(template);
            PDF.SaveAs(path);
        }
    }
}

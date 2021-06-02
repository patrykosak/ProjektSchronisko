using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektSchronisko.AppData;
using ProjektSchronisko.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace ProjektSchronisko.Pages.Animals
{
    public class PdfMakerModel : PageModel
    {
        private readonly AnimalsContext _context;

        public PdfMakerModel(AnimalsContext context) {
            _context = context;
        }

        public Animal Animal { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? id) {
            if(id == null) {
                return NotFound();
            }

            Animal = await _context.Animals.FirstOrDefaultAsync(m => m.IdAnimal == id);

            if(Animal == null) {
                return NotFound();
            }

            //try {
            //    Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
            //    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.);
            //    pdfDoc.Open();
            //    Paragraph Text = new Paragraph("This is test file");
            //    pdfDoc.Add(Text);
            //    pdfWriter.CloseStream = false;
            //    pdfDoc.Close();
            //} catch(Exception ex) { Console.Write(ex.Message); }

            return Page();
        }
    }
}

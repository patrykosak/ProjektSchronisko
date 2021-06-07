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

            CreatePdfExample(Animal);

            var rootPath = Directory.GetCurrentDirectory();

            string fileName = Animal.Name +"_Formularz.pdf";

            var filePath = $"{rootPath}/wwwroot/pdf/Sample.pdf";

            var fileExists = System.IO.File.Exists(filePath);
            if(!fileExists) {
                return NotFound();
            }
            var contentProvider = new FileExtensionContentTypeProvider();
            contentProvider.TryGetContentType(fileName, out string contentType);

            var fileContents = System.IO.File.ReadAllBytes(filePath);
            
            return File(fileContents, contentType, fileName);
        }
        void CreatePdfExample(Animal AAnimal) {
            var renderer = new HtmlToPdf();
            // tworzymy prosty template oraz ścieżkę zapisu pliku
            string template = "<h1 style='text-align: center;'>Formularz adopcyjny zwierzęcia</h1> <br />"
                + "<b>Imię zwierzęcia:</b> " + AAnimal.Name + "<br />"
                + "<b>Gatunek:</b> " + EnumExtensions.GetDisplayName(AAnimal.TypeAnimale) + "<br />"
                + "<b>Rasa:</b> " + EnumExtensions.GetDisplayName(AAnimal.RaceAnimal) + "<br />"
                + "<b>Wiek:</b> " + EnumExtensions.GetDisplayName(AAnimal.AgeAnimal) + "<br /> <br />"
                + "<div style='text-align: center;' >§1</div> <br />"
                + "1.Ilekroć zapisy niniejszej umowy odnoszą się do "
                + "ustawy, rozumie się przez to Ustawę o ochronie zwierząt z dnia  21 sierpnia 1997 r. , oraz Ustawę o ochronie zwierząt wykorzystywanych do "
                + "celów naukowych lub edukacyjnych z dnia 15 stycznia 2015 r.z późniejszymi zmianami."
                + "2.Niniejszy dokument jest zobowiązaniem adopcyjnym, a nie umową kupna. <br /> <br />"
                + "<div style='text-align: center;' >§2</div> <br />"
                + "1.Oddający do adopcji przekazuje zwierzę pod stałą opiekę adoptującego w dniu podpisania przez obie strony niniejszej umowy.<br />"
                + "2.Zwierzę będzie przebywało pod adresem zamieszkania stałego(zameldowania) lub adresem pobytu tymczasowego adoptującego.<br />"
                + "3.Zabrania się przekazania na stałe zwierzęcia przez adoptującego osobom trzecim bez wiedzy i zgody oddającego doadopcji.<br />"
                + "4.Zabrania się sprzedaży zwierzęcia(np.na targu, w sklepie zoologicznym, na aukcji internetowej czy w jakikolwiek inny sposób).<br />"
                + "5.Adoptujący zobowiązuje się nie przeprowadzać zbiórek na rzecz utrzymania adoptowanego zwierzęcia.<br />"
                + "6.Zabrania się przeznaczenia adoptowanego zwierzęcia na pokarm dla ludzi lub zwierząt(np.gadów czy drapieżnych kotów/ ptaków oraz innych zwierząt).<br /><br />"
                + "<div style='text-align: center;' >§3</div> <br />"
                + "1.Adoptujący zobowiązuje się do traktowania zwierzęcia zgodnie z wymogami określonymi w ustawie.<br />"
                + "2.Ponadto adoptujący zobowiązuje się:<br />"
                + "a. Niezwłocznie powiadomić oddającego do adopcji o zaginięciu lub ucieczce zwierzęcia, a także o postawieniu przez weterynarza diagnozy poważnej choroby zwierzęcia.<br />"
                + "b. W przypadku natychmiastowej konieczności uśmiercanie zwierzęcia w okresie 1 miesiąca od adopcji, adoptujący zobowiązuje się powiadomić telefonicznie oddającego do adopcji przed dokonaniem uśpienia.<br />"
                + "c. Zapewnić zwierzęciu właściwe warunki bytowania poprzez zapewnienie zwierzęciu możliwości egzystencji, zgodnie z potrzebami danego gatunku, rasy, płci i wieku.<br />"
                + "d. Zapewnić zwierzęciu wartościowe pożywienie dobrane pod względem wieku, wielkości, trybu życia i temperamentu zwierzęcia.<br />"
                + "e. Zapewnić zwierzęciu nieograniczony i stały dostęp do świeżej i czystej wody.<br />"
                + "f. Zapewnić zwierzęciu należytą opiekę weterynaryjną w szczególności w razie choroby.<br /><br />"
                + "<div style='text-align: center;' >§4</div> <br />"
                + "1.Ocena warunków utrzymania zwierzęcia, jak i wypełniania postanowień niniejszej umowy pozostaje wyłącznie po stronie oddającego do adopcji.W tym celu oddający do adopcji wskazuje dowykonania takiej czynności upoważnioną osobę.<br />"
                + "2.Adoptujący zobowiązuje się do przyjęcia po wcześniejszym umówieniu osoby na wizytę poadopcyjną w celu oceny warunków utrzymania zwierzęcia.<br />"
                + "3.W przypadku stwierdzenia przez osobę wizytującą sytuacji wymagającej jedynie pozostawienia wskazówek i pouczeń, adoptujący zastosuje się do nich.<br />"
                + "4.W przypadku stwierdzenia przez osobę wizytującą nieodpowiednich warunków adoptujący wyraża zgodę na zabranie adoptowanego zwierzęcia z powrotem do oddającego do adopcji.<br />"
                + "<br /><div style='text-align: center;' >§5</div> <br />"
                + "1.Adoptujący w chwili adopcji otrzymuje informację o stanie zdrowia zwierzęcia.<br />"
                + "2.Oddający do adopcji poinformował adoptującego o stanie zdrowia zwierzęcia w maksymalnym zakresie, jaki był możliwy do ustalenia przez oddającego do adopcji przy użyciu dostępnych mu środków.<br />"
                + "3.Adoptujący przyjął do wiadomości informacje o stanie zdrowia zwierzęcia i zobowiązuje się do samodzielnego pokrywania kosztów ewentualnego dalszego leczenia zwierzęcia oraz zrzeka się wszelkich roszczeń z tego tytułu wobec oddającego do adopcji.<br />"
                + "<br /><div style='text-align: center;' >§6</div> <br />"
                + "1.W przypadku stwierdzenia  naruszenia któregokolwiek z zapisów niniejszej umowy, w szczególności naruszenia przepisów ustawy, oddający do adopcji ma prawo odebrać zwierzę adoptującemu. <br />"
                + "2.W przypadku decyzji oddającego do adopcji o odebraniu zwierzęcia adoptujący bezzwłocznie odda zwierzę oraz zrzeknie się wszelkich roszczeń z tego tytułu wobec oddającego do adopcji. <br />"
                + "3.W przypadku stwierdzenia aktów noszących znamiona czynu zabronionego, działając na podstawie art. 304 §1 zd. 1 Postępowania Karnego, oddający do adopcji zawiadomi właściwe organy ścigania o podejrzeniu popełnienia przestępstwa.<br />"
                + "<br /><div style='text-align: center;' >§7</div> <br />"
                + "Jakiekolwiek zmiany w niniejszej umowie mogą być dokonane tylko w formie pisemnej pod rygorem nieważności.Strony nie mogą powoływać się na ustalenia pozaumowne.<br />"
                + "<br /><div style='text-align: center;' >§8</div> <br />"
                + "W sprawach nieuregulowanych niniejszą umową stosuje się przepisy Kodeksu cywilnego. Właściwym do rozstrzygania sporów mogących wyniknąć z realizacji niniejszej umowy jest Sąd właściwy dla siedziby oddającego do adopcji. <br />"
                + "<br /><div style='text-align: center;' >§9</div> <br />"
                + "Umowa została sporządzona w dwóch jednobrzmiących egzemplarzach, po jednym dla każdej ze stron.<br />"
                + "Adoptujący wyraża zgodę na przetwarzanie danych osobowych zbieranych na potrzeby ewidencjonowania procesu adopcyjnego, w tym przeprowadzenie wizyty  poadopcyjnej.Zgoda adoptującego na przetwarzanie danych jest dobrowolna, adoptujący zna swoje prawa w zakresie danych osobowych wynikające z ustawy z dnia 29 sierpnia 1997r.o ochronie danych osobowych, w tym prawo wglądu do swoich danych i ich poprawiania. <br /><br /><br />"
                + " …………………………………………<br />"
                + "pieczątka i podpis osoby oddającej  do adopcji<br /><br />"
                + " …………………………………………<br />"
                + "podpis adoptującego";

            string path = "wwwroot/pdf/Sample.pdf";

            var PDF = renderer.RenderHtmlAsPdf(template);
            PDF.SaveAs(path);
        }
    }
}

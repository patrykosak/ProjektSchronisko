using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSchronisko.Models
{
    public enum TypeAnimal
    {
        [Display(Name = "Pies")]
        Dog,
        [Display(Name = "Kot")]
        Cat,
        [Display(Name = "Inny")]
        Other
    }
    public enum Age
    {
        [Display(Name = "1-3 miesiące")]
        Months13,
        [Display(Name = "3-6 miesięcy")]
        Months36,
        [Display(Name = "6-12 miesięcy")]
        Months612,
        [Display(Name = "1-2 lata")]
        Year,
        [Display(Name = "2-3 lata")]
        Years2,
        [Display(Name = "3-4 lata")]
        Years3,
        [Display(Name = "Starszy")]
        Older

    }
    public enum Race
    {
        [Display(Name = "Jamnik")]
        Dachshund,
        [Display(Name = "Owczarek Niemiecki")]
        GermanShepherd,
        [Display(Name = "Inny")]
        Other
    }
}

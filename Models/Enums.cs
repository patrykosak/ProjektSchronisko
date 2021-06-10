using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

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
        [Display(Name = "5 lat lub starszy")]
        Older

    }
    public enum Race
    {
        [Display(Name = "Jamnik")]
        Dachshund,
        [Display(Name = "Owczarek Niemiecki")]
        GermanShepherd,
        [Display(Name = "Inny")]
        Other,
        [Display(Name = "Border Collie")]
        BorderCollie,
        [Display(Name = "Shiba")]
        Shiba,
        [Display(Name = "Labrador")]
        Labrador,
        [Display(Name = "Husky")]
        Husky,
        [Display(Name = "Buldog")]
        Buldog,
        [Display(Name = "Rottweiler")]
        Rottweiler,
        [Display(Name = "Greyhound")]
        Greyhound,
        [Display(Name = "Bengalski")]
        Bengal,
        [Display(Name = "Perski")]
        Pers,
        [Display(Name = "Dachowiec")]
        Moggy


    }
    public enum TypeReport
    {
        [Display(Name = "Zaniedbane zwierzę")]
        NeglectedPet,
        [Display(Name = "Zagubienie zwierzę")]
        LossOfPet,
        [Display(Name = "Błąkające zwierzę ")]
        WanderingPet
    }



public static class EnumExtensions {
        public static string GetDisplayName(this Enum enumValue) {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}

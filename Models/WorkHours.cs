using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSchronisko.Models {
    public class WorkHours {
        [Key]
        public Guid Id { get; set; }
        [Display(Name ="Od kiedy")]
        public DateTime From { get; set; }
        [Display(Name = "Do kiedy")]
        public DateTime To { get; set; }
        public Guid VolonteerId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSchronisko.Models
{
    public class Conversation
    {
        [Key]
        public Guid Id { get; set; }
        public Guid User1Id { get; set; }
        [MaxLength(10000)]
        public string Email1 { get; set; }
        public Guid User2Id { get; set; }
        [MaxLength(10000)]
        public string Email2 { get; set; }
        public DateTime AddDate { get; set; }


        public virtual List<Message> Messages { get; set; }
    }
}

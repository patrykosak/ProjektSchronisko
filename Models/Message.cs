using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektSchronisko.Models
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        public Guid From { get; set; }
        [Required]
        [MaxLength(31)]
        [Display(Name = "Wiadomość")]
        public string MessageU { get; set; }
        public DateTime AddDate { get; set; }

        public Guid ConversationId { get; set; }
        public virtual Conversation Conversation { get; set; }

    }
}

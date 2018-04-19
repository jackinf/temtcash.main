using System;
using System.ComponentModel.DataAnnotations;

namespace TemtCash.Main.Domain.Model
{
    public class InfoChannelMessage : BaseModel<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime? VisibleUntil { get; set; }

        public bool VisibleForAll { get; set; }

        public bool? Visible { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
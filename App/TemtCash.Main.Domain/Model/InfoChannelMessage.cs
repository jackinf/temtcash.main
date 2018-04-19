using System;

namespace TemtCash.Main.Domain.Model
{
    public class InfoChannelMessage : BaseModel<int>
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime? VisibleUntil { get; set; }

        public bool VisibleForAll { get; set; }

        public bool? Visible { get; set; }

        public string Status { get; set; }
    }
}
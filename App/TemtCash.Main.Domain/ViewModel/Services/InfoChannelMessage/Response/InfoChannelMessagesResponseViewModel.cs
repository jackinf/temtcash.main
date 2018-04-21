using System;

namespace TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage.Response
{
    public class InfoChannelMessagesResponseViewModel
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool IsVisible { get; set; }
    }
}
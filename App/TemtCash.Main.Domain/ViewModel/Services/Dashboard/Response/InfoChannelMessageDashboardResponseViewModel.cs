using System;

namespace TemtCash.Main.Domain.ViewModel.Services.Dashboard.Response
{
    public class InfoChannelMessageDashboardResponseViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
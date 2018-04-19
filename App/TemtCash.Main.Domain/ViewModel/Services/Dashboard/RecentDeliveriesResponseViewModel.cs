using System;

namespace SpeysCloud.Main.Domain.ViewModel.Services.Dashboard
{
    public class RecentDeliveriesResponseViewModel
    {
        public int Id { get; set; }
        public string DeliveryNumber { get; set; }
        public DateTime? Inserted { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime? EstimatedReceiveDate { get; set; }
        public string Status { get; set; }
        public decimal? Total { get; set; }
    }
}
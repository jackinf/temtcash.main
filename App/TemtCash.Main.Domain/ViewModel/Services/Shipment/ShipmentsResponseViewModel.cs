using System;

namespace SpeysCloud.Main.Domain.ViewModel.Services.Shipment
{
    /// <summary>
    /// Properties to display per each shipment when querying for multiple shipments
    /// </summary>
    public class ShipmentsResponseViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Company { get; set; }
        public string Destination { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public decimal? TotalEur { get; set; }
    }
}
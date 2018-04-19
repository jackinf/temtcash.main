using System;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.Domain.Enum;

namespace SpeysCloud.Main.Domain.ViewModel.Services.Shipment
{
    public class ShipmentsRequestViewModel : PaginatedSearchBaseOptionsResult
    {
        public string Company { get; set; }

        public DateTime? DeliveryDateFrom { get; set; }

        public DateTime? DeliveryDateTo { get; set; }

        public ShipmentStatus? Status { get; set; }

        public class OrderFields
        {
            public const string CreatedOn = "CREATEDON";
            public const string Company = "COMPANY";
            public const string Destination = "DESTINATION";
            public const string DeliveryDate = "DELIVERYDATE";
            public const string Status = "STATUS";
        }
    }
}
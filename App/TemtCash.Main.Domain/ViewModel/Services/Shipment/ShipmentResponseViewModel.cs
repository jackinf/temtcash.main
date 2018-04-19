using System;
using System.Collections.Generic;
using SpeysCloud.Main.Domain.Enum;

namespace SpeysCloud.Main.Domain.ViewModel.Services.Shipment
{
    public class ShipmentResponseViewModel
    {
        public string Number { get; set; }
        public string Reference { get; set; }
        public string TransportCompany { get; set; }
        public ShipmentStatus? Status { get; set; }
        public decimal? TotalEur { get; set; }

        public DateTime? EarliestPickupDate { get; set; }
        public DateTime? LatestPickupDate { get; set; }
        public DateTime? EarliestArrivalDate { get; set; }
        public DateTime? LatestArrivalDate { get; set; }

        public string OtherInstructions { get; set; }

        public List<ShipmentDetailsRow> ShipmentDetailsRows { get; set; } = new List<ShipmentDetailsRow>();
        public ShipmentContact Sender { get; set; }
        public ShipmentContact SenderAlternative { get; set; }
        public bool? UseSenderAlternative { get; set; }
        public ShipmentContact Receiver { get; set; }
        public ShipmentContact ReceiverAlternative { get; set; }
        public bool? UseReceiverAlternative { get; set; }

        public class ShipmentContact
        {
            public int? Id { get; set; }
            public string Country { get; set; }
            public string PostCode { get; set; }
            public string City { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string AddressLine3 { get; set; }
            public string CompanyName { get; set; }
            public string ContactPersonName { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Vat { get; set; }

            public bool UpdateContact { get; set; }
        }

        public class ShipmentDetailsRow
        {
            public int? QuantityId { get; set; }
            public int? TypeId { get; set; }
            public float? Length { get; set; }
            public float? Width { get; set; }
            public float? Height { get; set; }
            public float? Weight { get; set; }
            public string ProductDescription { get; set; }
            public string ProductAdditionalInfo { get; set; }
            public bool? DangerousGoods { get; set; }
        }
    }
}
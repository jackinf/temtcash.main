using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SpeysCloud.Core.Extension;
using SpeysCloud.Main.DAL.Model;
using SpeysCloud.Main.Domain.Enum;

namespace SpeysCloud.Main.Domain.Model
{
    public class Shipment : BaseModel<int>
    {
        public string Number { get; set; }
        public string Reference { get; set; }
        public string TransportCompany { get; set; }

        [Column(nameof(Status))]
        public string StatusString
        {
            get { return Status?.ToString() ?? String.Empty; }
            private set { Status = value.ParseEnum<ShipmentStatus>(); }
        }

        [NotMapped]
        public ShipmentStatus? Status { get; set; }
        public decimal? TotalEur { get; set; }

        //
        // Pickup dates and times
        //

        public DateTime? EarliestPickupDate { get; set; }
        public DateTime? LatestPickupDate   { get; set; }
        public DateTime? EarliestArrivalDate { get; set; }
        public DateTime? LatestArrivalDate  { get; set; }

        //
        // Sender
        //
        
        public int? SenderId { get; set; }
        public Address Sender { get; set; }
        public string SenderCountry { get; set; }
        public string SenderPostCode { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddressLine1 { get; set; }
        public string SenderAddressLine2 { get; set; }
        public string SenderAddressLine3 { get; set; }
        public string SenderCompanyName { get; set; }
        public string SenderContactPersonName { get; set; }
        public string SenderPhone { get; set; }
        public string SenderEmail { get; set; }
        public string SenderVat { get; set; }

        //
        // Sender Alternative
        //

        public int? SenderAlternativeId { get; set; }
        public Address SenderAlternative { get; set; }
        public bool? UseSenderAlternative { get; set; }
        public string SenderAlternativeCountry { get; set; }
        public string SenderAlternativePostCode { get; set; }
        public string SenderAlternativeCity { get; set; }
        public string SenderAlternativeAddressLine1 { get; set; }
        public string SenderAlternativeAddressLine2 { get; set; }
        public string SenderAlternativeAddressLine3 { get; set; }
        public string SenderAlternativeCompanyName { get; set; }
        public string SenderAlternativeContactPersonName { get; set; }
        public string SenderAlternativePhone { get; set; }
        public string SenderAlternativeEmail { get; set; }
        public string SenderAlternativeVat { get; set; }

        //
        // Receiver
        //
        
        public int? ReceiverId { get; set; }
        public Address Receiver { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverPostCode { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverAddressLine1 { get; set; }
        public string ReceiverAddressLine2 { get; set; }
        public string ReceiverAddressLine3 { get; set; }
        public string ReceiverCompanyName { get; set; }
        public string ReceiverContactPersonName { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverVat { get; set; }

        //
        // Receiver Alternative
        //
        
        public int? ReceiverAlternativeId { get; set; }
        public Address ReceiverAlternative { get; set; }
        public bool? UseReceiverAlternative { get; set; }
        public string ReceiverAlternativeCountry { get; set; }
        public string ReceiverAlternativePostCode { get; set; }
        public string ReceiverAlternativeCity { get; set; }
        public string ReceiverAlternativeAddressLine1 { get; set; }
        public string ReceiverAlternativeAddressLine2 { get; set; }
        public string ReceiverAlternativeAddressLine3 { get; set; }
        public string ReceiverAlternativeCompanyName { get; set; }
        public string ReceiverAlternativeContactPersonName { get; set; }
        public string ReceiverAlternativePhone { get; set; }
        public string ReceiverAlternativeEmail { get; set; }
        public string ReceiverAlternativeVat { get; set; }

        //
        // Other
        //

        public string OtherInstructions { get; set; }

        //
        // One-2-Many and Many-2-One references
        //

        [InverseProperty(nameof(ShipmentDetail.Shipment))]
        public List<ShipmentDetail> ShipmentDetails { get; set; }
    }
}
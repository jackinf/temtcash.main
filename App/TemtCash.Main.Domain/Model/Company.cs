using System;

namespace TemtCash.Main.Domain.Model
{
    public class Company : BaseModel<int>
    {
        public string ClientCode { get; set; }

        public int PrimaryUserId { get; set; }

        public string Name { get; set; }

        public string RegNo { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string ContactPerson { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public string BusinessArea { get; set; }

        public bool HasStore { get; set; }

        public bool IsActive { get; set; }

        public string Status { get; set; }

        public DateTime? LastInfoUpdateDate { get; set; }

        public string InvoiceFrequency { get; set; }

        public string InvoiceEmail { get; set; }

        // TODO: Do we need VAT number
    }
}
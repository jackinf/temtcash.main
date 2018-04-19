namespace SpeysCloud.Main.DAL.Model
{
    public class Address : BaseModel<int>
    {
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Company { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string KmkRegistrationNumber { get; set; }
        public string TntClientNumber { get; set; }
        public string ContactReference { get; set; }
    }
}
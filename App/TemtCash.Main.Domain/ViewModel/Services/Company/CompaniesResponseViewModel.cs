using System;

namespace TemtCash.Main.Domain.ViewModel.Services.Company
{
    public class CompaniesResponseViewModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ClientCode { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string InvoiceFrequency { get; set; }
        public string InvoiceEmail { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool IsActive { get; set; }
    }
}
namespace TemtCash.Main.Domain.ViewModel.Services.Supplier.Response
{
    public class SupplierResponseViewModel
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Kmkr { get; set; }
        public string RegistrationNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AaInBank { get; set; }
        public string Iban { get; set; }
        public string BicSwift { get; set; }
        public int PaymentPeriodInDays { get; set; }
        public string Comment { get; set; }
    }
}
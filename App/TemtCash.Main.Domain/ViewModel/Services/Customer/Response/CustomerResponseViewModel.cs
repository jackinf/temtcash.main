namespace TemtCash.Main.Domain.ViewModel.Services.Customer.Response
{
    public class CustomerResponseViewModel
    {
        public int Id { get; set; }
        public string UsernameOrEmail { get; set; }
        public string Name { get; set; }
        public bool CompanysMainUser { get; set; }
        public bool IsSeller { get; set; }
        public bool IsActive { get; set; }
    }
}
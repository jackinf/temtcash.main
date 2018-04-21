using TemtCash.Main.Domain.ViewModel.Services.Customer.Response;

namespace TemtCash.Main.Domain.ViewModel.Services.Customer.Request
{
    public class CustomerCreateOrUpdateRequestViewModel : CustomerResponseViewModel
    {
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
    }
}
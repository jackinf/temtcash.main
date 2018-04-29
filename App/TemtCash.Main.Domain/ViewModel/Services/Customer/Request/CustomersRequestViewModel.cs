using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Customer.Response;

namespace TemtCash.Main.Domain.ViewModel.Services.Customer.Request
{
    public class CustomersRequestViewModel : PaginatedSearchBaseOptionsResult
    {
        public class OrderFields
        {
            public static string UsernameOrEmail = nameof(CustomersResponseViewModel.UsernameOrEmail).ToUpperInvariant();
            public static string Name = nameof(CustomersResponseViewModel.Name).ToUpperInvariant();
            public static string Role = nameof(CustomersResponseViewModel.Role).ToUpperInvariant();
            public static string CompanysMainUser = nameof(CustomersResponseViewModel.CompanysMainUser).ToUpperInvariant();
            public static string LastLoginTime = nameof(CustomersResponseViewModel.LastLoginTime).ToUpperInvariant();
            public static string IsActive = nameof(CustomersResponseViewModel.IsActive).ToUpperInvariant();
        }
    }
}
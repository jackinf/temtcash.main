using SpeysCloud.Core.Result;

namespace TemtCash.Main.Domain.ViewModel.Services.SystemUser
{
    public class SystemUsersRequestViewModel : PaginatedSearchBaseOptionsResult
    {
        public class OrderFields
        {
            public static string UsernameOrEmail = nameof(SystemUsersResponseViewModel.UsernameOrEmail).ToUpperInvariant();
            public static string FirstName = nameof(SystemUsersResponseViewModel.FirstName).ToUpperInvariant();
            public static string LastName = nameof(SystemUsersResponseViewModel.LastName).ToUpperInvariant();
            public static string LastLoginTime = nameof(SystemUsersResponseViewModel.LastLoginTime).ToUpperInvariant();
        }
    }
}
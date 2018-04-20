using SpeysCloud.Core.Result;

namespace TemtCash.Main.Domain.ViewModel.Services.Company
{
    public class CompaniesRequestViewModel : PaginatedSearchBaseOptionsResult
    {
        public class OrderFields
        {
            public static string CompanyName = nameof(CompaniesResponseViewModel.CompanyName).ToUpperInvariant();
            public static string ClientCode = nameof(CompaniesResponseViewModel.ClientCode).ToUpperInvariant();
            public static string ContactPerson = nameof(CompaniesResponseViewModel.ContactPerson).ToUpperInvariant();
            public static string ContactPhone = nameof(CompaniesResponseViewModel.ContactPhone).ToUpperInvariant();
            public static string ContactEmail = nameof(CompaniesResponseViewModel.ContactEmail).ToUpperInvariant();
            public static string InvoiceFrequency = nameof(CompaniesResponseViewModel.InvoiceFrequency).ToUpperInvariant();
            public static string InvoiceEmail = nameof(CompaniesResponseViewModel.InvoiceEmail).ToUpperInvariant();
            public static string LastLoginTime = nameof(CompaniesResponseViewModel.LastLoginTime).ToUpperInvariant();
        }
    }
}
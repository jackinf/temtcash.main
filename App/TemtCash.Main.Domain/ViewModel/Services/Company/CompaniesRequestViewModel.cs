using SpeysCloud.Core.Result;

namespace TemtCash.Main.Domain.ViewModel.Services.Company
{
    public class CompaniesRequestViewModel : PaginatedSearchBaseOptionsResult
    {
        public string Keyword { get; set; }

        public class OrderFields
        {
            //public static string Company = nameof(AddressesResponseViewModel.Company).ToUpperInvariant();
            //public static string CityCountry = nameof(AddressesResponseViewModel.CityCountry).ToUpperInvariant();
            //public static string Street = nameof(AddressesResponseViewModel.Street).ToUpperInvariant();
            //public static string Contact = nameof(AddressesResponseViewModel.Contact).ToUpperInvariant();
            //public static string CreationDate = nameof(AddressesResponseViewModel.CreationDate).ToUpperInvariant();
        }
    }
}
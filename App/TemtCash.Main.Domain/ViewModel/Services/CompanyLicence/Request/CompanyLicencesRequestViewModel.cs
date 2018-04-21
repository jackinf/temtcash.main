using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicence.Response;

namespace TemtCash.Main.Domain.ViewModel.Services.CompanyLicence.Request
{
    public class CompanyLicencesRequestViewModel : PaginatedSearchBaseOptionsResult
    {
        public class OrderFields
        {
            public static string LicenceKey = nameof(CompanyLicencesResponseViewModel.LicenceKey).ToUpperInvariant();
            public static string ValidToDate = nameof(CompanyLicencesResponseViewModel.ExpiresOn).ToUpperInvariant();
            public static string LastCheckedDate = nameof(CompanyLicencesResponseViewModel.LincenceUpdatingDateTime).ToUpperInvariant();
            public static string Version = nameof(CompanyLicencesResponseViewModel.Version).ToUpperInvariant();
        }
    }
}
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense.Response;

namespace TemtCash.Main.Domain.ViewModel.Services.CompanyLicense.Request
{
    public class CompanyLicencesRequestViewModel : PaginatedSearchBaseOptionsResult
    {
        public class OrderFields
        {
            public static string LicenceKey = nameof(CompanyLicencesResponseViewModel.LicenceKey).ToUpperInvariant();
            public static string ExpiresOn = nameof(CompanyLicencesResponseViewModel.ExpiresOn).ToUpperInvariant();
            public static string LincenceUpdatingDateTime = nameof(CompanyLicencesResponseViewModel.LincenceUpdatingDateTime).ToUpperInvariant();
            public static string Version = nameof(CompanyLicencesResponseViewModel.Version).ToUpperInvariant();
        }
    }
}
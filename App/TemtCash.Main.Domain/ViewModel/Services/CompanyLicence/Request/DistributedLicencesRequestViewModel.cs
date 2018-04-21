using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense.Response;

namespace TemtCash.Main.Domain.ViewModel.Services.CompanyLicense.Request
{
    public class DistributedLicencesRequestViewModel : PaginatedSearchBaseOptionsResult
    {
        public string ClientName { get; set; }

        public class OrderFields
        {
            public static string ClientName = nameof(DistributedLicencesResponseViewModel.ClientName).ToUpperInvariant();
            public static string LicenceKey = nameof(DistributedLicencesResponseViewModel.LicenceKey).ToUpperInvariant();
            public static string ExpiresOn = nameof(DistributedLicencesResponseViewModel.ExpiresOn).ToUpperInvariant();
            public static string LincenceUpdatingDateTime = nameof(DistributedLicencesResponseViewModel.LincenceUpdatingDateTime).ToUpperInvariant();
            public static string Version = nameof(DistributedLicencesResponseViewModel.Version).ToUpperInvariant();
        }
    }
}
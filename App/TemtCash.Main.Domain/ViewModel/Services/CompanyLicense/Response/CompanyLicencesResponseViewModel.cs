using System;

namespace TemtCash.Main.Domain.ViewModel.Services.CompanyLicense.Response
{
    public class CompanyLicencesResponseViewModel
    {
        public int Id { get; set; }
        public string LicenceKey { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public DateTime? LincenceUpdatingDateTime { get; set; }
        public string Version { get; set; }
    }
}
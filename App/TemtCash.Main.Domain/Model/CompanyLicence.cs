using System;

namespace TemtCash.Main.Domain.Model
{
    /// <summary>
    /// Many-2-Many between company and licence
    /// </summary>
    public class CompanyLicence : BaseModel<int>
    {
        public string LicenceKey { get; set; }

        public DateTime? ValidToDate { get; set; }

        public string ValidToHash { get; set; }

        public string Version { get; set; }

        public DateTime? LastCheckedDate { get; set; }

        // TODO: Do we need this? We can get this information using function which compares UTC with the ValidToDate
        public bool IsActive { get; set; }

        //
        // Foreign references
        //

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int? StoreId { get; set; }
        public Store Store { get; set; }
    }
}
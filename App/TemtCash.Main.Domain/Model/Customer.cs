using System.ComponentModel.DataAnnotations;

namespace TemtCash.Main.Domain.Model
{
    public class Customer : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsCompany { get; set; }

        public string RegCode { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }

        //
        // Foreign references
        //

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int? StoreId { get; set; }
        public Store Store { get; set; }

        public int? ExternalId { get; set; }
    }
}
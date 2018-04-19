using System.ComponentModel.DataAnnotations;

namespace TemtCash.Main.Domain.Model
{
    public class ProductCategory : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Vat { get; set; }
        
        [Required]
        public string Status { get; set; }

        //
        // Foreign references
        //

        public int? ParentId { get; set; }
        public ProductCategory Parent { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int? StoreId { get; set; }
        public Store Store { get; set; }

        // TODO: what is external?
        public int? ExternalId { get; set; }
    }
}
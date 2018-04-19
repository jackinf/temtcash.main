using System.ComponentModel.DataAnnotations;

namespace TemtCash.Main.Domain.Model
{
    public class Product : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public string EanCode { get; set; }

        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        public string Vat { get; set; }

        public string ProductType { get; set; }

        public int? Unit { get; set; }

        public bool? UseProductVat { get; set; }

        [Required]
        public string Status { get; set; }

        public bool? DissallowDiscount { get; set; }

        //
        // Foreign references
        //

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int? ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public int? StoreId { get; set; }
        public Store Store { get; set; }

        // TODO: What is external?
        public int? ExternalId { get; set; }
    }
}
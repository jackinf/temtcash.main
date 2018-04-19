using System.ComponentModel.DataAnnotations;

namespace TemtCash.Main.Domain.Model
{
    public class InvoiceRow : BaseModel<int>
    {
        [Required]
        public int Amount { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Vat { get; set; }

        public int? Discount { get; set; }

        public float? DiscountSum { get; set; }

        public float? NetoSum { get; set; }

        public float? VatSum { get; set; }

        public float? UsedBonusSum { get; set; }

        [Required]
        public string Status { get; set; }

        //
        // Foreign References
        //

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        // TODO: What is external
        public int? ExternalId { get; set; }
    }
}
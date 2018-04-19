using System.ComponentModel.DataAnnotations;

namespace TemtCash.Main.Domain.Model
{
    public class InvoicePaymentType : BaseModel<int>
    {
        [Required]
        public float Sum { get; set; }

        [Required]
        public int PaymentType { get; set; }

        //
        // Foreign references
        //

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int? ExternalId { get; set; }
    }
}
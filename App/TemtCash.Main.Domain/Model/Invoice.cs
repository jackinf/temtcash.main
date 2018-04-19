using System;
using System.ComponentModel.DataAnnotations;

namespace TemtCash.Main.Domain.Model
{
    public class Invoice : BaseModel<int>
    {
        public string Number { get; set; }

        // TODO: Rename
        [Required]
        public DateTime Date { get; set; }

        public DateTime? DueDate { get; set; }

        public int? Discount { get; set; }

        public float? BrutoSum { get; set; }

        public float? NetoSum { get; set; }

        public float? VatSum { get; set; }

        public float? GiftCardSum { get; set; }

        public string Comment { get; set; }

        // TODO: We don't need this because we have seller id, if it references to some model
        public string SellerName { get; set; }

        public int? BonusesUsed { get; set; }

        [Required]
        public string Status { get; set; }

        //
        // Foreign references
        //

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        // TODO: To which model it is referencing to?
        public int? SellerId { get; set; }

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        // TODO: what is external?
        public int? ExternalId { get; set; }
    }
}
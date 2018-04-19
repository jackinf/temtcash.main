using System;

namespace TemtCash.Main.Domain.Model
{
    public class WarehouseItem : BaseModel<int>
    {
        // TODO: Specify, what's a date
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public float PurchacePrice { get; set; }

        //
        // Foreign references
        //

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        /// <summary>
        /// External Id of User
        /// </summary>
        public int UserId { get; set; }

        // TODO: What is external id?
        public int? ExternalId { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
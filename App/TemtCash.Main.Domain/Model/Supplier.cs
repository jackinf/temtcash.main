using System.ComponentModel.DataAnnotations;

namespace TemtCash.Main.Domain.Model
{
    public class Supplier : BaseModel<int>
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public bool IsPerson { get; set; }

        [Required]
        public string Name { get; set; }

        // TODO: Maybe SupplierType is better?
        public string SupType { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Skype { get; set; }

        // TODO: Do we need this? We have reference to the company
        public string CompanyVatNumber { get; set; }

        // TODO: Do we need this? We have reference to the company
        public string CompanyRegNumber { get; set; }

        public string BankAccount { get; set; }

        public string BankIban { get; set; }

        public string BankSwift { get; set; }

        // TODO: Rename: Deadline till what?
        public int DeadlineDays { get; set; }

        public string Status { get; set; }

        public string Comment { get; set; }
    }
}
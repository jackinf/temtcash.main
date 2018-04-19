using System.ComponentModel.DataAnnotations;

namespace TemtCash.Main.Domain.Model
{
    public class Store : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        [Required]
        public string Status { get; set; }

        //
        // Foreign references
        //

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
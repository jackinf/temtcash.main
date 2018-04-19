using System.ComponentModel.DataAnnotations;

namespace TemtCash.Main.Domain.Model
{
    public class ProductUnit : BaseModel<int>
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        public string LangEt { get; set; }

        public string LangEn { get; set; }

        public string LangRu { get; set; }

        // TODO: What is a position?
        public int Position { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
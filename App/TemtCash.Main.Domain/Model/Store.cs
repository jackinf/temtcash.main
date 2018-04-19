namespace TemtCash.Main.Domain.Model
{
    public class Store : BaseModel<int>
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Status { get; set; }
    }
}
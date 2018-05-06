using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;

namespace TemtCash.Main.DAL.Repository
{
    public class ProductCatalogRepository : CrudRepository<Product>, IProductCatalogRepository
    {
        public ProductCatalogRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
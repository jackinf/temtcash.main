using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;

namespace TemtCash.Main.DAL.Repository
{
    public class SupplierRepository : CrudRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
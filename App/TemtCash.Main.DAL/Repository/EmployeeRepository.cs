using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;

namespace TemtCash.Main.DAL.Repository
{
    public class EmployeeRepository : CrudRepository<Customer>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
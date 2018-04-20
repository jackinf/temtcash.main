using System.Threading.Tasks;
using TemtCash.Main.Domain.Model;

namespace TemtCash.Main.Domain.Repository
{
    public interface ICrudRepository<TModel>
        where TModel : BaseModel<int>
    {
        Task AddAsync(TModel model);
        void Delete(TModel model);
        Task<TModel> GetSingleAsync(int id);
        void Update(TModel model);

        Task<int> SaveChangesAsync();
    }
}
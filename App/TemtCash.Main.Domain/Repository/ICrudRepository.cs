using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;

namespace TemtCash.Main.Domain.Repository
{
    public interface ICrudRepository<TModel, in TSearchOptions>
        where TModel : BaseModel<int>
        where TSearchOptions : PaginatedSearchBaseOptionsResult
    {
        Task AddAsync(TModel model);
        void Delete(TModel model);
        Task<TModel> GetSingleAsync(int id);
        Task<int> SaveChangesAsync();
        Task<PaginatedListResult<TModel>> Search(TSearchOptions viewModel);
        void Update(TModel model);
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpeysCloud.Core.Extension;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;

namespace TemtCash.Main.DAL.Repository
{
    public class CrudRepository<TModel, TSearchOptions> : ICrudRepository<TModel, TSearchOptions>
        where TModel : BaseModel<int>
        where TSearchOptions: PaginatedSearchBaseOptionsResult
    {
        protected readonly ApplicationDbContext _context;

        public CrudRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedListResult<TModel>> Search(TSearchOptions viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var query = BaseQuery();
            query = SearchFilter(query, viewModel);
            query = SearchSort(query, viewModel);

            return await query.ToPaginatedListResultAsync(viewModel);
        }

        public async Task<TModel> GetSingleAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Argument should be greater than 0", nameof(id));

            return await BaseQuery().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            model.CreatedOn = DateTime.UtcNow;
            await _context.Set<TModel>().AddAsync(model);
        }

        public void Update(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            model.UpdatedOn = DateTime.UtcNow;
            _context.Set<TModel>().Update(model);
        }

        public void Delete(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "Argument should be greater than 0");

            model.DeletedOn = DateTime.UtcNow;
            _context.Set<TModel>().Update(model);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        protected IQueryable<TModel> BaseQuery() => _context.Set<TModel>().Where(x => x.DeletedOn == null);

        protected virtual IQueryable<TModel> SearchFilter(IQueryable<TModel> query, TSearchOptions viewModel) => query;

        protected virtual IOrderedQueryable<TModel> SearchSort(IQueryable<TModel> query, TSearchOptions viewModel) => query.OrderBy(x => x.Id);
    }
}
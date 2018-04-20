using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;

namespace TemtCash.Main.DAL.Repository
{
    public class CrudRepository<TModel> : ICrudRepository<TModel> where TModel : BaseModel<int>
    {
        protected readonly ApplicationDbContext Context;

        public CrudRepository(ApplicationDbContext context)
        {
            Context = context;
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
            await Context.Set<TModel>().AddAsync(model);
        }

        public void Update(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            model.UpdatedOn = DateTime.UtcNow;
            Context.Set<TModel>().Update(model);
        }

        public void Delete(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "Argument should be greater than 0");

            model.DeletedOn = DateTime.UtcNow;
            Context.Set<TModel>().Update(model);
        }

        public async Task<int> SaveChangesAsync() => await Context.SaveChangesAsync();

        protected IQueryable<TModel> BaseQuery() => Context.Set<TModel>().Where(x => x.DeletedOn == null);
    }
}
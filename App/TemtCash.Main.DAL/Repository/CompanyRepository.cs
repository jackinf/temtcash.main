using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpeysCloud.Core.Extension;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.Company;

namespace TemtCash.Main.DAL.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedListResult<Company>> Search(CompaniesRequestViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            var query = BaseQuery();

            // Filtering
            //if (!string.IsNullOrWhiteSpace(viewModel.Keyword))
            //{
            //    query = query.Where(x => x.Company.Contains(viewModel.Keyword)
            //        || x.City.Contains(viewModel.Keyword)
            //        || x.AddressLine1.Contains(viewModel.Keyword)
            //        || x.AddressLine2.Contains(viewModel.Keyword)
            //        || x.AddressLine3.Contains(viewModel.Keyword)
            //        || x.ContactName.Contains(viewModel.Keyword)
            //    );
            //}

            // Sorting
            string sortName = viewModel.SortName?.ToUpper();
            //if (sortName == CompaniesRequestViewModel.OrderFields.Company)
            //    query = query.OrderUsingSearchOptions(viewModel, x => x.Company);
            //else if (sortName == CompaniesRequestViewModel.OrderFields.CityCountry)
            //    query = query
            //        .OrderUsingSearchOptions(viewModel, x => x.City)
            //        .OrderUsingSearchOptions(viewModel, x => x.Country);
            //else if (sortName == CompaniesRequestViewModel.OrderFields.Street)
            //    query = query.OrderUsingSearchOptions(viewModel, x => x.AddressLine1);
            //else if (sortName == CompaniesRequestViewModel.OrderFields.Contact)
            //    query = query.OrderUsingSearchOptions(viewModel, x => x.ContactName);
            //else if (sortName == CompaniesRequestViewModel.OrderFields.CreationDate)
            //    query = query.OrderUsingSearchOptions(viewModel, x => x.CreatedOn);
            //else
            //    query = query.OrderBy(x => x.Id);

            return await query.ToPaginatedListResultAsync(viewModel);
        }

        public async Task<Company> GetSingleAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id), "Argument should be greater than 0");
            }

            return await BaseQuery().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Company model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.CreatedOn = DateTime.UtcNow;
            await _context.Companies.AddAsync(model);
        }

        public void Update(Company model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            
            model.UpdatedOn = DateTime.UtcNow;
            _context.Companies.Update(model);
        }

        public void Delete(Company model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Argument should be greater than 0");
            }

            model.DeletedOn = DateTime.UtcNow;
            _context.Companies.Update(model);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        private IQueryable<Company> BaseQuery() => _context.Companies.Where(x => x.DeletedOn == null);
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Extension;
using SpeysCloud.Core.Result;
using TemtCash.Main.DAL.Helper;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicence.Request;

namespace TemtCash.Main.DAL.Repository
{
    public class CompanyLicenceRepository : CrudRepository<CompanyLicence>, ICompanyLicenceRepository
    {
        public CompanyLicenceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<PaginatedListResult<CompanyLicence>> Search(CompanyLicencesRequestViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var query = BaseQuery();
            query = SearchFilter(query, viewModel);
            query = SearchSort(query, viewModel);

            return await query.ToPaginatedListResultAsync(viewModel);
        }

        protected IQueryable<CompanyLicence> SearchFilter(IQueryable<CompanyLicence> query, CompanyLicencesRequestViewModel viewModel)
        {
            return query;
        }

        protected IQueryable<CompanyLicence> SearchSort(IQueryable<CompanyLicence> query, CompanyLicencesRequestViewModel viewModel)
        {
            string sortName = viewModel.SortName?.ToUpper();
            if (sortName == CompanyLicencesRequestViewModel.OrderFields.LicenceKey)
                query = query.OrderUsingSearchOptions(viewModel, x => x.LicenceKey);
            else if (sortName == CompanyLicencesRequestViewModel.OrderFields.ValidToDate)
                query = query.OrderUsingSearchOptions(viewModel, x => x.ValidToDate);
            else if (sortName == CompanyLicencesRequestViewModel.OrderFields.LastCheckedDate)
                query = query.OrderUsingSearchOptions(viewModel, x => x.LastCheckedDate);
            else if (sortName == CompanyLicencesRequestViewModel.OrderFields.Version)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Version);
            else 
                query = query.OrderBy(x => x.Id);
            return query;
        }
    }
}
using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense;

namespace TemtCash.Main.DAL.Repository
{
    public class CompanyLicenceRepository : CrudRepository<CompanyLicence>, ICompanyLicenceRepository
    {
        public CompanyLicenceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<PaginatedListResult<Company>> Search(CompanyLicensesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
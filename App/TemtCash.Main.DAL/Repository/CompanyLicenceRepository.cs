using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense.Request;

namespace TemtCash.Main.DAL.Repository
{
    public class CompanyLicenceRepository : CrudRepository<CompanyLicence>, ICompanyLicenceRepository
    {
        public CompanyLicenceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<PaginatedListResult<Company>> Search(CompanyLicencesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
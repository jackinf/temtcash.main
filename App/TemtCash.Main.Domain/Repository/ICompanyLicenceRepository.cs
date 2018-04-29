using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicence.Request;

namespace TemtCash.Main.Domain.Repository
{
    public interface ICompanyLicenceRepository : ICrudRepository<CompanyLicence>
    {
        Task<CompanyLicence> GetSingleByCompanyAsync(int companyId, int id);
        Task<PaginatedListResult<CompanyLicence>> Search(CompanyLicencesRequestViewModel viewModel);
    }
}
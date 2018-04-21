using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense.Request;

namespace TemtCash.Main.Domain.Repository
{
    public interface ICompanyLicenceRepository : ICrudRepository<CompanyLicence>
    {
        Task<PaginatedListResult<Company>> Search(CompanyLicencesRequestViewModel viewModel);
    }
}
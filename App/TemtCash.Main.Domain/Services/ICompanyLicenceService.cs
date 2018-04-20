using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense;

namespace TemtCash.Main.Domain.Services
{
    public interface ICompanyLicenceService
    {
        Task<ServiceResult<PaginatedListResult<CompanyLicensesResponseViewModel>>> Search(CompanyLicensesRequestViewModel viewModel);

        Task<ServiceResult<CompanyLicenseResponseViewModel>> GetSingle(int id);

        Task<ServiceResult<int>> Create(CompanyLicenseCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> Update(int id, CompanyLicenseCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> Delete(int id);
    }
}
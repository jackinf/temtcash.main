using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense;

namespace TemtCash.Main.Api.Services
{
    public class CompanyLicenceService : ICompanyLicenceService
    {
        public Task<ServiceResult<PaginatedListResult<CompanyLicensesResponseViewModel>>> Search(CompanyLicensesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<CompanyLicenseResponseViewModel>> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<int>> Create(CompanyLicenseCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<bool>> Update(int id, CompanyLicenseCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<bool>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
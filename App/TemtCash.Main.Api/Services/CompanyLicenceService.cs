using System.Collections.Generic;
using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense.Request;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicense.Response;

namespace TemtCash.Main.Api.Services
{
    public class CompanyLicenceService : ICompanyLicenceService
    {
        public async Task<ServiceResult<PaginatedListResult<CompanyLicencesResponseViewModel>>> Search(CompanyLicencesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<CompanyLicenceResponseViewModel>> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<int>> Create(CompanyLicenceCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<bool>> Update(int id, CompanyLicenceCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<bool>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<PaginatedListResult<DistributedLicencesResponseViewModel>>> DistributedLicences(CompanyLicencesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<bool>> UpdateLicences(List<int> licenceIds)
        {
            throw new System.NotImplementedException();
        }
    }
}
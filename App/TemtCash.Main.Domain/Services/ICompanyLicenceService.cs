using System.Collections.Generic;
using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicence.Request;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicence.Response;

namespace TemtCash.Main.Domain.Services
{
    public interface ICompanyLicenceService
    {
        Task<ServiceResult<PaginatedListResult<CompanyLicencesResponseViewModel>>> Search(CompanyLicencesRequestViewModel viewModel);

        Task<ServiceResult<CompanyLicenceResponseViewModel>> GetSingle(int id);

        Task<ServiceResult<int>> Create(CompanyLicenceCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> Update(int id, CompanyLicenceCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> Delete(int id);

        Task<ServiceResult<PaginatedListResult<DistributedLicencesResponseViewModel>>> DistributedLicences(CompanyLicencesRequestViewModel viewModel);

        Task<ServiceResult<bool>> UpdateLicences(List<int> licenceIds);
    }
}
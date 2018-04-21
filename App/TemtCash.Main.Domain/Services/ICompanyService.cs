using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Company;
using TemtCash.Main.Domain.ViewModel.Services.Company.Requests;
using TemtCash.Main.Domain.ViewModel.Services.Company.Response;

namespace TemtCash.Main.Domain.Services
{
    public interface ICompanyService
    {
        Task<ServiceResult<PaginatedListResult<CompaniesResponseViewModel>>> Search(CompaniesRequestViewModel viewModel);

        Task<ServiceResult<CompanyResponseViewModel>> GetSingle(int id);

        Task<ServiceResult<int>> Create(CompanyCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> Update(int id, CompanyCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> Delete(int id);
    }
}
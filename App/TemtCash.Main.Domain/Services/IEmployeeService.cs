using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Employee.Request;
using TemtCash.Main.Domain.ViewModel.Services.Employee.Response;

namespace TemtCash.Main.Domain.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResult<PaginatedListResult<EmployeesResponseViewModel>>> Search(EmployeesRequestViewModel viewModel);
        Task<ServiceResult<EmployeeResponseViewModel>> GetSingle(int id);
        Task<ServiceResult<int>> Create(EmployeeCreateOrUpdateRequestViewModel viewModel);
        Task<ServiceResult<bool>> Update(int id, EmployeeCreateOrUpdateRequestViewModel viewModel);
        Task<ServiceResult<bool>> Delete(int id);
    }
}
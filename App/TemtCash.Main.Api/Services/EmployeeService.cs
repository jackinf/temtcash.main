using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Employee.Request;
using TemtCash.Main.Domain.ViewModel.Services.Employee.Response;

namespace TemtCash.Main.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public Task<ServiceResult<PaginatedListResult<EmployeesResponseViewModel>>> Search(EmployeesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<EmployeeResponseViewModel>> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<int>> Create(EmployeeCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<bool>> Update(int id, EmployeeCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<bool>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
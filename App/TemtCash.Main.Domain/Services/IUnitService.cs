using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Unit.Request;
using TemtCash.Main.Domain.ViewModel.Services.Unit.Response;

namespace TemtCash.Main.Domain.Services
{
    public interface IUnitService
    {
        Task<ServiceResult<PaginatedListResult<UnitsResponseViewModel>>> Search(UnitssRequestViewModel viewModel);
        Task<ServiceResult<UnitResponseViewModel>> GetSingle(int id);
        Task<ServiceResult<int>> Create(UnitsCreateOrUpdateRequestViewModel viewModel);
        Task<ServiceResult<bool>> Update(int id, UnitsCreateOrUpdateRequestViewModel viewModel);
        Task<ServiceResult<bool>> Delete(int id);
    }
}
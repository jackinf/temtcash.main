using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.SystemUser;

namespace TemtCash.Main.Domain.Services
{
    public interface ISystemUserService
    {
        Task<ServiceResult<PaginatedListResult<SystemUsersResponseViewModel>>> Search(SystemUsersRequestViewModel viewModel);

    }
}
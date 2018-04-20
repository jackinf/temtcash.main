using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.SystemUser;

namespace TemtCash.Main.Api.Services
{
    public class SystemUserService : ISystemUserService
    {
        public Task<ServiceResult<PaginatedListResult<SystemUsersResponseViewModel>>> Search(SystemUsersRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
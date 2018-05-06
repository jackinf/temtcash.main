using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Client.Request;
using TemtCash.Main.Domain.ViewModel.Services.Client.Response;

namespace TemtCash.Main.Domain.Services
{
    public interface IClientService
    {
        Task<ServiceResult<PaginatedListResult<ClientsResponseViewModel>>> Search(ClientsRequestViewModel viewModel);
    }
}
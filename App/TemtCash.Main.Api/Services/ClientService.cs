using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Client.Request;
using TemtCash.Main.Domain.ViewModel.Services.Client.Response;

namespace TemtCash.Main.Api.Services
{
    public class ClientService : IClientService
    {
        public async Task<ServiceResult<PaginatedListResult<ClientsResponseViewModel>>> Search(ClientsRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage.Request;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage.Response;

namespace TemtCash.Main.Api.Services
{
    public class InfoChannelMessageService : IInfoChannelMessageService
    {
        public async Task<ServiceResult<PaginatedListResult<InfoChannelMessagesResponseViewModel>>> Search(InfoChannelMessagesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<InfoChannelMessageResponseViewModel>> GetSingle(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<int>> Create(InfoChannelMessageCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<bool>> Update(int id, InfoChannelMessageCreateOrUpdateRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<bool>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
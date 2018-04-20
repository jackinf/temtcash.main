using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage;

namespace TemtCash.Main.Domain.Services
{
    public interface IInfoChannelMessageService
    {
        Task<ServiceResult<PaginatedListResult<InfoChannelMessagesResponseViewModel>>> Search(InfoChannelMessagesRequestViewModel viewModel);

        Task<ServiceResult<InfoChannelMessageResponseViewModel>> GetSingle(int id);

        Task<ServiceResult<int>> Create(InfoChannelMessageCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> Update(int id, InfoChannelMessageCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> Delete(int id);
    }
}
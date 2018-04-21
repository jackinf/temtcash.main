using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage.Request;

namespace TemtCash.Main.Domain.Repository
{
    public interface IInfoChannelMessageRepository : ICrudRepository<InfoChannelMessage>
    {
        Task<PaginatedListResult<InfoChannelMessage>> Search(InfoChannelMessagesRequestViewModel viewModel);
    }
}
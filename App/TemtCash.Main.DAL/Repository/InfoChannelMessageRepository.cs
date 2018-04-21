using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage.Request;

namespace TemtCash.Main.DAL.Repository
{
    public class InfoChannelMessageRepository : CrudRepository<InfoChannelMessage>, IInfoChannelMessageRepository
    {
        public InfoChannelMessageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<PaginatedListResult<InfoChannelMessage>> Search(InfoChannelMessagesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
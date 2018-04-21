using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Dashboard.Response;

namespace TemtCash.Main.Domain.Services
{
    public interface IDashboardService
    {
        Task<ServiceResult<PaginatedListResult<InfoChannelMessagesDashboardResponseViewModel>>> InfoChannelMessages();

        Task<ServiceResult<InfoChannelMessageDashboardResponseViewModel>> InfoChannelMessage(int id);
    }
}
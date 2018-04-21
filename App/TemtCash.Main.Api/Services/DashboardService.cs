using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Dashboard;
using TemtCash.Main.Domain.ViewModel.Services.Dashboard.Response;

namespace TemtCash.Main.Api.Services
{
    public class DashboardService : IDashboardService
    {
        public DashboardService()
        {
        }

        public Task<ServiceResult<InfoChannelMessagesDashboardResponseViewModel>> InfoChannelMessages()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<InfoChannelMessageDashboardResponseViewModel>> InfoChannelMessage(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
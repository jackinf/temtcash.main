using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Factory;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Dashboard.Response;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage.Request;

namespace TemtCash.Main.Api.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IInfoChannelMessageRepository _infoChannelMessageRepository;

        public DashboardService(IInfoChannelMessageRepository infoChannelMessageRepository)
        {
            _infoChannelMessageRepository = infoChannelMessageRepository;

        }

        public async Task<ServiceResult<PaginatedListResult<InfoChannelMessagesDashboardResponseViewModel>>> InfoChannelMessages()
        {
            var paginatedListWithModel = await _infoChannelMessageRepository.Search(new InfoChannelMessagesRequestViewModel());

            List<InfoChannelMessagesDashboardResponseViewModel> Mapping(List<InfoChannelMessage> list)
            {
                return list?
                    .Select(model => new InfoChannelMessagesDashboardResponseViewModel
                    {
                        Id = model.Id,
                        Subject = model.Title,
                        Date = model.UpdatedOn ?? model.CreatedOn
                    })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
        }

        public async Task<ServiceResult<InfoChannelMessageDashboardResponseViewModel>> InfoChannelMessage(int id)
        {
            var item = await _infoChannelMessageRepository.GetSingleAsync(id);
            var viewModel = new InfoChannelMessageDashboardResponseViewModel
            {
                Id = item.Id,
                Subject = item.Title,
                Message = item.Message,
                Date = item.UpdatedOn ?? item.CreatedOn
            };
            return ServiceResultFactory.Success(viewModel);
        }
    }
}
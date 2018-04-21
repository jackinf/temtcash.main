using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Factory;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.Customer.Response;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage.Request;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage.Response;

namespace TemtCash.Main.Api.Services
{
    public class InfoChannelMessageService : IInfoChannelMessageService
    {
        private readonly IInfoChannelMessageRepository _repository;

        public InfoChannelMessageService(IInfoChannelMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<PaginatedListResult<InfoChannelMessagesResponseViewModel>>> Search(InfoChannelMessagesRequestViewModel viewModel)
        {
            var paginatedListWithModel = await _repository.Search(viewModel);

            // Mapping
            List<InfoChannelMessagesResponseViewModel> Mapping(List<InfoChannelMessage> list)
            {
                return list?
                    .Select(model => new InfoChannelMessagesResponseViewModel
                    {

                    })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
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
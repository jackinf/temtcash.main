using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Factory;
using SpeysCloud.Core.Result;
using TemtCash.Main.Api.Services.Validator;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.Services;
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
                        Id = model.Id,
                        Subject = model.Title,
                        Message = model.Message,
                        Date = model.VisibleUntil,
                        IsVisible = model.Visible
                    })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
        }

        public async Task<ServiceResult<InfoChannelMessageResponseViewModel>> GetSingle(int id)
        {
            var model = await _repository.GetSingleAsync(id);
            if (model == null)
                return ServiceResultFactory.Success<InfoChannelMessageResponseViewModel>(null);

            var viewModel = new InfoChannelMessageResponseViewModel
            {
                Id = model.Id,
                IsVisible = model.Visible,
                Subject = model.Title,
                Message = model.Message
            };

            return ServiceResultFactory.Success(viewModel);
        }

        public async Task<ServiceResult<int>> Create(InfoChannelMessageCreateOrUpdateRequestViewModel viewModel)
        {
            var model = new InfoChannelMessage();
            MapViewModelToModel(viewModel, model);
            model.Status = "1"; // TODO: What is status for?

            var validator = new InfoChannelMessageCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
                return ServiceResultFactory.Fail<int>(validationResult);

            await _repository.AddAsync(model);
            var changes = await _repository.SaveChangesAsync();
            if (changes == 0)
                return ServiceResultFactory.Fail<int>("Insert fails");
            return ServiceResultFactory.Success(model.Id);
        }

        public async Task<ServiceResult<bool>> Update(int id, InfoChannelMessageCreateOrUpdateRequestViewModel viewModel)
        {
            if (id <= 0)
                throw new ArgumentException("Argument should be greater than 0", nameof(viewModel));

            var model = await _repository.GetSingleAsync(id);
            if (model == null)
                return ServiceResultFactory.Fail<bool>("Item not found");
            MapViewModelToModel(viewModel, model);

            var validator = new InfoChannelMessageCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
                return ServiceResultFactory.Fail<bool>(validationResult);
            
            _repository.Update(model);
            var changes = await _repository.SaveChangesAsync();
            return ServiceResultFactory.Success(changes > 0);
        }

        public async Task<ServiceResult<bool>> Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Argument should be greater than 0", nameof(id));

            var model = await _repository.GetSingleAsync(id);
            if (model == null)
                return ServiceResultFactory.Fail<bool>("Item not found");

            _repository.Delete(model);
            var changes = await _repository.SaveChangesAsync();
            return ServiceResultFactory.Success(changes > 0);
        }

        private void MapViewModelToModel(InfoChannelMessageCreateOrUpdateRequestViewModel viewModel, InfoChannelMessage model)
        {
            model.Title = viewModel.Subject;
            model.Message = viewModel.Message;
            model.Visible = viewModel.IsVisible;
        }
    }
}
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
using TemtCash.Main.Domain.ViewModel.Services.Unit.Request;
using TemtCash.Main.Domain.ViewModel.Services.Unit.Response;

namespace TemtCash.Main.Api.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _repository;

        public UnitService(IUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<PaginatedListResult<UnitsResponseViewModel>>> Search(UnitssRequestViewModel viewModel)
        {
            var paginatedListWithModel = await _repository.Search(viewModel);

            // Mapping
            List<UnitsResponseViewModel> Mapping(List<ProductUnit> list)
            {
                return list?
                    .Select(model => new UnitsResponseViewModel
                    {
                        // TODO
                    })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
        }

        public async Task<ServiceResult<UnitResponseViewModel>> GetSingle(int id)
        {
            var model = await _repository.GetSingleAsync(id);
            if (model == null)
                return ServiceResultFactory.Success<UnitResponseViewModel>(null);

            var viewModel = new UnitResponseViewModel
            {
                // TODO
            };

            return ServiceResultFactory.Success(viewModel);
        }

        public async Task<ServiceResult<int>> Create(UnitsCreateOrUpdateRequestViewModel viewModel)
        {
            var model = new ProductUnit();
            MapViewModelToModel(viewModel, model);

            var validator = new ProductUnitCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
                return ServiceResultFactory.Fail<int>(validationResult);

            await _repository.AddAsync(model);
            var changes = await _repository.SaveChangesAsync();
            if (changes == 0)
                return ServiceResultFactory.Fail<int>("Insert fails");
            return ServiceResultFactory.Success(model.Id);
        }

        public async Task<ServiceResult<bool>> Update(int id, UnitsCreateOrUpdateRequestViewModel viewModel)
        {
            if (id <= 0)
                throw new ArgumentException("Argument should be greater than 0", nameof(viewModel));

            var model = await _repository.GetSingleAsync(id);
            if (model == null)
                return ServiceResultFactory.Fail<bool>("Item not found");
            MapViewModelToModel(viewModel, model);

            var validator = new ProductUnitCreateOrUpdateRequestViewModelValidator();
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

        private void MapViewModelToModel(UnitsCreateOrUpdateRequestViewModel viewModel, ProductUnit model)
        {
            throw new NotImplementedException();
        }
    }
}
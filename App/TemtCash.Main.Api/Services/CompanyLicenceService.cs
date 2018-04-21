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
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicence.Request;
using TemtCash.Main.Domain.ViewModel.Services.CompanyLicence.Response;

namespace TemtCash.Main.Api.Services
{
    public class CompanyLicenceService : ICompanyLicenceService
    {
        private readonly ICompanyLicenceRepository _repository;

        public CompanyLicenceService(ICompanyLicenceRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<PaginatedListResult<CompanyLicencesResponseViewModel>>> Search(CompanyLicencesRequestViewModel viewModel)
        {
            var paginatedListWithModel = await _repository.Search(viewModel);

            List<CompanyLicencesResponseViewModel> Mapping(List<CompanyLicence> list)
            {
                return list?
                    .Select(model => new CompanyLicencesResponseViewModel
                    {
                        Id = model.Id,
                        ExpiresOn = model.ValidToDate,
                        LicenceKey = model.LicenceKey,
                        LincenceUpdatingDateTime = model.ValidToDate,
                        Version = model.Version
                    })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
        }

        public async Task<ServiceResult<CompanyLicenceResponseViewModel>> GetSingle(int id)
        {
            var model = await _repository.GetSingleAsync(id);
            if (model == null)
            {
                return ServiceResultFactory.Success<CompanyLicenceResponseViewModel>(null);
            }

            var viewModel = new CompanyLicenceResponseViewModel
            {
                Id = model.Id,
                LicenceKey = model.LicenceKey
            };

            return ServiceResultFactory.Success(viewModel);
        }

        public async Task<ServiceResult<int>> Create(CompanyLicenceCreateOrUpdateRequestViewModel viewModel)
        {
            var validator = new CompanyLicenceCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(viewModel);
            if (!validationResult.IsValid)
                return ServiceResultFactory.Fail<int>(validationResult);

            var model = new CompanyLicence();
            MapViewModelToModel(viewModel, model);
            await _repository.AddAsync(model);
            var changes = await _repository.SaveChangesAsync();
            if (changes == 0)
                return ServiceResultFactory.Fail<int>("Insert fails");
            return ServiceResultFactory.Success(model.Id);
        }

        public async Task<ServiceResult<bool>> Update(int id, CompanyLicenceCreateOrUpdateRequestViewModel viewModel)
        {
            if (id <= 0)
                throw new ArgumentException("Argument should be greater than 0", nameof(viewModel));

            var validator = new CompanyLicenceCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(viewModel);
            if (!validationResult.IsValid)
                return ServiceResultFactory.Fail<bool>(validationResult);

            var model = await _repository.GetSingleAsync(id);
            MapViewModelToModel(viewModel, model);
            _repository.Update(model);
            var changes = await _repository.SaveChangesAsync();
            return ServiceResultFactory.Success(changes > 0);
        }

        public async Task<ServiceResult<bool>> Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Argument should be greater than 0", nameof(id));

            var model = await _repository.GetSingleAsync(id);
            _repository.Delete(model);
            var changes = await _repository.SaveChangesAsync();
            return ServiceResultFactory.Success(changes > 0);
        }

        public async Task<ServiceResult<PaginatedListResult<DistributedLicencesResponseViewModel>>> DistributedLicences(CompanyLicencesRequestViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<bool>> UpdateLicences(List<int> licenceIds)
        {
            throw new System.NotImplementedException();
        }

        private void MapViewModelToModel(CompanyLicenceCreateOrUpdateRequestViewModel viewModel, CompanyLicence model)
        {
            model.LicenceKey = viewModel.LicenceKey;
        }
    }
}
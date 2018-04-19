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
using TemtCash.Main.Domain.ViewModel.Services.Company;

namespace TemtCash.Main.Api.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<PaginatedListResult<CompaniesResponseViewModel>>> Search(CompaniesRequestViewModel viewModel)
        {
            var paginatedListWithModel = await _repository.Search(viewModel);

            // Mapping
            List<CompaniesResponseViewModel> Mapping(List<Company> list)
            {
                return list?
                    .Select(address => new CompaniesResponseViewModel
                    {
                        //Id = address.Id,
                        //Country = address.Country,
                        //City = address.City,
                        //Company = address.Company,
                        //Contact = address.ContactName,
                        //CreationDate = address.CreatedOn,
                        //Street = address.AddressLine1
                    })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
        }

        public async Task<ServiceResult<CompanyResponseViewModel>> GetSingle(int id)
        {
            var model = await _repository.GetSingleAsync(id);
            if (model == null)
            {
                return ServiceResultFactory.Success<CompanyResponseViewModel>(null);
            }

            var viewModel = new CompanyResponseViewModel
            {
                //Country = model.Country,
                //PostalCode = model.PostalCode,
                //City = model.City,
                //AddressLine1 = model.AddressLine1,
                //AddressLine2 = model.AddressLine2,
                //AddressLine3 = model.AddressLine3,
                //Company = model.Company,
                //ContactName = model.ContactName,
                //ContactPhoneNumber = model.ContactPhoneNumber,
                //ContactEmail = model.ContactEmail,
                //KmkRegistrationNumber = model.KmkRegistrationNumber,
                //TntClientNumber = model.TntClientNumber,
                //ContactReference = model.ContactReference,
            };

            return ServiceResultFactory.Success(viewModel);
        }

        public async Task<ServiceResult<int>> Create(CompanyCreateOrUpdateRequestViewModel viewModel)
        {
            var validator = new CompanyCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(viewModel);
            if (!validationResult.IsValid)
            {
                return ServiceResultFactory.Fail<int>(validationResult);
            }

            var model = new Company();
            MapViewModelToModel(viewModel, model);
            await _repository.AddAsync(model);
            var changes = await _repository.SaveChangesAsync();
            if (changes == 0)
                return ServiceResultFactory.Fail<int>("Insert fails");
            return ServiceResultFactory.Success(model.Id);
        }

        public async Task<ServiceResult<bool>> Update(int id, CompanyCreateOrUpdateRequestViewModel viewModel)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Argument should be greater than 0", nameof(viewModel));
            }

            var validator = new CompanyCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(viewModel);
            if (!validationResult.IsValid)
            {
                return ServiceResultFactory.Fail<bool>(validationResult);
            }

            var model = await _repository.GetSingleAsync(id);
            MapViewModelToModel(viewModel, model);
            _repository.Update(model);
            var changes = await _repository.SaveChangesAsync();
            return ServiceResultFactory.Success(changes > 0);
        }

        public async Task<ServiceResult<bool>> Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Argument should be greater than 0", nameof(id));
            }

            var model = await _repository.GetSingleAsync(id);
            _repository.Delete(model);
            var changes = await _repository.SaveChangesAsync();
            return ServiceResultFactory.Success(changes > 0);
        }

        private static void MapViewModelToModel(CompanyCreateOrUpdateRequestViewModel viewModel, Company address)
        {
            // TODO: implement
        }

    }
}
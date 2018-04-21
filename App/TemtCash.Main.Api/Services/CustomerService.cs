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
using TemtCash.Main.Domain.ViewModel.Services.Customer.Request;
using TemtCash.Main.Domain.ViewModel.Services.Customer.Response;

namespace TemtCash.Main.Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<PaginatedListResult<CustomersResponseViewModel>>> Search(CustomersRequestViewModel viewModel)
        {
            var paginatedListWithModel = await _repository.Search(viewModel);

            // Mapping
            List<CustomersResponseViewModel> Mapping(List<Customer> list)
            {
                return list?
                    .Select(model => new CustomersResponseViewModel
                    {
                        Id = model.Id,
                        UsernameOrEmail = model.Email,
                        FirstName = model.Name, // TODO
                        //LastName = model. TODO
                        //Role = model.Role TODO
                        CompanysMainUser = model.IsCompany, // TODO? is this correct?
                        //IsActive = model.IsActive // TODO
                        //LastLoginTime = model.LastLoginTime // TODO
                    })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
        }

        public async Task<ServiceResult<CustomerResponseViewModel>> GetSingle(int id)
        {
            var model = await _repository.GetSingleAsync(id);
            if (model == null)
            {
                return ServiceResultFactory.Success<CustomerResponseViewModel>(null);
            }

            var viewModel = new CustomerResponseViewModel
            {
                Id = model.Id,
                UsernameOrEmail = model.Email,
                FirstName = model.Name,
                //LastName = model.LastName, // TODO
                CompanysMainUser = model.IsCompany,
                //IsSeller = model.IsSeller, // TODO 
                //IsActive = model.IsActive, // TODO
            };

            return ServiceResultFactory.Success(viewModel);
        }

        public async Task<ServiceResult<int>> Create(CustomerCreateOrUpdateRequestViewModel viewModel)
        {
            var validator = new CustomerCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(viewModel);
            if (!validationResult.IsValid)
                return ServiceResultFactory.Fail<int>(validationResult);

            var model = new Customer();
            MapViewModelToModel(viewModel, model);
            await _repository.AddAsync(model);
            var changes = await _repository.SaveChangesAsync();
            if (changes == 0)
                return ServiceResultFactory.Fail<int>("Insert fails");
            return ServiceResultFactory.Success(model.Id);
        }

        public async Task<ServiceResult<bool>> Update(int id, CustomerCreateOrUpdateRequestViewModel viewModel)
        {
            if (id <= 0)
                throw new ArgumentException("Argument should be greater than 0", nameof(viewModel));

            var validator = new CustomerCreateOrUpdateRequestViewModelValidator();
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

        private void MapViewModelToModel(CustomerCreateOrUpdateRequestViewModel viewModel, Customer model)
        {
            model.Email = viewModel.UsernameOrEmail;
            //model.Name = viewModel.FirstName; // TODO
            //model.LastName = viewModel.LastName; // TODO
            model.IsCompany = viewModel.CompanysMainUser;
            //model.IsSeller = viewModel.IsSeller; // TODO
            //model.IsActive = viewModel.IsActive; // TODO
        }
    }
}
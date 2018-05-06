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
using TemtCash.Main.Domain.ViewModel.Services.Supplier.Request;
using TemtCash.Main.Domain.ViewModel.Services.Supplier.Response;

namespace TemtCash.Main.Api.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<PaginatedListResult<SuppliersResponseViewModel>>> Search(SuppliersRequestViewModel viewModel)
        {
            var paginatedListWithModel = await _repository.Search(viewModel);

            // Mapping
            List<SuppliersResponseViewModel> Mapping(List<Supplier> list)
            {
                return list?
                    .Select(model => new SuppliersResponseViewModel
                    {
                        Id = model.Id,
                        CompanyName = model.Company?.Name,
                        //ClientCode = model. // TODO
                        //ContactPerson = model. //TODO
                        //ContactPhone = model. //TODO
                        //ContactEmail = model. //TODO
                        //InvoiceFrequency = model.InvoiceFrequency // TODO
                        //InvoiceEmail = model.InvoiceEmail // TODO
                        //LastLoginTime = model.LastLoginTime // TODO
                        //IsActive = model.IsActive // TODO
                    })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
        }

        public async Task<ServiceResult<SupplierResponseViewModel>> GetSingle(int id)
        {
            var model = await _repository.GetSingleAsync(id);
            if (model == null)
            {
                return ServiceResultFactory.Success<SupplierResponseViewModel>(null);
            }

            var viewModel = new SupplierResponseViewModel
            {
                CompanyId = model.CompanyId,
                Name = model.Name,
                RegistrationNumber = model.CompanyRegNumber,
                Phone = model.Phone,
                Email = model.Email,
                Iban = model.BankIban,
                BicSwift = model.BankSwift,
                PaymentPeriodInDays = model.DeadlineDays,
                Comment = model.Comment
            };

            return ServiceResultFactory.Success(viewModel);
        }

        public async Task<ServiceResult<int>> Create(SupplierCreateOrUpdateRequestViewModel viewModel)
        {
            var model = new Supplier();
            MapViewModelToModel(viewModel, model);

            var validator = new SupplierCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return ServiceResultFactory.Fail<int>(validationResult);
            }

            await _repository.AddAsync(model);
            var changes = await _repository.SaveChangesAsync();
            if (changes == 0)
                return ServiceResultFactory.Fail<int>("Insert fails");
            return ServiceResultFactory.Success(model.Id);
        }

        public async Task<ServiceResult<bool>> Update(int id, SupplierCreateOrUpdateRequestViewModel viewModel)
        {
            if (id <= 0)
                throw new ArgumentException("Argument should be greater than 0", nameof(id));

            var model = await _repository.GetSingleAsync(id);
            MapViewModelToModel(viewModel, model);

            var validator = new SupplierCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return ServiceResultFactory.Fail<bool>(validationResult);
            }

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

        private void MapViewModelToModel(SupplierCreateOrUpdateRequestViewModel viewModel, Supplier model)
        {
            model.CompanyId = viewModel.CompanyId;
            model.Name = viewModel.Name;
            //model.Kmkr = viewModel.Kmkr; // TODO
            model.CompanyRegNumber = viewModel.RegistrationNumber;
            model.Phone = viewModel.Phone;
            model.Email = viewModel.Email;
            //model.AaInBank = viewModel.AaInBank; // TODO
            model.BankIban = viewModel.Iban;
            model.BankSwift = viewModel.BicSwift;
            model.DeadlineDays = viewModel.PaymentPeriodInDays;
            model.Comment = viewModel.Comment;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Factory;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.DAL.Model;
using SpeysCloud.Main.Domain.Repository;
using SpeysCloud.Main.Domain.Services;
using SpeysCloud.Main.Domain.ViewModel.Services.AddressBook;
using SpeysCloud.Main.Services.Validator;

namespace SpeysCloud.Main.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<PaginatedListResult<AddressesResponseViewModel>>> GetAddresses(AddressesRequestViewModel viewModel)
        {
            var paginatedListWithModel = await _repository.Search(viewModel);

            // Mapping
            List<AddressesResponseViewModel> Mapping(List<Address> list)
            {
                return list?
                    .Select(address => new AddressesResponseViewModel
                    {
                        Id = address.Id,
                        Country = address.Country,
                        City = address.City,
                        Company = address.Company,
                        Contact = address.ContactName,
                        CreationDate = address.CreatedOn,
                        Street = address.AddressLine1
                    })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
        }

        public async Task<ServiceResult<AddressResponseViewModel>> GetAddress(int addressId)
        {
            var model = await _repository.GetSingleAsync(addressId);
            if (model == null)
            {
                return ServiceResultFactory.Success<AddressResponseViewModel>(null);
            }

            var viewModel = new AddressResponseViewModel
            {
                Country = model.Country,
                PostalCode = model.PostalCode,
                City = model.City,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                AddressLine3 = model.AddressLine3,
                Company = model.Company,
                ContactName = model.ContactName,
                ContactPhoneNumber = model.ContactPhoneNumber,
                ContactEmail = model.ContactEmail,
                KmkRegistrationNumber = model.KmkRegistrationNumber,
                TntClientNumber = model.TntClientNumber,
                ContactReference = model.ContactReference,
            };

            return ServiceResultFactory.Success(viewModel);
        }

        public async Task<ServiceResult<ShipmentContactViewModel>> GetSingleShipmentContact(int addressId)
        {
            var address = await _repository.GetSingleAsync(addressId);

            var viewModel = new ShipmentContactViewModel
            {
                Id = address.Id,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                AddressLine3 = address.AddressLine3,
                City = address.City,
                CompanyName = address.Company,
                ContactPersonName = address.ContactName,
                Phone = address.ContactPhoneNumber,
                Email = address.ContactEmail,
                Country = address.Country,
                PostCode = address.PostalCode,
                //Vat = user.Vat
            };

            return ServiceResultFactory.Success(viewModel);
        }

        public async Task<ServiceResult<int>> CreateAddress(AddressCreateOrUpdateRequestViewModel viewModel)
        {
            var validator = new AddressCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(viewModel);
            if (!validationResult.IsValid)
            {
                return ServiceResultFactory.Fail<int>(validationResult);
            }

            var address = new Address();
            MapAddress(viewModel, address);
            await _repository.AddAsync(address);
            var changes = await _repository.SaveChangesAsync();
            if (changes == 0)
                return ServiceResultFactory.Fail<int>("Insert fails");
            return ServiceResultFactory.Success(address.Id);
        }

        public async Task<ServiceResult<bool>> UpdateAddress(int addressId, AddressCreateOrUpdateRequestViewModel viewModel)
        {
            if (addressId <= 0)
            {
                throw new ArgumentException("Argument should be greater than 0", nameof(viewModel));
            }

            var validator = new AddressCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(viewModel);
            if (!validationResult.IsValid)
            {
                return ServiceResultFactory.Fail<bool>(validationResult);
            }

            var address = await _repository.GetSingleAsync(addressId);
            MapAddress(viewModel, address);
            _repository.Update(address);
            var changes = await _repository.SaveChangesAsync();
            return ServiceResultFactory.Success(changes > 0);
        }

        public async Task<ServiceResult<bool>> DeleteAddress(int addressId)
        {
            if (addressId <= 0)
            {
                throw new ArgumentException("Argument should be greater than 0", nameof(addressId));
            }

            var address = await _repository.GetSingleAsync(addressId);
            _repository.Delete(address);
            var changes = await _repository.SaveChangesAsync();
            return ServiceResultFactory.Success(changes > 0);
        }

        private static void MapAddress(AddressCreateOrUpdateRequestViewModel viewModel, Address address)
        {
            address.Country = viewModel.Country;
            address.PostalCode = viewModel.PostalCode;
            address.City = viewModel.City;
            address.AddressLine1 = viewModel.AddressLine1;
            address.AddressLine2 = viewModel.AddressLine2;
            address.AddressLine3 = viewModel.AddressLine3;
            address.Company = viewModel.Company;
            address.ContactName = viewModel.ContactName;
            address.ContactPhoneNumber = viewModel.ContactPhoneNumber;
            address.ContactEmail = viewModel.ContactEmail;
            address.KmkRegistrationNumber = viewModel.KmkRegistrationNumber;
            address.TntClientNumber = viewModel.TntClientNumber;
            address.ContactReference = viewModel.ContactReference;
        }

    }
}
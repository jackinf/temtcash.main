using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.DAL.Model;
using SpeysCloud.Main.DAL.UnitOfWork;
using SpeysCloud.Core.Factory;
using SpeysCloud.Main.Domain.Model;
using SpeysCloud.Main.Domain.Repository;
using SpeysCloud.Main.Domain.Services;
using SpeysCloud.Main.Domain.ViewModel.Services.Shipment;
using SpeysCloud.Main.Services.Validator;

namespace SpeysCloud.Main.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _repository;
        private readonly AddressAndShipmentUnitOfWork _unitOfWork;

        public ShipmentService(IShipmentRepository repository, AddressAndShipmentUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult<PaginatedListResult<ShipmentsResponseViewModel>>> Search(ShipmentsRequestViewModel viewModel)
        {
            var paginatedListWithModel = await _repository.Search(viewModel);
            
            // Mapping
            List<ShipmentsResponseViewModel> Mapping(List<Shipment> list)
            {
                return list?
                        .Select(x => new ShipmentsResponseViewModel
                        {
                            Id = x.Id,
                            Number = x.Number,
                            Status = x.StatusString,
                            DeliveryDate = x.EarliestArrivalDate,
                            Company = x.TransportCompany,
                            CreatedOn = x.CreatedOn,
                            TotalEur = x.TotalEur
                        })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
        }

        public async Task<ServiceResult<ShipmentResponseViewModel>> GetSingle(int deliveryId)
        {
            var model = await _repository.GetSingle(deliveryId);
            if (model == null)
            {
                return ServiceResultFactory.Success<ShipmentResponseViewModel>(null);
            }

            var viewModel = new ShipmentResponseViewModel
            {
                Reference = model.Reference,
                TransportCompany = model.TransportCompany,
                Status = model.Status,
                Number = model.Number,
                TotalEur = model.TotalEur,

                OtherInstructions = model.OtherInstructions,

                EarliestPickupDate = model.EarliestPickupDate,
                EarliestArrivalDate = model.EarliestArrivalDate,
                LatestPickupDate = model.LatestPickupDate,
                LatestArrivalDate = model.LatestArrivalDate,

                ShipmentDetailsRows = model.ShipmentDetails.Select(x => new ShipmentResponseViewModel.ShipmentDetailsRow
                {
                    DangerousGoods = x.DangerousGoods,
                    Height = x.Height,
                    Length = x.Length,
                    ProductAdditionalInfo = x.ProductAdditionalInfo,
                    ProductDescription = x.ProductDescription,
                    QuantityId = x.QuantityId,
                    TypeId = x.TypeId,
                    Weight = x.Weight,
                    Width = x.Width
                }).ToList(),

                Sender = new ShipmentResponseViewModel.ShipmentContact
                {
                    Id = model.SenderId,
                    Country = model.SenderCountry,
                    PostCode = model.SenderPostCode,
                    City = model.SenderCity,
                    AddressLine1 = model.SenderAddressLine1,
                    AddressLine2 = model.SenderAddressLine2,
                    AddressLine3 = model.SenderAddressLine3,
                    CompanyName = model.SenderCompanyName,
                    ContactPersonName = model.SenderContactPersonName,
                    Phone = model.SenderPhone,
                    Email = model.SenderEmail,
                    Vat = model.SenderVat
                },

                SenderAlternative = new ShipmentResponseViewModel.ShipmentContact
                {
                    Id = model.SenderAlternativeId,
                    Country = model.SenderAlternativeCountry,
                    PostCode = model.SenderAlternativePostCode,
                    City = model.SenderAlternativeCity,
                    AddressLine1 = model.SenderAlternativeAddressLine1,
                    AddressLine2 = model.SenderAlternativeAddressLine2,
                    AddressLine3 = model.SenderAlternativeAddressLine3,
                    CompanyName = model.SenderAlternativeCompanyName,
                    ContactPersonName = model.SenderAlternativeContactPersonName,
                    Phone = model.SenderAlternativePhone,
                    Email = model.SenderAlternativeEmail,
                    Vat = model.SenderAlternativeVat
                },
                UseSenderAlternative = model.UseSenderAlternative,

                Receiver = new ShipmentResponseViewModel.ShipmentContact
                {
                    Id = model.ReceiverId,
                    Country = model.ReceiverCountry,
                    PostCode = model.ReceiverPostCode,
                    City = model.ReceiverCity,
                    AddressLine1 = model.ReceiverAddressLine1,
                    AddressLine2 = model.ReceiverAddressLine2,
                    AddressLine3 = model.ReceiverAddressLine3,
                    CompanyName = model.ReceiverCompanyName,
                    ContactPersonName = model.ReceiverContactPersonName,
                    Phone = model.ReceiverPhone,
                    Email = model.ReceiverEmail,
                    Vat = model.ReceiverVat
                },

                ReceiverAlternative = new ShipmentResponseViewModel.ShipmentContact
                {
                    Id = model.ReceiverAlternativeId,
                    Country = model.ReceiverAlternativeCountry,
                    PostCode = model.ReceiverAlternativePostCode,
                    City = model.ReceiverAlternativeCity,
                    AddressLine1 = model.ReceiverAlternativeAddressLine1,
                    AddressLine2 = model.ReceiverAlternativeAddressLine2,
                    AddressLine3 = model.ReceiverAlternativeAddressLine3,
                    CompanyName = model.ReceiverAlternativeCompanyName,
                    ContactPersonName = model.ReceiverAlternativeContactPersonName,
                    Phone = model.ReceiverAlternativePhone,
                    Email = model.ReceiverAlternativeEmail,
                    Vat = model.ReceiverAlternativeVat
                },
                UseReceiverAlternative = model.UseReceiverAlternative
            };

            return ServiceResultFactory.Success(viewModel);
        }

        public async Task<ServiceResult<int>> Create(ShipmentCreateOrUpdateRequestViewModel viewModel)
        {
            return await _unitOfWork.TryExecuteTransactionThenSaveAndCommitOrRollback(async transaction =>
            {
                // TODO: validate if addresses exist for senders and receivers
                var validator = new ShipmentCreateOrUpdateRequestViewModelValidator();
                var validationResult = await validator.ValidateAsync(viewModel);
                if (!validationResult.IsValid)
                {
                    return ServiceResultFactory.Fail<int>(validationResult);
                }

                var shipment = new Shipment();

                await MapAndUpsertAddresses(viewModel, shipment, _unitOfWork.AddressRepository);

                MapShipmentDetails(viewModel, shipment);

                await _repository.Add(shipment);
                var changes = await _repository.SaveChangesAsync();
                if (changes == 0)
                    return ServiceResultFactory.Fail<int>("Insert fails");
                return ServiceResultFactory.Success(shipment.Id);
            });
        }

        public async Task<ServiceResult<bool>> Update(int shipmentId, ShipmentCreateOrUpdateRequestViewModel viewModel)
        {
            return await _unitOfWork.TryExecuteTransactionThenSaveAndCommitOrRollback(async transaction =>
            {
                // TODO: validate if addresses exist for senders and receivers
                var validator = new ShipmentCreateOrUpdateRequestViewModelValidator();
                var validationResult = await validator.ValidateAsync(viewModel);
                if (!validationResult.IsValid)
                {
                    return ServiceResultFactory.Fail<bool>(validationResult);
                }

                if (shipmentId <= 0)
                {
                    throw new ArgumentException(nameof(shipmentId), "Argument should be greater than 0");
                }

                var shipment = await _repository.GetSingle(shipmentId);

                await MapAndUpsertAddresses(viewModel, shipment, _unitOfWork.AddressRepository);

                if (shipment.ShipmentDetails.Any())
                    _repository.RemoveRange(shipment.ShipmentDetails);
                MapShipmentDetails(viewModel, shipment);
                _repository.Update(shipment);
                var changes = await _repository.SaveChangesAsync();
                return ServiceResultFactory.Success(changes > 0);
            });
        }

        public async Task<ServiceResult<bool>> Delete(int shipmentId)
        {
            if (shipmentId <= 0)
            {
                throw new ArgumentException("Argument should be greater than 0", nameof(shipmentId));
            }

            var shipment = await _repository.GetSingle(shipmentId);
            _repository.Delete(shipment);
            var changes = await _repository.SaveChangesAsync();
            return ServiceResultFactory.Success(changes > 0);
        }

        //
        // Helpers 
        //

        private async Task MapAndUpsertAddresses(ShipmentCreateOrUpdateRequestViewModel viewModel, Shipment shipment, IAddressRepository addressRepository)
        {
            await UpsertAddress(viewModel.Sender, addressRepository);
            await UpsertAddress(viewModel.SenderAlternative, addressRepository);
            await UpsertAddress(viewModel.Receiver, addressRepository);
            await UpsertAddress(viewModel.ReceiverAlternative, addressRepository);

            MapMainInfo(viewModel, shipment);
            MapSender(viewModel, shipment);
            MapSenderAlternative(viewModel, shipment);
            MapReceiver(viewModel, shipment);
            MapReceiverAlternative(viewModel, shipment);
        }

        private static void MapMainInfo(ShipmentCreateOrUpdateRequestViewModel viewModel, Shipment shipment)
        {
            shipment.Number = viewModel.Number;
            shipment.Reference = viewModel.Reference;
            shipment.TransportCompany = viewModel.TransportCompany;
            shipment.Status = viewModel.Status;
            shipment.TotalEur = viewModel.TotalEur;

            shipment.EarliestPickupDate = viewModel.EarliestPickupDate;
            shipment.EarliestArrivalDate = viewModel.EarliestArrivalDate;
            shipment.LatestPickupDate = viewModel.LatestPickupDate;
            shipment.LatestArrivalDate = viewModel.LatestArrivalDate;

            shipment.OtherInstructions = viewModel.OtherInstructions;
        }

        private static void MapShipmentDetails(ShipmentCreateOrUpdateRequestViewModel viewModel, Shipment shipment)
        {
            shipment.ShipmentDetails = viewModel.ShipmentDetailsRows.Select(x => new ShipmentDetail
            {
                DangerousGoods = x.DangerousGoods,
                Height = x.Height,
                Length = x.Length,
                ProductAdditionalInfo = x.ProductAdditionalInfo,
                ProductDescription = x.ProductDescription,
                QuantityId = x.QuantityId,
                TypeId = x.TypeId,
                Weight = x.Weight,
                Width = x.Width
            }).ToList();
        }

        private static void MapSender(ShipmentCreateOrUpdateRequestViewModel viewModel, Shipment shipment)
        {
            if (viewModel.Sender != null)
            {
                shipment.SenderId = viewModel.Sender.Id;
                shipment.SenderCountry = viewModel.Sender.Country;
                shipment.SenderPostCode = viewModel.Sender.PostCode;
                shipment.SenderCity = viewModel.Sender.City;
                shipment.SenderAddressLine1 = viewModel.Sender.AddressLine1;
                shipment.SenderAddressLine2 = viewModel.Sender.AddressLine2;
                shipment.SenderAddressLine3 = viewModel.Sender.AddressLine3;
                shipment.SenderCompanyName = viewModel.Sender.CompanyName;
                shipment.SenderContactPersonName = viewModel.Sender.ContactPersonName;
                shipment.SenderPhone = viewModel.Sender.Phone;
                shipment.SenderEmail = viewModel.Sender.Email;
                shipment.SenderVat = viewModel.Sender.Vat;
            }
        }

        private static void MapSenderAlternative(ShipmentCreateOrUpdateRequestViewModel viewModel, Shipment shipment)
        {
            shipment.UseSenderAlternative = viewModel.UseSenderAlternative;
            if (viewModel.SenderAlternative != null)
            {
                shipment.SenderAlternativeId = viewModel.SenderAlternative.Id;
                shipment.SenderAlternativeCountry = viewModel.SenderAlternative.Country;
                shipment.SenderAlternativePostCode = viewModel.SenderAlternative.PostCode;
                shipment.SenderAlternativeCity = viewModel.SenderAlternative.City;
                shipment.SenderAlternativeAddressLine1 = viewModel.SenderAlternative.AddressLine1;
                shipment.SenderAlternativeAddressLine2 = viewModel.SenderAlternative.AddressLine2;
                shipment.SenderAlternativeAddressLine3 = viewModel.SenderAlternative.AddressLine3;
                shipment.SenderAlternativeCompanyName = viewModel.SenderAlternative.CompanyName;
                shipment.SenderAlternativeContactPersonName = viewModel.SenderAlternative.ContactPersonName;
                shipment.SenderAlternativePhone = viewModel.SenderAlternative.Phone;
                shipment.SenderAlternativeEmail = viewModel.SenderAlternative.Email;
                shipment.SenderAlternativeVat = viewModel.SenderAlternative.Vat;
            }
        }

        private static void MapReceiver(ShipmentCreateOrUpdateRequestViewModel viewModel, Shipment shipment)
        {
            if (viewModel.Receiver != null)
            {
                shipment.ReceiverId = viewModel.Receiver.Id;
                shipment.ReceiverCountry = viewModel.Receiver.Country;
                shipment.ReceiverPostCode = viewModel.Receiver.PostCode;
                shipment.ReceiverCity = viewModel.Receiver.City;
                shipment.ReceiverAddressLine1 = viewModel.Receiver.AddressLine1;
                shipment.ReceiverAddressLine2 = viewModel.Receiver.AddressLine2;
                shipment.ReceiverAddressLine3 = viewModel.Receiver.AddressLine3;
                shipment.ReceiverCompanyName = viewModel.Receiver.CompanyName;
                shipment.ReceiverContactPersonName = viewModel.Receiver.ContactPersonName;
                shipment.ReceiverPhone = viewModel.Receiver.Phone;
                shipment.ReceiverEmail = viewModel.Receiver.Email;
                shipment.ReceiverVat = viewModel.Receiver.Vat;
            }
        }

        private static void MapReceiverAlternative(ShipmentCreateOrUpdateRequestViewModel viewModel, Shipment shipment)
        {
            shipment.UseReceiverAlternative = viewModel.UseReceiverAlternative;
            if (viewModel.ReceiverAlternative != null)
            {
                shipment.ReceiverAlternativeId = viewModel.ReceiverAlternative.Id;
                shipment.ReceiverAlternativeCountry = viewModel.ReceiverAlternative.Country;
                shipment.ReceiverAlternativePostCode = viewModel.ReceiverAlternative.PostCode;
                shipment.ReceiverAlternativeCity = viewModel.ReceiverAlternative.City;
                shipment.ReceiverAlternativeAddressLine1 = viewModel.ReceiverAlternative.AddressLine1;
                shipment.ReceiverAlternativeAddressLine2 = viewModel.ReceiverAlternative.AddressLine2;
                shipment.ReceiverAlternativeAddressLine3 = viewModel.ReceiverAlternative.AddressLine3;
                shipment.ReceiverAlternativeCompanyName = viewModel.ReceiverAlternative.CompanyName;
                shipment.ReceiverAlternativeContactPersonName = viewModel.ReceiverAlternative.ContactPersonName;
                shipment.ReceiverAlternativePhone = viewModel.ReceiverAlternative.Phone;
                shipment.ReceiverAlternativeEmail = viewModel.ReceiverAlternative.Email;
                shipment.ReceiverAlternativeVat = viewModel.ReceiverAlternative.Vat;
            }
        }

        /// <summary>
        /// Inserts new address, if does not exist, or updates an existing one.
        /// If id is incorrect then record is still created and id is changed to existing one in view model.
        /// </summary>
        /// <param name="viewModel">Information taken from to insert/update</param>
        /// <param name="addressRepository">DAL</param>
        /// <returns></returns>
        private async Task UpsertAddress(ShipmentResponseViewModel.ShipmentContact viewModel, IAddressRepository addressRepository)
        {
            if (viewModel == null)
            {
                return;
            }

            if (!viewModel.UpdateContact)
            {
                viewModel.Id = null;
                return;
            }

            Address address = null;
            if (viewModel.Id != null)
                address = await addressRepository.GetSingleAsync(viewModel.Id.Value); // account that incorrect id can be specified. Then we create record implicitly
            var isNew = address == null;
            address = address ?? new Address();

            address.Country = viewModel.Country;
            address.PostalCode = viewModel.PostCode;
            address.City = viewModel.City;
            address.AddressLine1 = viewModel.AddressLine1;
            address.AddressLine2 = viewModel.AddressLine2;
            address.AddressLine3 = viewModel.AddressLine3;
            address.Company = viewModel.CompanyName;
            address.ContactName = viewModel.ContactPersonName;
            address.ContactPhoneNumber = viewModel.Phone;
            address.ContactEmail = viewModel.Email;
            //address.Vat = viewModel.Vat; // TODO: does vat exist in address?

            if (isNew)
            {
                await addressRepository.AddAsync(address);
            }
            else
            {
                addressRepository.Update(address);
            }

            await addressRepository.SaveChangesAsync();
            viewModel.Id = address.Id;
        }
    }
}
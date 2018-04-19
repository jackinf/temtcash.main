using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.DAL.Model;
using SpeysCloud.Main.Domain.ViewModel.Services.Shipment;
using SpeysCloud.Main.IntegrationTests.Utils;
using Xunit;
using Validator = SpeysCloud.Main.Services.Validator.ShipmentCreateOrUpdateRequestViewModelValidator;

namespace SpeysCloud.Main.IntegrationTests.Features.Shipment
{
    public class when_shipment_is_updated : clear_data
    {
        private const string Endpoint = "/api/shipment";
        private int _deliveryId;
        DAL.Model.Address _existingAddress = null;

        public when_shipment_is_updated()
        {
            ApiServerFixture.Current.DoDatabaseOperation(context => context.ShipmentDetails.RemoveRange(context.ShipmentDetails));

            var fixture = new Fixture();

            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var address = fixture.Build<DAL.Model.Address>()
                    .WithoutBaseProperties()
                    .Create();
                context.Addresses.Add(address);
                context.SaveChanges();
                _existingAddress = address;
            });

            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var createdShipmentDetailsRow = fixture
                    .Build<ShipmentDetail>()
                    .WithoutBaseProperties()
                    .Without(x => x.Shipment)
                    .Without(x => x.ShipmentId)
                    .Create();
                var createdShipment = fixture
                    .Build<Domain.Model.Shipment>()
                    .WithoutBaseProperties()
                    .Without(x => x.Sender)
                    .Without(x => x.SenderId)
                    .Without(x => x.SenderAlternative)
                    .Without(x => x.SenderAlternativeId)
                    .Without(x => x.Receiver)
                    .Without(x => x.ReceiverId)
                    .Without(x => x.ReceiverAlternative)
                    .With(x => x.ReceiverAlternativeId, _existingAddress.Id)
                    .With(x => x.ShipmentDetails, new List<ShipmentDetail> { createdShipmentDetailsRow })
                    .Create();
                context.Shipments.Add(createdShipment);
                context.SaveChanges();

                _deliveryId = createdShipment.Id;
            });
        }

        [Fact]
        public void with_no_properties__then_validations_errors_occur()
        {
            // Arrange
            var viewModel = new ShipmentCreateOrUpdateRequestViewModel();

            // Act
            TestServiceResult<bool> result;
            using (var client = ApiServerFixture.Current.Server.CreateClient())
                result = client.HttpPutJson<TestServiceResult<bool>>($"{Endpoint}/{_deliveryId}", viewModel, expectSuccess: false).Result;

            // Assert
            Assert.False(result.IsSuccessful);
            var errors = result.TestValidation.Errors;
            Assert.Equal(4, errors.Count);
            Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.Number));
            Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.Company));
            Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.Status));
            Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.Total));
        }

        [Fact]
        public void with_all_properties__then_properties_should_be_updated()
        {
            // Arrange
            var fixture = new Fixture();

            // should be created
            var sender = fixture.Build<ShipmentResponseViewModel.ShipmentContact>()
                .With(x => x.Id, 9999999) // some non-existing address
                .With(x => x.UpdateContact, true)
                .Create();

            // should not be created
            var senderAlternative = fixture.Build<ShipmentResponseViewModel.ShipmentContact>()
                .With(x => x.UpdateContact, false) // we don't want it to be created
                .Create();

            // should be created
            var receiver = fixture.Build<ShipmentResponseViewModel.ShipmentContact>()
                .Without(x => x.Id)
                .With(x => x.UpdateContact, true)
                .Create();

            // should be updated // TODO: What happens if we use the same id  for different address?
            var receiverAlternative = fixture.Build<ShipmentResponseViewModel.ShipmentContact>()
                .With(x => x.Id, _existingAddress.Id) // we want it to be updated
                .With(x => x.UpdateContact, true)
                .Create();

            var updatedShipmentDetailsRow = fixture.Create<ShipmentResponseViewModel.ShipmentDetailsRow>();
            var deliveryRequestViewModel = fixture
                .Build<ShipmentCreateOrUpdateRequestViewModel>()
                .With(x => x.Sender, sender)
                .With(x => x.SenderAlternative, senderAlternative)
                .With(x => x.Receiver, receiver)
                .With(x => x.ReceiverAlternative, receiverAlternative)
                .With(x => x.ShipmentDetailsRows, new List<ShipmentResponseViewModel.ShipmentDetailsRow> { updatedShipmentDetailsRow })
                .Create();

            // Act
            ServiceResult<bool> result;
            using (var client = ApiServerFixture.Current.Server.CreateClient())
                result = client.HttpPutJson<ServiceResult<bool>>($"{Endpoint}/{_deliveryId}", deliveryRequestViewModel)
                    .Result;

            // Assert
            Assert.True(result.Payload);
            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var delivery = context.Shipments.Include(x => x.ShipmentDetails)
                    .FirstOrDefault(x => x.Id == _deliveryId);
                Assert.NotNull(delivery);
                Assert.Equal(deliveryRequestViewModel.Number, delivery.Number);
                Assert.Equal(deliveryRequestViewModel.Status, delivery.Status);
                //Assert.Equal(_deliveryRequestViewModel.DeliveryDate, delivery.EstimatedReceiveDate);
                Assert.Equal(deliveryRequestViewModel.TotalEur, delivery.TotalEur);

                // Sender
                Assert.Equal(deliveryRequestViewModel.Sender.Country, delivery.SenderCountry);
                Assert.Equal(deliveryRequestViewModel.Sender.PostCode, delivery.SenderPostCode);
                Assert.Equal(deliveryRequestViewModel.Sender.City, delivery.SenderCity);
                Assert.Equal(deliveryRequestViewModel.Sender.AddressLine1, delivery.SenderAddressLine1);
                Assert.Equal(deliveryRequestViewModel.Sender.AddressLine2, delivery.SenderAddressLine2);
                Assert.Equal(deliveryRequestViewModel.Sender.AddressLine3, delivery.SenderAddressLine3);
                Assert.Equal(deliveryRequestViewModel.Sender.CompanyName, delivery.SenderCompanyName);
                Assert.Equal(deliveryRequestViewModel.Sender.ContactPersonName, delivery.SenderContactPersonName);
                Assert.Equal(deliveryRequestViewModel.Sender.Phone, delivery.SenderPhone);
                Assert.Equal(deliveryRequestViewModel.Sender.Email, delivery.SenderEmail);
                Assert.Equal(deliveryRequestViewModel.Sender.Vat, delivery.SenderVat);

                var senderAddress = context.Addresses.SingleOrDefault(x => x.Company == deliveryRequestViewModel.Sender.CompanyName);
                Assert.NotNull(senderAddress);
                AssertAddress(senderAddress, deliveryRequestViewModel.Sender);

                // Sender Alternative
                Assert.Equal(deliveryRequestViewModel.SenderAlternative.Country, delivery.SenderAlternativeCountry);
                Assert.Equal(deliveryRequestViewModel.SenderAlternative.PostCode, delivery.SenderAlternativePostCode);
                Assert.Equal(deliveryRequestViewModel.SenderAlternative.City, delivery.SenderAlternativeCity);
                Assert.Equal(deliveryRequestViewModel.SenderAlternative.AddressLine1, delivery.SenderAlternativeAddressLine1);
                Assert.Equal(deliveryRequestViewModel.SenderAlternative.AddressLine2, delivery.SenderAlternativeAddressLine2);
                Assert.Equal(deliveryRequestViewModel.SenderAlternative.AddressLine3, delivery.SenderAlternativeAddressLine3);
                Assert.Equal(deliveryRequestViewModel.SenderAlternative.CompanyName, delivery.SenderAlternativeCompanyName);
                Assert.Equal(deliveryRequestViewModel.SenderAlternative.ContactPersonName, delivery.SenderAlternativeContactPersonName);
                Assert.Equal(deliveryRequestViewModel.SenderAlternative.Phone, delivery.SenderAlternativePhone);
                Assert.Equal(deliveryRequestViewModel.SenderAlternative.Email, delivery.SenderAlternativeEmail);
                Assert.Equal(deliveryRequestViewModel.SenderAlternative.Vat, delivery.SenderAlternativeVat);

                var senderAlternativeAddress = context.Addresses.SingleOrDefault(x => x.Company == deliveryRequestViewModel.SenderAlternative.CompanyName);
                Assert.Null(senderAlternativeAddress);

                // Receiver
                Assert.Equal(deliveryRequestViewModel.Receiver.Country, delivery.ReceiverCountry);
                Assert.Equal(deliveryRequestViewModel.Receiver.PostCode, delivery.ReceiverPostCode);
                Assert.Equal(deliveryRequestViewModel.Receiver.City, delivery.ReceiverCity);
                Assert.Equal(deliveryRequestViewModel.Receiver.AddressLine1, delivery.ReceiverAddressLine1);
                Assert.Equal(deliveryRequestViewModel.Receiver.AddressLine2, delivery.ReceiverAddressLine2);
                Assert.Equal(deliveryRequestViewModel.Receiver.AddressLine3, delivery.ReceiverAddressLine3);
                Assert.Equal(deliveryRequestViewModel.Receiver.CompanyName, delivery.ReceiverCompanyName);
                Assert.Equal(deliveryRequestViewModel.Receiver.ContactPersonName, delivery.ReceiverContactPersonName);
                Assert.Equal(deliveryRequestViewModel.Receiver.Phone, delivery.ReceiverPhone);
                Assert.Equal(deliveryRequestViewModel.Receiver.Email, delivery.ReceiverEmail);
                Assert.Equal(deliveryRequestViewModel.Receiver.Vat, delivery.ReceiverVat);

                var receiverAddress = context.Addresses.SingleOrDefault(x => x.Company == deliveryRequestViewModel.Receiver.CompanyName);
                Assert.NotNull(receiverAddress);
                AssertAddress(receiverAddress, deliveryRequestViewModel.Receiver);

                // Receiver Alternative
                Assert.Equal(deliveryRequestViewModel.Receiver.Country, delivery.ReceiverCountry);
                Assert.Equal(deliveryRequestViewModel.Receiver.PostCode, delivery.ReceiverPostCode);
                Assert.Equal(deliveryRequestViewModel.Receiver.City, delivery.ReceiverCity);
                Assert.Equal(deliveryRequestViewModel.Receiver.AddressLine1, delivery.ReceiverAddressLine1);
                Assert.Equal(deliveryRequestViewModel.Receiver.AddressLine2, delivery.ReceiverAddressLine2);
                Assert.Equal(deliveryRequestViewModel.Receiver.AddressLine3, delivery.ReceiverAddressLine3);
                Assert.Equal(deliveryRequestViewModel.Receiver.CompanyName, delivery.ReceiverCompanyName);
                Assert.Equal(deliveryRequestViewModel.Receiver.ContactPersonName, delivery.ReceiverContactPersonName);
                Assert.Equal(deliveryRequestViewModel.Receiver.Phone, delivery.ReceiverPhone);
                Assert.Equal(deliveryRequestViewModel.Receiver.Email, delivery.ReceiverEmail);
                Assert.Equal(deliveryRequestViewModel.Receiver.Vat, delivery.ReceiverVat);

                var receiverAlternativeAddress = context.Addresses.SingleOrDefault(x => x.Id == _existingAddress.Id);
                Assert.NotNull(receiverAlternativeAddress);
                AssertAddress(receiverAlternativeAddress, deliveryRequestViewModel.ReceiverAlternative);

                // Shipment details
                Assert.Equal(1, deliveryRequestViewModel.ShipmentDetailsRows.Count);
                Assert.Equal(1, delivery.ShipmentDetails.Count);

                var deliveryRequestViewModelFirstShipmentDetail = deliveryRequestViewModel.ShipmentDetailsRows[0];
                var firstShipmentDetail = delivery.ShipmentDetails[0];
                Assert.Equal(deliveryRequestViewModelFirstShipmentDetail.QuantityId, firstShipmentDetail.QuantityId);
                Assert.Equal(deliveryRequestViewModelFirstShipmentDetail.TypeId, firstShipmentDetail.TypeId);
                Assert.Equal(deliveryRequestViewModelFirstShipmentDetail.Length, firstShipmentDetail.Length);
                Assert.Equal(deliveryRequestViewModelFirstShipmentDetail.Width, firstShipmentDetail.Width);
                Assert.Equal(deliveryRequestViewModelFirstShipmentDetail.Height, firstShipmentDetail.Height);
                Assert.Equal(deliveryRequestViewModelFirstShipmentDetail.Weight, firstShipmentDetail.Weight);
                Assert.Equal(deliveryRequestViewModelFirstShipmentDetail.ProductDescription,
                    firstShipmentDetail.ProductDescription);
                Assert.Equal(deliveryRequestViewModelFirstShipmentDetail.ProductAdditionalInfo,
                    firstShipmentDetail.ProductAdditionalInfo);
                Assert.Equal(deliveryRequestViewModelFirstShipmentDetail.DangerousGoods,
                    firstShipmentDetail.DangerousGoods);
            });
        }

        private void AssertAddress(DAL.Model.Address address, ShipmentResponseViewModel.ShipmentContact viewModel)
        {
            Assert.Equal(address.Country, viewModel.Country);
            Assert.Equal(address.PostalCode, viewModel.PostCode);
            Assert.Equal(address.City, viewModel.City);
            Assert.Equal(address.AddressLine1, viewModel.AddressLine1);
            Assert.Equal(address.AddressLine2, viewModel.AddressLine2);
            Assert.Equal(address.AddressLine3, viewModel.AddressLine3);
            Assert.Equal(address.Company, viewModel.CompanyName);
            Assert.Equal(address.ContactName, viewModel.ContactPersonName);
            Assert.Equal(address.ContactPhoneNumber, viewModel.Phone);
            Assert.Equal(address.ContactEmail, viewModel.Email);
        }
    }
}
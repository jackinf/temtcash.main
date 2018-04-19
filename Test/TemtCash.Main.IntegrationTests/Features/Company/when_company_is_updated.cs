using System.Linq;
using AutoFixture;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Company;
using TemtCash.Main.IntegrationTests.Utils;
using Xunit;
using Validator = TemtCash.Main.Api.Services.Validator.CompanyCreateOrUpdateRequestViewModelValidator;

namespace TemtCash.Main.IntegrationTests.Features.Address
{
    public class when_company_is_updated : clear_data
    {
        private const string Endpoint = "/api/company";
        private int _modelId;

        public when_company_is_updated()
        {
            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var createdModel = new Fixture().Build<Domain.Model.Company>()
                    .WithoutBaseProperties()
                    .Create();;
                context.Companies.Add(createdModel);
                context.SaveChanges();

                _modelId = createdModel.Id;
            });
        }

        [Fact]
        public void with_no_properties__then_properties_should_be_updated()
        {
            // Arrange
            var updatedModel = new CompanyCreateOrUpdateRequestViewModel();

            // Act
            TestServiceResult<bool> result;
            using (var client = ApiServerFixture.Current.Server.CreateClient())
                result = client.HttpPutJson<TestServiceResult<bool>>($"{Endpoint}/{_modelId}", updatedModel, expectSuccess: false).Result;

            // Assert
            Assert.False(result.Payload);
            Assert.False(result.IsSuccessful);
            var errors = result.TestValidation.Errors;
            //Assert.Equal(7, errors.Count);
            //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.Country));
            //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.PostalCode));
            //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.City));
            //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.AddressLine1));
            //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.Company));
            //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.ContactName));
            //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.ContactPhoneNumber));
        }

        [Fact]
        public void with_all_properties__then_properties_should_be_updated()
        {
            // Arrange
            var updatedModel = new Fixture().Create<CompanyCreateOrUpdateRequestViewModel>();

            // Act
            ServiceResult<bool> result;
            using (var client = ApiServerFixture.Current.Server.CreateClient())
                result = client.HttpPutJson<ServiceResult<bool>>($"{Endpoint}/{_modelId}", updatedModel).Result;

            // Assert
            Assert.True(result.Payload);
            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var model = context.Companies.SingleOrDefault(x => x.Id == _modelId);
                Assert.NotNull(model);
                //Assert.Equal(address.Country, updatedAddress.Country);
                //Assert.Equal(address.PostalCode, updatedAddress.PostalCode);
                //Assert.Equal(address.City, updatedAddress.City);
                //Assert.Equal(address.AddressLine1, updatedAddress.AddressLine1);
                //Assert.Equal(address.AddressLine2, updatedAddress.AddressLine2);
                //Assert.Equal(address.AddressLine3, updatedAddress.AddressLine3);
                //Assert.Equal(address.Company, updatedAddress.Company);
                //Assert.Equal(address.ContactName, updatedAddress.ContactName);
                //Assert.Equal(address.ContactPhoneNumber, updatedAddress.ContactPhoneNumber);
                //Assert.Equal(address.ContactEmail, updatedAddress.ContactEmail);
                //Assert.Equal(address.KmkRegistrationNumber, updatedAddress.KmkRegistrationNumber);
                //Assert.Equal(address.TntClientNumber, updatedAddress.TntClientNumber);
                //Assert.Equal(address.ContactReference, updatedAddress.ContactReference);
            });
        }
    }
}
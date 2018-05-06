using AutoFixture;
using SpeysCloud.Core.Result;
using TemtCash.Main.Api.Controllers;
using TemtCash.Main.Api.Controllers.ForAdmin;
using TemtCash.Main.Domain.ViewModel.Services.Company.Requests;
using TemtCash.Main.IntegrationTests.Utils;
using Xunit;

namespace TemtCash.Main.IntegrationTests.Features.Company
{
    public class when_customer_is_created
    {
        private const string Endpoint = CompanyController.ApiEndpoint;

        [Fact]
        public void with_no_properties__then_validations_errors_occur()
        {
            // Arrange
            var viewModel = new CompanyCreateOrUpdateRequestViewModel();

            // Act
            TestServiceResult<int> result;
            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                result = client.HttpPostJson<TestServiceResult<int>>(Endpoint, viewModel, expectSuccess: false).Result;
            }

            // Assert
            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var address = context.Companies.Find(result.Payload);
                Assert.Null(address);

                Assert.False(result.IsSuccessful);
                var errors = result.TestValidation.Errors;
                Assert.Equal(7, errors.Count);
                // TODO
                //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.Country));
                //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.PostalCode));
                //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.City));
                //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.AddressLine1));
                //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.Company));
                //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.ContactName));
                //Assert.NotNull(errors.SingleOrDefault(x => x.ErrorMessage == Validator.ErrorMessage.Required.ContactPhoneNumber));
            });
        }

        [Fact]
        public void with_all_properties__then_items_should_be_in_db()
        {
            // Arrange
            var viewModel = new Fixture().Create<CompanyCreateOrUpdateRequestViewModel>();

            // Act
            ServiceResult<int> result;
            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                result = client.HttpPostJson<ServiceResult<int>>(Endpoint, viewModel).Result;
            }

            // Assert
            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var model = context.Companies.Find(result.Payload);
                Assert.NotNull(model);
                //Assert.Equal(address.Country, viewModel.Country);
                //Assert.Equal(address.PostalCode, viewModel.PostalCode);
                //Assert.Equal(address.City, viewModel.City);
                //Assert.Equal(address.AddressLine1, viewModel.AddressLine1);
                //Assert.Equal(address.AddressLine2, viewModel.AddressLine2);
                //Assert.Equal(address.AddressLine3, viewModel.AddressLine3);
                //Assert.Equal(address.Company, viewModel.Company);
                //Assert.Equal(address.ContactName, viewModel.ContactName);
                //Assert.Equal(address.ContactPhoneNumber, viewModel.ContactPhoneNumber);
                //Assert.Equal(address.ContactEmail, viewModel.ContactEmail);
                //Assert.Equal(address.KmkRegistrationNumber, viewModel.KmkRegistrationNumber);
                //Assert.Equal(address.TntClientNumber, viewModel.TntClientNumber);
                //Assert.Equal(address.ContactReference, viewModel.ContactReference);
            });
        }
    }
}
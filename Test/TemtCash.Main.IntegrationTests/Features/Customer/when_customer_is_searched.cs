using AutoFixture;
using SpeysCloud.Core.Result;
using TemtCash.Main.Api.Controllers;
using TemtCash.Main.Domain.ViewModel.Services.Customer.Response;
using TemtCash.Main.IntegrationTests.Utils;
using Xunit;

namespace TemtCash.Main.IntegrationTests.Features.Customer
{
    public class when__customer_is_searched : clear_data
    {
        private const string Endpoint = CustomerController.ApiEndpoint;
        private int _lastAddedId;
        private Domain.Model.Customer _lastAdded = null;

        public when__customer_is_searched()
        {
            var fixture = new Fixture();

            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    var createdModel = fixture.Build<Domain.Model.Customer>()
                        .WithoutBaseProperties()
                        .Create();
                    
                    context.Customers.Add(createdModel);
                    _lastAdded = createdModel;
                }
                
                context.SaveChanges();

                Assert.NotNull(_lastAdded);
                _lastAddedId = _lastAdded.Id;
            });
        }

        [Fact]
        public void then_it_should_find_by_id()
        {
            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                var response = client.HttpGet<ServiceResult<CustomerResponseViewModel>>($"{Endpoint}/{_lastAddedId}").Result;
                Assert.True(response.IsSuccessful);
                var result = response.Payload;
                Assert.NotNull(result);

                // TODO
                //Assert.Equal(result.Country, _lastAdded.Country);
                //Assert.Equal(result.PostalCode, _lastAdded.PostalCode);
                //Assert.Equal(result.City, _lastAdded.City);
                //Assert.Equal(result.AddressLine1, _lastAdded.AddressLine1);
                //Assert.Equal(result.AddressLine2, _lastAdded.AddressLine2);
                //Assert.Equal(result.AddressLine3, _lastAdded.AddressLine3);
                //Assert.Equal(result.Company, _lastAdded.Company);
                //Assert.Equal(result.ContactName, _lastAdded.ContactName);
                //Assert.Equal(result.ContactPhoneNumber, _lastAdded.ContactPhoneNumber);
                //Assert.Equal(result.ContactEmail, _lastAdded.ContactEmail);
                //Assert.Equal(result.KmkRegistrationNumber, _lastAdded.KmkRegistrationNumber);
                //Assert.Equal(result.TntClientNumber, _lastAdded.TntClientNumber);
                //Assert.Equal(result.ContactReference, _lastAdded.ContactReference);
            }
        }
    }
}
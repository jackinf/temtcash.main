using AutoFixture;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.Domain.ViewModel.Services.AddressBook;
using SpeysCloud.Main.IntegrationTests.Utils;
using Xunit;

namespace SpeysCloud.Main.IntegrationTests.Features.Address
{
    public class when_address_is_searched : clear_data
    {
        private int _lastAddedId;
        private DAL.Model.Address _lastAdded = null;

        public when_address_is_searched()
        {
            var fixture = new Fixture();

            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    var createdAddress = fixture.Build<DAL.Model.Address>()
                        .WithoutBaseProperties()
                        .Create();
                    
                    context.Addresses.Add(createdAddress);
                    _lastAdded = createdAddress;
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
                var response = client.HttpGet<ServiceResult<AddressResponseViewModel>>($"/api/addressbook/{_lastAddedId}").Result;
                Assert.True(response.IsSuccessful);
                var result = response.Payload;
                Assert.NotNull(result);

                Assert.Equal(result.Country, _lastAdded.Country);
                Assert.Equal(result.PostalCode, _lastAdded.PostalCode);
                Assert.Equal(result.City, _lastAdded.City);
                Assert.Equal(result.AddressLine1, _lastAdded.AddressLine1);
                Assert.Equal(result.AddressLine2, _lastAdded.AddressLine2);
                Assert.Equal(result.AddressLine3, _lastAdded.AddressLine3);
                Assert.Equal(result.Company, _lastAdded.Company);
                Assert.Equal(result.ContactName, _lastAdded.ContactName);
                Assert.Equal(result.ContactPhoneNumber, _lastAdded.ContactPhoneNumber);
                Assert.Equal(result.ContactEmail, _lastAdded.ContactEmail);
                Assert.Equal(result.KmkRegistrationNumber, _lastAdded.KmkRegistrationNumber);
                Assert.Equal(result.TntClientNumber, _lastAdded.TntClientNumber);
                Assert.Equal(result.ContactReference, _lastAdded.ContactReference);
            }
        }
    }
}
using System.Threading.Tasks;
using AutoFixture;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.Domain.ViewModel.Services.AddressBook;
using SpeysCloud.Main.IntegrationTests.Utils;
using Xunit;

namespace SpeysCloud.Main.IntegrationTests.Features.Address
{
    public class when_address_is_deleted : clear_data
    {
        private const string Endpoint = "/api/addressbook";
        private int _addressId;
        private readonly ServiceResult<bool> _result;

        public when_address_is_deleted()
        {
            var fixture = new Fixture();

            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var createdAddress = fixture.Build<DAL.Model.Address>()
                    .WithoutBaseProperties()
                    .Create();
                context.Addresses.Add(createdAddress);
                context.SaveChanges();

                _addressId = createdAddress.Id;
            });

            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                _result = client.HttpDelete<ServiceResult<bool>>($"{Endpoint}/{_addressId}").Result;
            }
        }

        [Fact]
        public async Task then_address_should_not_be_in_database()
        {
            Assert.True(_result.Payload);
            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var address = context.Addresses.Find(_addressId);
                Assert.NotNull(address.DeletedOn);
            });

            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                var result = await client.HttpGet<ServiceResult<AddressResponseViewModel>>($"{Endpoint}/{_addressId}");
                Assert.Null(result.Payload);
            }
        }
    }
}
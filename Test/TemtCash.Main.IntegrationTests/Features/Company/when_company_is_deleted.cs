using System.Threading.Tasks;
using AutoFixture;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.ViewModel.Services.Company;
using TemtCash.Main.IntegrationTests.Utils;
using Xunit;

namespace TemtCash.Main.IntegrationTests.Features.Address
{
    public class when_company_is_deleted : clear_data
    {
        private const string Endpoint = "/api/company";
        private int _modelId;
        private readonly ServiceResult<bool> _result;

        public when_company_is_deleted()
        {
            var fixture = new Fixture();

            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var createdModel = fixture.Build<Domain.Model.Company>()
                    .WithoutBaseProperties()
                    .Create();
                context.Companies.Add(createdModel);
                context.SaveChanges();

                _modelId = createdModel.Id;
            });

            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                _result = client.HttpDelete<ServiceResult<bool>>($"{Endpoint}/{_modelId}").Result;
            }
        }

        [Fact]
        public async Task then_address_should_not_be_in_database()
        {
            Assert.True(_result.Payload);
            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var model = context.Companies.Find(_modelId);
                Assert.NotNull(model.DeletedOn);
            });

            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                var result = await client.HttpGet<ServiceResult<CompanyResponseViewModel>>($"{Endpoint}/{_modelId}");
                Assert.Null(result.Payload);
            }
        }
    }
}
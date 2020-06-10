using AutoFixture;
using SpeysCloud.Core.Result;
using TemtCash.Main.Api.Controllers;
using TemtCash.Main.Api.Controllers.ForAdmin;
using TemtCash.Main.Domain.ViewModel.Services.Company.Response;
using TemtCash.Main.IntegrationTests.Utils;
using Xunit;

namespace TemtCash.Main.IntegrationTests.Features.Company
{
    public class when_customer_is_searched : clear_data
    {
        private const string Endpoint = CompanyController.ApiEndpoint;
        private int _lastAddedId;
        private Domain.Model.Company _lastAdded = null;

        public when_customer_is_searched()
        {
            var fixture = new Fixture();

            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    var createdModel = fixture.Build<Domain.Model.Company>()
                        .WithoutBaseProperties()
                        .Create();
                    
                    context.Companies.Add(createdModel);
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
                var response = client.HttpGet<ServiceResult<CompanyResponseViewModel>>($"{Endpoint}/{_lastAddedId}").Result;
                Assert.True(response.IsSuccessful);
                var result = response.Payload;
                Assert.NotNull(result);
            }
        }
    }
}
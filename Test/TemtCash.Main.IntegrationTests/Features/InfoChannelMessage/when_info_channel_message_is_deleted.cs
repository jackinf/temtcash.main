using System.Threading.Tasks;
using AutoFixture;
using SpeysCloud.Core.Result;
using TemtCash.Main.Api.Controllers;
using TemtCash.Main.Api.Controllers.ForAdmin;
using TemtCash.Main.Domain.ViewModel.Services.Company.Response;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage.Response;
using TemtCash.Main.IntegrationTests.Utils;
using Xunit;

namespace TemtCash.Main.IntegrationTests.Features.InfoChannelMessage
{
    public class when_info_channel_message_licence_is_deleted : clear_data
    {
        private const string Endpoint = InfoChannelMessageController.ApiEndpoint;
        private int _modelId;
        private readonly ServiceResult<bool> _result;

        public when_info_channel_message_licence_is_deleted()
        {
            var fixture = new Fixture();

            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var createdModel = fixture.Build<Domain.Model.InfoChannelMessage>()
                    .WithoutBaseProperties()
                    .Create();
                context.InfoChannelMessages.Add(createdModel);
                context.SaveChanges();

                _modelId = createdModel.Id;
            });

            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                _result = client.HttpDelete<ServiceResult<bool>>($"{Endpoint}/{_modelId}").Result;
            }
        }

        [Fact]
        public async Task then_item_should_not_be_in_database()
        {
            Assert.True(_result.Payload);
            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var model = context.InfoChannelMessages.Find(_modelId);
                Assert.NotNull(model.DeletedOn);
            });

            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                var result = await client.HttpGet<ServiceResult<InfoChannelMessageResponseViewModel>>($"{Endpoint}/{_modelId}");
                Assert.Null(result.Payload);
            }
        }
    }
}
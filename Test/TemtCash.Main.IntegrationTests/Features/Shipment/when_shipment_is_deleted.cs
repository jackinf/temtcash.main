using System;
using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.Domain.Enum;
using SpeysCloud.Main.Domain.ViewModel.Services.Shipment;
using SpeysCloud.Main.IntegrationTests.Utils;
using Xunit;

namespace SpeysCloud.Main.IntegrationTests.Features.Shipment
{
    public class when_shipment_is_deleted : clear_data
    {
        private int _shipmentId;
        private readonly ServiceResult<bool> _result;

        public when_shipment_is_deleted()
        {
            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var createdDelivery = new Domain.Model.Shipment();
                createdDelivery.Number = "Number123";
                createdDelivery.Status = ShipmentStatus.NotSelected;
                createdDelivery.TotalEur = 123;
                context.Shipments.Add(createdDelivery);
                context.SaveChanges();

                _shipmentId = createdDelivery.Id;
            });

            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                _result = client.HttpDelete<ServiceResult<bool>>($"/api/shipment/{_shipmentId}").Result;
            }
        }

        [Fact]
        public async Task then_delivery_should_not_be_in_database()
        {
            Assert.True(_result.Payload);
            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                var delivery = context.Shipments.Find(_shipmentId);
                Assert.NotNull(delivery.DeletedOn);
            });

            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                var result = await client.HttpGet<ServiceResult<ShipmentResponseViewModel>>($"/api/shipment/{_shipmentId}");
                Assert.Null(result.Payload);
            }
        }
    }
}
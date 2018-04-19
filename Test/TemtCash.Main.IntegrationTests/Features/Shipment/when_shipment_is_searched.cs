using System;
using System.Linq;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.Domain.Enum;
using SpeysCloud.Main.Domain.ViewModel.Services.Shipment;
using SpeysCloud.Main.IntegrationTests.Utils;
using Xunit;

namespace SpeysCloud.Main.IntegrationTests.Features.Shipment
{
    public class when_shipment_is_searched : clear_data
    {
        private const string Endpoint = "/api/shipment";
        private int _lastAddedId;

        public when_shipment_is_searched()
        {
            ApiServerFixture.Current.DoDatabaseOperation(context =>
            {
                Domain.Model.Shipment lastAdded = null;
                for (int i = 1; i <= 5; i++)
                {
                    var shipment = new Domain.Model.Shipment();
                    shipment.Number = $"SearchTest{i}";
                    shipment.Status = i%2 == 0 ? ShipmentStatus.NotSelected : ShipmentStatus.Collecting;
                    shipment.TotalEur = i;
                    shipment.EarliestArrivalDate = new DateTime(2011, 02, i);
                    context.Shipments.Add(shipment);
                    lastAdded = shipment;
                }
                
                context.SaveChanges();

                Assert.NotNull(lastAdded);
                _lastAddedId = lastAdded.Id;
            });
        }

        [Fact]
        public void then_it_should_find_by_id()
        {
            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                var i = 5; // last element
                var response = client.HttpGet<ServiceResult<ShipmentResponseViewModel>>($"{Endpoint}/{_lastAddedId}").Result;
                Assert.True(response.IsSuccessful);
                var result = response.Payload;
                Assert.NotNull(result);
                Assert.Equal($"SearchTest{i}", result.Number);
                Assert.Equal(i % 2 == 0 ? ShipmentStatus.NotSelected : ShipmentStatus.Collecting, result.Status);
                Assert.Equal(i, result.TotalEur);
            }
        }

        //[Fact]
        //public void then_it_should_find_by_company()
        //{
        //    using (var client = ApiServerFixture.Current.Server.CreateClient())
        //    {
        //        var response = client.HttpGet<ServiceResult<PaginatedListResult<DeliveriesResponseViewModel>>>($"/api/delivery?country=Country1").Result;
        //        var list = response.Payload;
        //        var item = list.ContextObjects.SingleOrDefault();
        //        Assert.NotNull(item);
        //    }
        //}

        [Fact]
        public void then_it_should_find_by_delivery_date()
        {
            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                var response = client
                    .HttpGet<ServiceResult<PaginatedListResult<ShipmentsResponseViewModel>>>($"{Endpoint}?${nameof(ShipmentsRequestViewModel.DeliveryDateFrom)}=2011.02.02&{nameof(ShipmentsRequestViewModel.DeliveryDateTo)}=2011.02.03")
                    .Result;
                var list = response.Payload;
                Assert.Equal(2, list.TotalCount);
                Assert.Equal(2, list.ContextObjects.Count);
                list.ContextObjects.ForEach(Assert.NotNull);
            }
        }

        [Fact]
        public void then_it_should_find_by_delivery_status()
        {
            using (var client = ApiServerFixture.Current.Server.CreateClient())
            {
                var response = client
                    .HttpGet<ServiceResult<PaginatedListResult<ShipmentsResponseViewModel>>>($"{Endpoint}?{nameof(ShipmentsRequestViewModel.Status)}=Collecting")
                    .Result;
                var list = response.Payload;
                Assert.Equal(3, list.ContextObjects.Count);
                Assert.Equal(3, list.TotalCount);
            }
        }
    }
}
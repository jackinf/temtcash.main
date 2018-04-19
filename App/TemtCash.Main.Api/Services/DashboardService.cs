using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Constant;
using SpeysCloud.Core.Factory;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.Domain.Repository;
using SpeysCloud.Main.Domain.Services;
using SpeysCloud.Main.Domain.ViewModel.Services.Dashboard;
using SpeysCloud.Main.Domain.ViewModel.Services.Shipment;

namespace SpeysCloud.Main.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IShipmentRepository _shipmentRepository;

        public DashboardService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<ServiceResult<List<RecentDeliveriesResponseViewModel>>> GetRecentDeliveries(RecentDeliveriesRequestViewModel viewModel)
        {
            const int totalSize = 10;
            var options = new ShipmentsRequestViewModel
            {
                SizePerPage = totalSize,
                SortName = ShipmentsRequestViewModel.OrderFields.CreatedOn,
                SortOrder = BaseConstants.OrderOptions_DESC
            };
            var shipments = await _shipmentRepository.Search(options);
            var items = shipments.ContextObjects.Select(shipment =>
                new RecentDeliveriesResponseViewModel
                {
                    Id = shipment.Id,
                    DeliveryNumber = shipment.Number,
                    Inserted = shipment.CreatedOn,
                    EstimatedReceiveDate = shipment.EarliestArrivalDate,
                    Status = shipment.Status?.ToString(),
                    DeliveryAddress = shipment.ReceiverAddressLine1,
                    Total = shipment.TotalEur
                }).ToList();
            return ServiceResultFactory.Success(items);
        }

        public Task<ServiceResult<FrequentContactsResponseViewModel>> GetFrequentContacts()
        {
            throw new NotImplementedException();
        }
    }
}
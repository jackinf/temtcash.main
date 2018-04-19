using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpeysCloud.Main.DAL.Model;
using SpeysCloud.Main.Domain.Repository;
using SpeysCloud.Main.Domain.ViewModel.Services.Shipment;
using SpeysCloud.Main.DAL.Helper;
using SpeysCloud.Main.Domain.Model;
using SpeysCloud.Core.Extension;
using SpeysCloud.Core.Result;

namespace SpeysCloud.Main.DAL.Repository
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ApplicationDbContext _context;

        public ShipmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedListResult<Shipment>> Search(ShipmentsRequestViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            var query = BaseQuery();

            if (viewModel.Company != null)
                query = query.Where(x => x.TransportCompany == viewModel.Company);
            
            if (viewModel.DeliveryDateFrom != null)
                query = query.Where(x => x.EarliestArrivalDate > viewModel.DeliveryDateFrom);
            
            if (viewModel.DeliveryDateTo != null)
                query = query.Where(x => x.EarliestArrivalDate < viewModel.DeliveryDateTo);

            if (viewModel.Status != null)
                query = query.Where(x => x.StatusString == viewModel.Status.ToString());

            switch (viewModel.SortName?.ToUpper())
            {
                case ShipmentsRequestViewModel.OrderFields.CreatedOn:
                    query = query.OrderUsingSearchOptions(viewModel, x => x.CreatedOn);
                    break;
                case ShipmentsRequestViewModel.OrderFields.Company:
                    query = query.OrderUsingSearchOptions(viewModel, x => x.TransportCompany);
                    break;
                case ShipmentsRequestViewModel.OrderFields.DeliveryDate:
                    query = query.OrderUsingSearchOptions(viewModel, x => x.EarliestArrivalDate);
                    break;
                case ShipmentsRequestViewModel.OrderFields.Status:
                    query = query.OrderUsingSearchOptions(viewModel, x => x.StatusString);
                    break;
                default:
                    query = query.OrderBy(x => x.Id);
                    break;
            }
            
            return await query.ToPaginatedListResultAsync(viewModel);
        }

        public async Task<Shipment> GetSingle(int deliveryId)
        {
            if (deliveryId <= 0)
            {
                throw new ArgumentException(nameof(deliveryId), "Argument should be greater than 0");
            }

            return await BaseQuery().Include(x => x.ShipmentDetails).SingleOrDefaultAsync(x => x.Id == deliveryId);
        }

        public async Task Add(Shipment shipment)
        {
            if (shipment == null)
            {
                throw new ArgumentNullException(nameof(shipment));
            }

            shipment.CreatedOn = DateTime.UtcNow;
            await _context.Shipments.AddAsync(shipment);
        }

        public void Update(Shipment shipment)
        {
            if (shipment == null)
            {
                throw new ArgumentNullException(nameof(shipment));
            }

            shipment.UpdatedOn = DateTime.UtcNow;
            _context.Shipments.Update(shipment);
        }

        public void Delete(Shipment shipment)
        {
            if (shipment == null)
            {
                throw new ArgumentNullException(nameof(shipment));
            }

            shipment.DeletedOn = DateTime.UtcNow;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void RemoveRange(List<ShipmentDetail> shipmentShipmentDetails) => _context.RemoveRange(shipmentShipmentDetails);

        private IQueryable<Shipment> BaseQuery() => _context.Shipments.Where(x => x.DeletedOn == null);
    }
}
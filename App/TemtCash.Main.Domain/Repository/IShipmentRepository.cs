using System.Collections.Generic;
using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.DAL.Model;
using SpeysCloud.Main.Domain.Model;
using SpeysCloud.Main.Domain.ViewModel.Services.Shipment;

namespace SpeysCloud.Main.Domain.Repository
{
    public interface IShipmentRepository
    {
        Task<PaginatedListResult<Shipment>> Search(ShipmentsRequestViewModel viewModel);

        Task<Shipment> GetSingle(int id);

        Task Add(Shipment shipment);

        void Update(Shipment shipment);

        void Delete(Shipment shipment);

        Task<int> SaveChangesAsync();

        void RemoveRange(List<ShipmentDetail> shipmentShipmentDetails);
    }
}
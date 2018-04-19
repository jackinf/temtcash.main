using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.Domain.ViewModel.Services.Shipment;

namespace SpeysCloud.Main.Domain.Services
{
    public interface IShipmentService
    {
        Task<ServiceResult<PaginatedListResult<ShipmentsResponseViewModel>>> Search(ShipmentsRequestViewModel viewModel);

        Task<ServiceResult<ShipmentResponseViewModel>> GetSingle(int deliveryId);

        Task<ServiceResult<int>> Create(ShipmentCreateOrUpdateRequestViewModel model);

        Task<ServiceResult<bool>> Update(int deliveryId, ShipmentCreateOrUpdateRequestViewModel model);

        Task<ServiceResult<bool>> Delete(int deliveryId);
    }
}
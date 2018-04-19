using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.Domain.ViewModel.Services.AddressBook;

namespace SpeysCloud.Main.Domain.Services
{
    public interface IAddressService
    {
        Task<ServiceResult<PaginatedListResult<AddressesResponseViewModel>>> GetAddresses(AddressesRequestViewModel viewModel);

        Task<ServiceResult<AddressResponseViewModel>> GetAddress(int addressId);

        Task<ServiceResult<ShipmentContactViewModel>> GetSingleShipmentContact(int addressId);

        Task<ServiceResult<int>> CreateAddress(AddressCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> UpdateAddress(int addressId, AddressCreateOrUpdateRequestViewModel viewModel);

        Task<ServiceResult<bool>> DeleteAddress(int addressId);
    }
}
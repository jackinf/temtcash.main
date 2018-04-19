using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.DAL.Model;
using SpeysCloud.Main.Domain.ViewModel.Services.AddressBook;

namespace SpeysCloud.Main.Domain.Repository
{
    public interface IAddressRepository
    {
        Task<PaginatedListResult<Address>> Search(AddressesRequestViewModel viewModel);

        Task<Address> GetSingleAsync(int addressId);

        //Task<ShipmentContactViewModel> GetSingleShipmentContact(int userId);

        Task AddAsync(Address address);

        void Update(Address address);

        void Delete(Address address);

        Task<int> SaveChangesAsync();
    }
}
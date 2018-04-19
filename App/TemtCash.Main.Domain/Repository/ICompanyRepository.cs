using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.Company;

namespace TemtCash.Main.Domain.Repository
{
    public interface ICompanyRepository
    {
        Task<PaginatedListResult<Company>> Search(CompaniesRequestViewModel viewModel);

        Task<Company> GetSingleAsync(int id);

        //Task<ShipmentContactViewModel> GetSingleShipmentContact(int userId);

        Task AddAsync(Company model);

        void Update(Company model);

        void Delete(Company model);

        Task<int> SaveChangesAsync();
    }
}
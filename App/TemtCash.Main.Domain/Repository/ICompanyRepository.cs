using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.Company;

namespace TemtCash.Main.Domain.Repository
{
    public interface ICompanyRepository : ICrudRepository<Company, CompaniesRequestViewModel>
    {
    }
}
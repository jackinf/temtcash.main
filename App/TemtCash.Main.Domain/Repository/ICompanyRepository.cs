using System.Threading.Tasks;
using SpeysCloud.Core.Result;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.ViewModel.Services.Company;
using TemtCash.Main.Domain.ViewModel.Services.Company.Requests;

namespace TemtCash.Main.Domain.Repository
{
    public interface ICompanyRepository : ICrudRepository<Company>
    {
        Task<PaginatedListResult<Company>> Search(CompaniesRequestViewModel viewModel);
    }
}
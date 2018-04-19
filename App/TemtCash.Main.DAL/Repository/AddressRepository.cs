using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpeysCloud.Core.Extension;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.DAL.Helper;
using SpeysCloud.Main.DAL.Model;
using SpeysCloud.Main.Domain.Repository;
using SpeysCloud.Main.Domain.ViewModel.Services.AddressBook;

namespace SpeysCloud.Main.DAL.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedListResult<Address>> Search(AddressesRequestViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            var query = BaseQuery();

            // Filtering
            if (!string.IsNullOrWhiteSpace(viewModel.Keyword))
            {
                query = query.Where(x => x.Company.Contains(viewModel.Keyword)
                    || x.City.Contains(viewModel.Keyword)
                    || x.AddressLine1.Contains(viewModel.Keyword)
                    || x.AddressLine2.Contains(viewModel.Keyword)
                    || x.AddressLine3.Contains(viewModel.Keyword)
                    || x.ContactName.Contains(viewModel.Keyword)
                );
            }

            // Sorting
            string sortName = viewModel.SortName?.ToUpper();
            if (sortName == AddressesRequestViewModel.OrderFields.Company)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Company);
            else if (sortName == AddressesRequestViewModel.OrderFields.CityCountry)
                query = query
                    .OrderUsingSearchOptions(viewModel, x => x.City)
                    .OrderUsingSearchOptions(viewModel, x => x.Country);
            else if (sortName == AddressesRequestViewModel.OrderFields.Street)
                query = query.OrderUsingSearchOptions(viewModel, x => x.AddressLine1);
            else if (sortName == AddressesRequestViewModel.OrderFields.Contact)
                query = query.OrderUsingSearchOptions(viewModel, x => x.ContactName);
            else if (sortName == AddressesRequestViewModel.OrderFields.CreationDate)
                query = query.OrderUsingSearchOptions(viewModel, x => x.CreatedOn);
            else
                query = query.OrderBy(x => x.Id);

            return await query.ToPaginatedListResultAsync(viewModel);
        }

        public async Task<Address> GetSingleAsync(int addressId)
        {
            if (addressId <= 0)
            {
                throw new ArgumentException(nameof(addressId), "Argument should be greater than 0");
            }

            return await BaseQuery().SingleOrDefaultAsync(x => x.Id == addressId);
        }

        public async Task AddAsync(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            address.CreatedOn = DateTime.UtcNow;
            await _context.Addresses.AddAsync(address);
        }

        public void Update(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            
            address.UpdatedOn = DateTime.UtcNow;
            _context.Addresses.Update(address);
        }

        public void Delete(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address), "Argument should be greater than 0");
            }

            address.DeletedOn = DateTime.UtcNow;
            _context.Addresses.Update(address);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        private IQueryable<Address> BaseQuery() => _context.Addresses.Where(x => x.DeletedOn == null);
    }
}
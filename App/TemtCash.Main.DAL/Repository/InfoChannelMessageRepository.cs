using System;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Extension;
using SpeysCloud.Core.Result;
using TemtCash.Main.DAL.Helper;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.ViewModel.Services.InfoChannelMessage.Request;

namespace TemtCash.Main.DAL.Repository
{
    public class InfoChannelMessageRepository : CrudRepository<InfoChannelMessage>, IInfoChannelMessageRepository
    {
        public InfoChannelMessageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<PaginatedListResult<InfoChannelMessage>> Search(InfoChannelMessagesRequestViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var query = BaseQuery();
            query = SearchFilter(query, viewModel);
            query = SearchSort(query, viewModel);

            return await query.ToPaginatedListResultAsync(viewModel);
        }

        protected IQueryable<InfoChannelMessage> SearchFilter(IQueryable<InfoChannelMessage> query, InfoChannelMessagesRequestViewModel viewModel)
        {
            return query;
        }

        protected IQueryable<InfoChannelMessage> SearchSort(IQueryable<InfoChannelMessage> query, InfoChannelMessagesRequestViewModel viewModel)
        {
            string sortName = viewModel.SortName?.ToUpper();
            if (sortName == InfoChannelMessagesRequestViewModel.OrderFields.Subject)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Title);
            else if (sortName == InfoChannelMessagesRequestViewModel.OrderFields.Message)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Message);
            else if (sortName == InfoChannelMessagesRequestViewModel.OrderFields.Date)
                query = query.OrderUsingSearchOptions(viewModel, x => x.UpdatedOn);
            else if (sortName == InfoChannelMessagesRequestViewModel.OrderFields.IsVisible)
                query = query.OrderUsingSearchOptions(viewModel, x => x.Visible);
            else
                query = query.OrderBy(x => x.Id);
            return query;
        }
    }
}
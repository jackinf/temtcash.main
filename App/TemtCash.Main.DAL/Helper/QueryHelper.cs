using System;
using System.Linq;
using System.Linq.Expressions;
using SpeysCloud.Core.Constant;
using SpeysCloud.Core.Result;
using SpeysCloud.Main.DAL.Model;

namespace SpeysCloud.Main.DAL.Helper
{
    public static class QueryHelper
    {
        public static IQueryable<T> OrderUsingSearchOptions<T, TU>(
            this IQueryable<T> query, 
            PaginatedSearchBaseOptionsResult options,
            Expression<Func<T, TU>> expression) where T : BaseModel<int>
        {
            var orderedQuery = options.SortOrder == BaseConstants.OrderOptions_DESC
                ? query.OrderByDescending(expression)
                : query.OrderBy(expression);
            return orderedQuery;
        }
    }
}
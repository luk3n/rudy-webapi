using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rudy.Common.Data.Pagination
{
    public static class PaginationExtensions
    {
        public static async Task<PagedResults<T>> Paginate<T>(this IQueryable<T> query, PagingOptions options)
        {
            var result = new PagedResults<T>
            {
                CurrentPage = options.PageNumber,
                PageSize = options.PageSize,
                TotalItems = await query.CountAsync(),
                Results = await query.Skip((options.PageNumber - 1) * options.PageSize).Take(options.PageSize).ToListAsync()
            };

            result.PageCount = (int)Math.Ceiling((double)result.TotalItems / options.PageSize);

            return result;
        }

        public static async Task<PagedResults<T>> Paginate<T>(this IQueryable<T> query, PagingOptions options, Sorts<T> sorts)
        {
            return await query.ApplySort(sorts).Paginate(options);
        }

        public static async Task<PagedResults<T>> Paginate<T>(this IQueryable<T> query, PagingOptions options, Sorts<T> sorts, Filters<T> filters)
        {
            return await query.ApplyFilter(filters).Paginate(options, sorts);
        }

        private static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, Filters<T> filters)
        {
            return !filters.IsValid() ? query : filters.Get().Aggregate(query, (current, filter) => current.Where(filter.Expression));
        }

        private static IQueryable<T> ApplySort<T>(this IQueryable<T> query, Sorts<T> sorts)
        {
            if (!sorts.IsValid()) return query;
            return Sorts<T>.ApplySorts(query, sorts);
        }
    }
}

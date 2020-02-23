using System.Collections.Generic;

namespace Rudy.Common.Data.Pagination
{
    public class PagedResults<T>
    {
        public IEnumerable<T> Results { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
    }
}

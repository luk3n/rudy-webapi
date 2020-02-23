using System;
using System.Linq.Expressions;

namespace Rudy.Common.Data.Pagination
{
    internal class Filter<T>
    {
        public bool Condition { get; set; }
        public Expression<Func<T, bool>> Expression { get; set; }
    }
}

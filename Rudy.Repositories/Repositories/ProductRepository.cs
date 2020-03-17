using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rudy.Common.Data.Pagination;
using Rudy.Models;
using System.Linq;

namespace Rudy.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(StockContext context)
            : base(context)
        {
        }

        public override async Task<PagedResults<Product>> GetAll(PagingOptions options)
        {
            //return await StockContext.Products.Include(prod => prod.category).Paginate(options);
            return await StockContext.Products.Select(p => new Product
            {
                name = p.name,
                category = p.category
            }).Paginate(options);
        }

        public StockContext StockContext
        {
            get { return Context as StockContext; }
        }
    }
}

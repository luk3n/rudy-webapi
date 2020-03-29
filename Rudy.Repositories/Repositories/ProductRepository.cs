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
            return await StockContext.Products.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Brand = p.Brand,
                Code = p.Code,
                Barcode = p.Barcode,
                Price = p.Price,
                MeasurementUnit = p.MeasurementUnit,
                CreationDate = p.CreationDate,
                Category = new Category
                {
                    Name = p.Category.Name
                }
            }).Paginate(options);
        }

        public StockContext StockContext
        {
            get { return Context as StockContext; }
        }
    }
}

using System;
using System.Threading.Tasks;
using Rudy.Common.Data.Pagination;
using Rudy.DTO;

namespace Rudy.Services.Interfaces
{
    public interface IProductService
    {
        Task<PagedResults<ProductDTO>> GetAll(PagingOptions options);
    }
}

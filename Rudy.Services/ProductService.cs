using System;
using System.Threading.Tasks;
using AutoMapper;
using Rudy.Common.Data.Pagination;
using Rudy.DTO;
using Rudy.Persistence;
using Rudy.Services.Interfaces;

namespace Rudy.Services
{
    public class ProductService : IProductService
    {
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResults<ProductDTO>> GetAll(PagingOptions options)
        {
            var products = await _unitOfWork.Products.GetAll(options);

            return _mapper.Map<PagedResults<ProductDTO>>(products);
        }
    }
}

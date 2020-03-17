using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rudy.Services.Interfaces;
using Rudy.Common.Configuration;
using Rudy.Common.Data.Pagination;
using Rudy.DTO;
using System;

namespace Rudy.WebAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IConfigurationManager _configurationManager;

        public ProductController(IProductService productService, IConfigurationManager configurationManager)
        {
            _productService = productService;
            _configurationManager = configurationManager;
        }

        /// <summary>
        /// Get all the products. Default page size: 10 elements
        /// </summary>
        /// <param name="options">The paging options</param>
        /// <returns>A list of products, paged using the specified settings</returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery]PagingOptions options)
        {
            var result = await _productService.GetAll(options);

            return Ok(result);
        }
    }
}

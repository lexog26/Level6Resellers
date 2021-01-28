using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.DataTransferObjects.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Level6Resellers.Api.Controllers
{
    /// <summary>
    /// Products API
    /// </summary>
    [Produces("application/json")]
    [Route("api/products")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProductsController : ControllerBase
    {
        protected readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        #region Read

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <param name="limit">Number of products to return</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(int limit = int.MaxValue)
        {
            var products = await _productService.GetAllAsync(limit);
            return Ok(products);
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Product of the requested id</returns>
        /// <response code="200">Product requested</response>
        /// <response code="404">Product doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product doesn't exist");
            }
            return Ok(product);
        }

        #endregion

        #region Create

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="productInputDto">Product's data</param>
        /// <returns>Product created</returns>
        /// <response code="200">The product was succesfully added</response>
        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] ProductInputDto productInputDto)
        {
            var dto = await _productService.CreateAsync(productInputDto);
            return Ok(dto);
        }

        #endregion
    }
}

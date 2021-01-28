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
    /// Product reseller customer's API
    /// </summary>
    [Produces("application/json")]
    [Route("api/product-reseller-customer")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProductResellerCustomersController : ControllerBase
    {
        protected readonly IProductResellerCustomerService _productResellerCustomerService;

        public ProductResellerCustomersController(IProductResellerCustomerService productResellerCustomerService)
        {
            _productResellerCustomerService = productResellerCustomerService;
        }

        #region Read

        /// <summary>
        /// Returns all product-reseller-customer relations
        /// </summary>
        /// <param name="limit">Number of relations to return</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductResellerCustomerDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(int limit = int.MaxValue)
        {
            var productsResellersCustom = await _productResellerCustomerService.GetAllAsync(limit);
            return Ok(productsResellersCustom);
        }

        #endregion

        #region Create

        /// <summary>
        /// Creates a new product-reseller-customer relation
        /// </summary>
        /// <param name="productResellerCustomerDto">Relation data</param>
        /// <returns>Relation created</returns>
        /// <response code="200">The relation was succesfully added</response>
        /// <response code="400">Once of the relation resources doesn't exist
        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] ProductResellerCustomerInputDto productResellerCustomerDto)
        {
            try
            {
                var dto = await _productResellerCustomerService.CreateAsync(productResellerCustomerDto);
                return Ok(dto);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion
    }
}
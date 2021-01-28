using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.DataTransferObjects.Companies;
using Level6Resellers.DataTransferObjects.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Level6Resellers.Api.Controllers
{
    /// <summary>
    /// Resellers API
    /// </summary>
    [Produces("application/json")]
    [Route("api/resellers")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ResellersController : ControllerBase
    {
        protected readonly IResellerCompanyService _resellerService;
        protected readonly IProductResellerCustomerService _productResellerCustomerService;

        public ResellersController(IResellerCompanyService resellerCompanyService,
                                   IProductResellerCustomerService productResellerCustomerService)
        {
            _resellerService = resellerCompanyService;
            _productResellerCustomerService = productResellerCustomerService;
        }

        #region Read

        /// <summary>
        /// Gets a reseller by id
        /// </summary>
        /// <param name="id">Reseller's id</param>
        /// <returns>Reseller with the requested id</returns>
        /// <response code="200">Returns reseller requested</response>
        /// <response code="404">The requested reseller doesn't exists</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResellerCompanyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var reseller = await _resellerService.GetByIdAsync(id);
            if (reseller == null)
            {
                return NotFound();
            }
            return Ok(reseller);
        }

        /// <summary>
        /// Returns all reseller companies
        /// </summary>
        /// <param name="limit">Number of resellers to return, default all reseller companies</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResellerCompanyDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(int limit = int.MaxValue)
        {
            var resellers = await _resellerService.GetAllAsync(limit);
            return Ok(resellers);
        }

        /// <summary>
        /// Gets reseller's customers guid
        /// </summary>
        /// <param name="id">Reseller id</param>
        /// <returns>Reseller's customers</returns>
        /// <response code="200">Returns all customers for requested reseller company</response>
        /// <response code="404">The requested reseller doesn't exists</response>
        [HttpGet("{id}/customers")]
        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetResellerCustomersByIdAsync([FromRoute] int id)
        {
            try
            {
                IEnumerable<string> customers = await _resellerService.GetResellerCustomersAsync(id);
                return Ok(customers);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Gets reseller's product - customers relations
        /// </summary>
        /// <param name="id">Reseller id</param>
        /// <returns>Reseller's product-customers</returns>
        /// <response code="200">Returns all product-customers for requested reseller company</response>
        [HttpGet("{id}/product-customers")]
        [ProducesResponseType(typeof(IEnumerable<ProductResellerCustomerDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetResellerProductCustomersByIdAsync([FromRoute] int id)
        {
            var productResellerCustomers = await _productResellerCustomerService.GetProductResellerCustomersByResellerIdAsync(id);
            return Ok(productResellerCustomers);
        }

        #endregion

        #region Create

        /// <summary>
        /// Creates a new reseller company
        /// </summary>
        /// <param name="resellerInputDto">Reseller's data</param>
        /// <returns>The reseller info persisted</returns>
        /// <response code="200">The reseller was succesfully added</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResellerCompanyDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] ResellerCompanyInputDto resellerInputDto)
        {
            var dto = await _resellerService.CreateAsync(resellerInputDto);
            return Ok(dto);
        }

        /// <summary>
        /// Creates a new reseller's product-customer relation
        /// </summary>
        /// <param name="id">Reseller id</param>
        /// <param name="productCustomer">Product-customer relation data</param>
        /// <returns>New reseller's product-customer relation</returns>
        /// <response code="200">Product-Customer relation succesfully added</response>
        [HttpPost("{id}/product-customers")]
        [ProducesResponseType(typeof(ProductResellerCustomerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateResellerProductCustomerRelationAsync(
            [FromRoute] int id,
            [FromBody] ProductCustomerDto productCustomer)
        {
            try
            {
                var productResellerCustomer = await _productResellerCustomerService.CreateAsync(
                    new ProductResellerCustomerDto
                    {
                        CustomerId = productCustomer.CustomerId,
                        ProductId = productCustomer.ProductId,
                        ResellerId = id
                    });
                return Ok(productResellerCustomer);
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Adds a customer company to an existing reseller company
        /// </summary>
        /// <param name="id">Reseller id</param>
        /// <param name="customerId">Customer id</param>
        /// <returns>Reseller - Customer data persisted</returns>
        /// <response code="200">The customer was succesfully added to reseller</response>
        /// <response code="404">The requested reseller or custoemr companies doesn't exists</response>
        /// <response code="400">Invalid Guid format</response>
        [HttpPost("{id}/customers")]
        [ProducesResponseType(typeof(ResellerCompanyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCustomerAsync([FromRoute] int id,
            [FromBody] string customerId)
        {
            try
            {
                Guid guid;
                if (Guid.TryParse(customerId, out guid))
                {
                    return Ok(await _resellerService.AddResellerCustomerAsync(id, customerId));
                }
                return BadRequest("Invalid Guid format");
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// Removes a customer from an existing reseller company
        /// </summary>
        /// <param name="id">Reseller id</param>
        /// <param name="customerId">Customer id</param>
        /// <returns>True if the customer was removed from reseller's customers data</returns>
        /// <response code="200">True --> customer succesfully removed</response>
        /// <response code="400">Reseller doesn't contain the customer</response>
        [HttpDelete("{id}/customers/{customerId}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveResellerCustomerAsync([FromRoute] int id, [FromRoute] string customerId)
        {
            try
            {
                return Ok(await _resellerService.RemoveResellerCustomerAsync(id, customerId));
            }
            catch(KeyNotFoundException e)
            {
                return BadRequest("Reseller doesn't contain the customer");
            }
        }

        /// <summary>
        /// Removes a product-customer relation from an existing reseller company
        /// </summary>
        /// <param name="id">Reseller id</param>
        /// <param name="productCustomerId">Product-customer id</param>
        /// <returns>True if the product-customer relation was removed</returns>
        /// <response code="200">True --> customer succesfully removed</response>
        [HttpDelete("{id}/product-customers/{productCustomerid}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveProductCustomerAsync([FromRoute] int id, [FromRoute] int productCustomerId)
        {
            try
            {
                return Ok(await _productResellerCustomerService.DeleteAsync(id));
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
    }
}

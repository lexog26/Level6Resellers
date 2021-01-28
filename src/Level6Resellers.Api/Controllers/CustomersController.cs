using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.DataTransferObjects.Companies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Level6Resellers.Api.Controllers
{
    /// <summary>
    /// Customers API
    /// </summary>
    [Produces("application/json")]
    [Route("api/customers")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CustomersController : ControllerBase
    {
        protected readonly ICustomerCompanyService _customerService;

        public CustomersController(ICustomerCompanyService customerCompanyService)
        {
            _customerService = customerCompanyService;
        }

        #region Read

        /// <summary>
        /// Returns all customer companies
        /// </summary>
        /// <param name="limit">Number of customers to return, default all customer companies</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerCompanyDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(int limit = int.MaxValue)
        {
            var customers = await _customerService.GetAllAsync(limit);
            return Ok(customers);
        }

        /// <summary>
        /// Returns a customer by id
        /// </summary>
        /// <param name="guid">Customer's guid</param>
        /// <returns>Customer of the requested guid</returns>
        /// <response code="200">Returns customer requested</response>
        /// <response code="404">Customer doesn't exist</response>
        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(CustomerCompanyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(string guid)
        {
            var customer = await _customerService.GetByIdAsync(guid);
            if (customer == null)
            {
                return NotFound("Customer doesn't exist");
            }
            return Ok(customer);
        }
        #endregion

        #region Create

        /// <summary>
        /// Creates a new customer company
        /// </summary>
        /// <param name="customerInputDto">Customer's data</param>
        /// <returns>The customer info persisted</returns>
        /// <response code="200">The customer was succesfully added</response>
        [HttpPost]
        [ProducesResponseType(typeof(CustomerCompanyDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerCompanyInputDto customerInputDto)
        {
            var dto = await _customerService.CreateAsync(customerInputDto);
            return Ok(dto);
        }


        #endregion

        #region Update

        /// <summary>
        /// Updates customer company
        /// </summary>
        /// <param name="customerUpdateDto">Update customer's data</param>
        /// <returns>The customer info persisted</returns>
        /// <response code="200">The customer was succesfully updated</response>
        [HttpPut]
        [ProducesResponseType(typeof(CustomerCompanyDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomerCompanyUpdateDto customerUpdateDto)
        {
            var dto = await _customerService.UpdateAsync(customerUpdateDto);
            return Ok(dto);
        }

        #endregion
    }
}

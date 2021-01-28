using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.DataTransferObjects.Companies;
using Level6Resellers.DataTransferObjects.Products;
using Level6Resellers.DataTransferObjects.Purchases;
using Level6Resellers.DataTransferObjects.Users;
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
        protected readonly IUserCustomerService _userService;
        protected readonly IPurchaseService _purchaseService;
        protected readonly IProductResellerCustomerService _productResellerCustomerService;

        public CustomersController(ICustomerCompanyService customerCompanyService,
                                   IUserCustomerService userService,
                                   IPurchaseService purchaseService,
                                   IProductResellerCustomerService productResellerCustomerService)
        {
            _customerService = customerCompanyService;
            _userService = userService;
            _purchaseService = purchaseService;
            _productResellerCustomerService = productResellerCustomerService;
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

        /// <summary>
        /// Returns customer's users
        /// </summary>
        /// <param name="guid">Customer's guid</param>
        /// <returns>Customer's users</returns>
        /// <response code="200">Customer's users</response>
        [HttpGet("{guid}/users")]
        [ProducesResponseType(typeof(IEnumerable<UserCustomerDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsersByIdAsync(string guid)
        {
            var users = await _userService.GetCustomerUsers(guid);
            return Ok(users);
        }

        /// <summary>
        /// Returns customer products
        /// </summary>
        /// <param name="guid">Customer's guid</param>
        /// <returns>Customer's products</returns>
        /// <response code="200">Customer's products</response>
        [HttpGet("{guid}/products")]
        [ProducesResponseType(typeof(IEnumerable<ProductResellerCustomerDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductsByIdAsync(string guid)
        {
            var products = await _productResellerCustomerService.GetProductResellerCustomersByCustomerIdAsync(guid);
            return Ok(products);
        }

        /// <summary>
        /// Returns customer's purchases
        /// </summary>
        /// <param name="guid">Customer's guid</param>
        /// <param name="since">Purchases made by the customer after this date</param>
        /// <returns>Customer's purchases</returns>
        /// <response code="200">Customer's purchases</response>
        [HttpGet("{guid}/purchases")]
        [ProducesResponseType(typeof(IEnumerable<PurchaseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomerPurchasesByIdAsync([FromRoute]string guid, [FromQuery] DateTime? since)
        {
            var purchases = await _purchaseService.GetCustomerPurchasesAsync(guid, since);
            return Ok(purchases);
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

        /// <summary>
        /// Creates a new user customer
        /// </summary>
        /// <param name="userInputDto">User's data</param>
        /// <returns>The user info persisted</returns>
        /// <response code="200">The user was succesfully added</response>
        [HttpPost("{guid}/users")]
        [ProducesResponseType(typeof(UserCustomerDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserCustomerInputDto userInputDto)
        {
            var dto = await _userService.CreateAsync(userInputDto);
            return Ok(dto);
        }

        /// <summary>
        /// Makes a new customer purchase
        /// </summary>
        /// <param name="purchaseDto">Purchase data</param>
        /// <returns>Purchase data persisted</returns>
        /// <response code="200">Purchase succesfully added</response>
        [HttpPost("{guid}/purchases")]
        [ProducesResponseType(typeof(PurchaseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> MakeCustomerPurchaseAsync([FromBody] PurchaseCreateDto purchaseDto)
        {
            var dto = await _purchaseService.CreateAsync(purchaseDto);
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

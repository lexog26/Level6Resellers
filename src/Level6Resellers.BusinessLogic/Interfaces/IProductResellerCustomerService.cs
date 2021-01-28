using Level6Resellers.DataTransferObjects.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Level6Resellers.BusinessLogic.Interfaces
{
    public interface IProductResellerCustomerService : ITransactionalService<ProductResellerCustomerDto, 
                                                                             ProductResellerCustomerInputDto,
                                                                             int>
    {
        Task<ProductResellerCustomerDto> CreateAsync(ProductResellerCustomerDto dto);

        Task<IEnumerable<ProductResellerCustomerDto>> GetProductResellerCustomersByResellerIdAsync(int resellerId);

        Task<IEnumerable<ProductResellerCustomerDto>> GetProductResellerCustomersByCustomerIdAsync(string customerId);

        Task<ProductResellerCustomerDto> GetProductResellerCustomerAsync(int resellerId, string customerId, int productId);
    }
}

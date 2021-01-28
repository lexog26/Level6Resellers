using Level6Resellers.DataTransferObjects.Companies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Level6Resellers.BusinessLogic.Interfaces
{
    public interface IResellerCustomerService : ITransactionalService<ResellerCustomerDto, ResellerCustomerInputDto, int>
    {
        Task<IEnumerable<string>> GetResellerCustomerIdsAsync(int resellerId);

        Task<IEnumerable<int>> GetCustomerResellerIdsAsync(string customerId);

        Task<ResellerCustomerDto> GetByResellerCustomerAsync(ResellerCustomerInputDto dto);

        Task<ResellerCustomerDto> GetByResellerCustomerAsync(int resellerId, string customerGuid);

        Task<ResellerCustomerDto> DeleteAsync(ResellerCustomerDto resellerCustomerDto);
    }
}

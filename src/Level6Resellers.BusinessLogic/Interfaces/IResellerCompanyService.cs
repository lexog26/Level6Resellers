using Level6Resellers.DataTransferObjects.Companies;
using Level6Resellers.DataTransferObjects.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Level6Resellers.BusinessLogic.Interfaces
{
    public interface IResellerCompanyService : ITransactionalService<ResellerCompanyDto, ResellerCompanyInputDto, int>
    {
        Task<IEnumerable<string>> GetResellerCustomersAsync(int id);

        Task<ResellerCompanyDto> AddResellerCustomerAsync(int id, string guid);

        Task<bool> RemoveResellerCustomerAsync(int id, string guid);

    }
}

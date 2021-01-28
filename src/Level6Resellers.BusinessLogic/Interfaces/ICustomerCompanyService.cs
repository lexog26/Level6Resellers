using Level6Resellers.DataTransferObjects.Companies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Level6Resellers.BusinessLogic.Interfaces
{
    public interface ICustomerCompanyService : ITransactionalService<CustomerCompanyDto, CustomerCompanyInputDto, string>
    {
        Task<bool> ExistCustomerAsync(string guid);

        Task<CustomerCompanyDto> UpdateAsync(CustomerCompanyUpdateDto dto);
    }
}

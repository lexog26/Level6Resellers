using Level6Resellers.DataTransferObjects.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Level6Resellers.BusinessLogic.Interfaces
{
    public interface IUserCustomerService : ITransactionalService<UserCustomerDto, UserCustomerInputDto, int>
    {
        Task<IEnumerable<UserCustomerDto>> GetCustomerUsers(string guid);
    }
}

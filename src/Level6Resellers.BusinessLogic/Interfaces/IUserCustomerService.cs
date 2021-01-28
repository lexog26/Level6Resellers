using Level6Resellers.DataTransferObjects.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.BusinessLogic.Interfaces
{
    public interface IUserCustomerService : ITransactionalService<UserCustomerDto, UserCustomerInputDto, int>
    {
    }
}

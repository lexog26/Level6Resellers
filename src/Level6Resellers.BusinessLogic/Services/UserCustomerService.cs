using AutoMapper;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.DataLayer.Repository.Interface;
using Level6Resellers.DataLayer.UnitOfWork.Interface;
using Level6Resellers.DataTransferObjects.Users;
using Level6Resellers.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Level6Resellers.BusinessLogic.Services
{
    public class UserCustomerService : TransactionalService<UserCustomerDto,
                                                       UserCustomerInputDto,
                                                       UserCustomer,
                                                       int>, IUserCustomerService
    {
        public UserCustomerService(IRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, repository)
        { }

        public async Task<IEnumerable<UserCustomerDto>> GetCustomerUsers(string guid)
        {
            return _mapper.Map<IEnumerable<UserCustomerDto>>(
                await _repository.GetByFilterAsync<UserCustomer>(
                    filter: x => x.CustomerCompanyId == guid
                    )
                );
        }
    }
}

using AutoMapper;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.DataLayer.Repository.Interface;
using Level6Resellers.DataLayer.UnitOfWork.Interface;
using Level6Resellers.DataTransferObjects.Companies;
using Level6Resellers.Domain.Companies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Level6Resellers.BusinessLogic.Services
{
    public class CustomerCompanyService : TransactionalService<CustomerCompanyDto,
                                                               CustomerCompanyInputDto,
                                                               CustomerCompany,
                                                               string>, ICustomerCompanyService
    {
        public CustomerCompanyService(IRepository repository, IMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork, repository)
        { }

        public async Task<bool> ExistCustomerAsync(string guid)
        {
            return await _repository.GetExistsAsync<CustomerCompany>(x => x.Id == guid);
        }

        public async Task<CustomerCompanyDto> UpdateAsync(CustomerCompanyUpdateDto dto)
        {
            var customer = await _repository.GetEntityByIdAsync<CustomerCompany, string>(dto.Id);
            customer.Name = dto.Name;
            customer.ModifiedDate = DateTime.UtcNow;
            _repository.Update(customer);
            await SaveChangesAsync();
            return _mapper.Map<CustomerCompanyDto>(customer);
        }
    }
}

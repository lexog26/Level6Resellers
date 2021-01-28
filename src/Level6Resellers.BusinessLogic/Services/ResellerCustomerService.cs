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
    public class ResellerCustomerService : TransactionalService<ResellerCustomerDto,
                                                                ResellerCustomerInputDto,
                                                                ResellerCustomer,
                                                                int>, IResellerCustomerService
    {
        public ResellerCustomerService(IRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, repository)
        { }

        public async Task<ResellerCustomerDto> DeleteAsync(ResellerCustomerDto resellerCustomerDto)
        {
            var resellerCustomer = await GetEntityByResellerCustomerIdAsync(resellerCustomerDto.ResellerCompanyId,
                                                                            resellerCustomerDto.CustomerCompanyId);
            return resellerCustomer != null ? await base.DeleteAsync(resellerCustomer.Id) : throw new KeyNotFoundException();
        }

        public async Task<ResellerCustomerDto> GetByResellerCustomerAsync(ResellerCustomerInputDto dto)
        {
            return await GetByResellerCustomerAsync(dto.ResellerCompanyId, dto.CustomerCompanyId);
        }

        public async Task<ResellerCustomerDto> GetByResellerCustomerAsync(int resellerId, string customerGuid)
        {
            return _mapper.Map<ResellerCustomerDto>(await GetEntityByResellerCustomerIdAsync(resellerId, customerGuid));

        }

        public async Task<IEnumerable<int>> GetCustomerResellerIdsAsync(string customerId)
        {
            return await _repository.GetByFilterAsync<ResellerCustomer, int>
            (
                filter: x => x.CustomerCompanyId == customerId,
                selector: x => x.ResellerCompanyId
            );
        }

        public async Task<IEnumerable<string>> GetResellerCustomerIdsAsync(int resellerId)
        {
            return await _repository.GetByFilterAsync<ResellerCustomer, string>
            (
                filter: x => x.ResellerCompanyId == resellerId,
                selector: x => x.CustomerCompanyId
            );
        }

        protected async Task<ResellerCustomer> GetEntityByResellerCustomerIdAsync(int resellerId, string customerGuid)
        {
            return await _repository.GetFirstOrDefaultAsync<ResellerCustomer>(
                filter: x => x.CustomerCompanyId == customerGuid &&
                             x.ResellerCompanyId == resellerId);
        }
    }
}

using AutoMapper;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.DataLayer.Repository.Interface;
using Level6Resellers.DataLayer.UnitOfWork.Interface;
using Level6Resellers.DataTransferObjects.Companies;
using Level6Resellers.Domain.Companies;
using Level6Resellers.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level6Resellers.BusinessLogic.Services
{
    public class ResellerCompanyService : TransactionalService<ResellerCompanyDto,
                                                               ResellerCompanyInputDto,
                                                               ResellerCompany,
                                                               int>, IResellerCompanyService
    {
        private readonly IResellerCustomerService _resellerCustomerService;
        public ResellerCompanyService(IResellerCustomerService resellerCustomerService,
                                      IRepository repository, 
                                      IMapper mapper,
                                      IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, repository)
        {
            _resellerCustomerService = resellerCustomerService;
        }

        /// <summary>
        /// Adds a new customer to reseller
        /// </summary>
        /// <param name="id"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public async Task<ResellerCompanyDto> AddResellerCustomerAsync(int id, string guid)
        {
            await _resellerCustomerService.CreateAsync(
                new ResellerCustomerInputDto 
                { 
                    CustomerCompanyId = guid,
                    ResellerCompanyId = id
                });
            return await GetByIdAsync(id);
        }

        public override async Task<IEnumerable<ResellerCompanyDto>> GetAllAsync(int limit = int.MaxValue)
        {
            var resellers = await base.GetAllAsync(limit);
            foreach (var reseller in resellers)
            {
                reseller.CustomerIds = await GetResellerCustomersAsync(reseller.Id);
            }
            return resellers;
        }

        public override async Task<ResellerCompanyDto> GetByIdAsync(int id)
        {
            var reseller = await base.GetByIdAsync(id);
            if (reseller != null)
            {
                reseller.CustomerIds = await _repository.GetByFilterAsync<ResellerCustomer, string>(
                    filter: x => x.ResellerCompanyId == id,
                    selector: x => x.CustomerCompanyId
                    );
                reseller.ProductIds = await _repository.GetByFilterAsync<ProductResellerCustomer, int>(
                    filter: x => x.ResellerId == id,
                    selector: x => x.ProductId
                    );
                return reseller;
            }
            throw new KeyNotFoundException($"Invalid id:{id} value");
        }

        public async Task<IEnumerable<string>> GetResellerCustomersAsync(int id)
        {
            return await _resellerCustomerService.GetResellerCustomerIdsAsync(id);
        }

        public async Task<bool> RemoveResellerCustomerAsync(int id, string guid)
        {
            await _resellerCustomerService.DeleteAsync(
                 new ResellerCustomerDto
                 {
                     CustomerCompanyId = guid,
                     ResellerCompanyId = id
                 });
            return true;
        }
    }
}

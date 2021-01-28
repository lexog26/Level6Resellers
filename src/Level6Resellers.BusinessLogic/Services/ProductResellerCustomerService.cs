using AutoMapper;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.DataTransferObjects.Products;
using Level6Resellers.Domain.Products;
using Level6Resellers.DataLayer.UnitOfWork.Interface;
using Level6Resellers.DataLayer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Level6Resellers.DataTransferObjects.Companies;

namespace Level6Resellers.BusinessLogic.Services
{
    public class ProductResellerCustomerService : TransactionalService<ProductResellerCustomerDto,
                                                                       ProductResellerCustomerInputDto,
                                                                       ProductResellerCustomer,
                                                                       int>, IProductResellerCustomerService
    {
        IResellerCustomerService _resellerCustomerService;
        public ProductResellerCustomerService(IResellerCustomerService resellerCustomerService,
                                              IRepository repository,
                                              IMapper mapper,
                                              IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, repository)
        {
            _resellerCustomerService = resellerCustomerService;
        }

        public async Task<IEnumerable<ProductResellerCustomerDto>> GetProductResellerCustomersByCustomerIdAsync(string customerId)
        {
            return await GetDtosByFilter(x => x.CustomerId == customerId);
        }

        public async Task<IEnumerable<ProductResellerCustomerDto>> GetProductResellerCustomersByResellerIdAsync(int resellerId)
        {
            return await GetDtosByFilter(x => x.ResellerId == resellerId);
        }

        public override async Task<ProductResellerCustomerDto> CreateAsync(ProductResellerCustomerInputDto dto)
        {
            var resellerCustomer = await _resellerCustomerService.GetByResellerCustomerAsync(dto.ResellerId, dto.CustomerId);
            if (resellerCustomer != null)
            {
                if (dto.ResellerCustomerId != resellerCustomer.Id)
                    throw new ArgumentException("Invalid reseller-customer id param");
                return await base.CreateAsync(dto);
            }
            throw new KeyNotFoundException("Relation reseller-customer doesn't exist");
        }

        public async Task<ProductResellerCustomerDto> CreateAsync(ProductResellerCustomerDto dto)
        {
            var resellerCustomer = await GetResellerCustomerAsync(dto.ResellerId, dto.CustomerId);
            if (resellerCustomer != null)
            {
                if ((await _repository.GetCountAsync<ProductResellerCustomer>(x => x.ProductId == dto.ProductId &&
                                                                             x.ResellerCustomerId == resellerCustomer.Id)) == 0)
                {
                    return await base.CreateAsync(new ProductResellerCustomerInputDto
                    {
                        CustomerId = dto.CustomerId,
                        ProductId = dto.ProductId,
                        ResellerId = dto.ResellerId,
                        ResellerCustomerId = resellerCustomer.Id
                    });
                }
                throw new Exception("Relation product-customer already exists");
            }
            throw new KeyNotFoundException("Relation reseller-customer doesn't exist");
        }

        public async Task<ProductResellerCustomerDto> GetProductResellerCustomerAsync(int resellerId, string customerId, int productId)
        {
            return _mapper.Map<ProductResellerCustomerDto>(
                await _repository.GetFirstOrDefaultAsync<ProductResellerCustomer>(
                    filter: x => x.CustomerId == customerId && x.ResellerId == resellerId && x.ProductId == productId
                ));
        }

        protected async Task<IEnumerable<ProductResellerCustomerDto>> GetDtosByFilter(Expression<Func<ProductResellerCustomer, bool>> filter)
        {
            return _mapper.Map<IEnumerable<ProductResellerCustomerDto>>(
                await _repository.GetByFilterAsync(filter: filter)
                );
        }

        protected async Task<ResellerCustomerDto> GetResellerCustomerAsync(int resellerId, string customerId)
        {
            return await _resellerCustomerService.GetByResellerCustomerAsync(resellerId, customerId);
        }

        
    }
}

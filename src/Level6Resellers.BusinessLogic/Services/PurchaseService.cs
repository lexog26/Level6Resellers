using AutoMapper;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.DataLayer.Repository.Interface;
using Level6Resellers.DataLayer.UnitOfWork.Interface;
using Level6Resellers.DataTransferObjects.Purchases;
using Level6Resellers.Domain.Purchases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Level6Resellers.BusinessLogic.Services
{
    public class PurchaseService : TransactionalService<PurchaseDto,
                                                        PurchaseInputDto,
                                                        Purchase,
                                                        int>, IPurchaseService
    {
        IProductResellerCustomerService _productResellerCustomerService;
        public PurchaseService(IProductResellerCustomerService productResellerCustomerService,
                               IRepository repository,
                               IMapper mapper,
                               IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, repository)
        {
            _productResellerCustomerService = productResellerCustomerService;
        }

        public async Task<IEnumerable<PurchaseDto>> GetCustomerPurchasesAsync(string customerGuid, DateTime? since)
        {
            var date = since.HasValue ? since.Value : DateTime.MinValue;
            return _mapper.Map<IEnumerable<PurchaseDto>>(
                await _repository.GetByFilterAsync<Purchase>(
                        filter: x => x.CustomerId == customerGuid && x.CreatedDate > date
                    )
            );
        }

        public override async Task<PurchaseDto> CreateAsync(PurchaseInputDto dto)
        {
            var prc = await _productResellerCustomerService.GetProductResellerCustomerAsync(dto.ResellerId, dto.CustomerId, dto.ProductId);
            if (prc != null)
            {
                if (prc.Id != dto.ProductResellerCustomerId)
                    throw new Exception("Product-customer-reseller relation doesn't exist");
                return await base.CreateAsync(dto);
            }
            throw new Exception("Product-customer-reseller relation doesn't exist");
        }

        public async Task<PurchaseDto> CreateAsync(PurchaseCreateDto dto)
        {
            var prc = await _productResellerCustomerService.GetProductResellerCustomerAsync(dto.ResellerId, dto.CustomerId, dto.ProductId);
            if (prc != null)
            {
                var purchase = new Purchase
                {
                    ProductId = dto.ProductId,
                    CustomerId = dto.CustomerId,
                    ResellerId = dto.ResellerId,
                    UserCustomerId = dto.UserCustomerId,
                    ProductResellerCustomerId = prc.Id
                };
                _repository.Create<Purchase, int>(purchase);
                await SaveChangesAsync();
                return _mapper.Map<PurchaseDto>(purchase);
            }
            throw new Exception("Product-customer-reseller relation doesn't exist");
        }
    }
}

using Level6Resellers.DataTransferObjects.Purchases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Level6Resellers.BusinessLogic.Interfaces
{
    public interface IPurchaseService : ITransactionalService<PurchaseDto, PurchaseInputDto, int>
    {
        Task<IEnumerable<PurchaseDto>> GetCustomerPurchasesAsync(string customerGuid, DateTime? since);

        Task<PurchaseDto> CreateAsync(PurchaseCreateDto dto);
    }
}

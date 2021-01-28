using Level6Resellers.DataTransferObjects.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.BusinessLogic.Interfaces
{
    public interface IProductService : ITransactionalService<ProductDto, ProductInputDto, int>
    {

    }
}

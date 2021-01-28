using AutoMapper;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.DataLayer.Repository.Interface;
using Level6Resellers.DataLayer.UnitOfWork.Interface;
using Level6Resellers.DataTransferObjects.Products;
using Level6Resellers.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.BusinessLogic.Services
{
    public class ProductService : TransactionalService<ProductDto,
                                                       ProductInputDto,
                                                       Product,
                                                       int>, IProductService
    {
        public ProductService(IRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, repository)
        { }
    }
}

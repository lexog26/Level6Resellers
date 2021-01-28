using AutoMapper;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.DataLayer.Repository.Interface;

namespace Level6Resellers.BusinessLogic.Services
{
    public abstract class ServiceBase : IServiceBase 
    {
        protected readonly IMapper _mapper;
        protected readonly IRepository _repository;

        public ServiceBase(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
    }
}

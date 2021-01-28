using AutoMapper;
using Level6Resellers.BusinessLogic.Interfaces;
using Level6Resellers.DataLayer.Repository.Interface;
using Level6Resellers.DataLayer.UnitOfWork.Interface;
using Level6Resellers.DataTransferObjects;
using Level6Resellers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Level6Resellers.BusinessLogic.Services
{
    /// <summary>
    /// Groups all services with data persistances features based on Unit of Work design pattern
    /// </summary>
    public abstract class TransactionalService<TDto, TInputDto, TEntity, TKey> : ServiceBase, 
                                                                                ITransactionalService<TDto, TInputDto, TKey>
        where TDto : BaseDto<TKey>
        where TInputDto : InputDto
        where TEntity : Entity<TKey>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionalService(IMapper mapper, IUnitOfWork unitOfWork, IRepository repository)
                                   : base(repository, mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<TDto> CreateAsync(TInputDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _repository.Create<TEntity, TKey>(entity);
            await SaveChangesAsync();
            var outputDto = _mapper.Map<TDto>(entity);
            return outputDto;
        }

        public virtual async Task<TDto> DeleteAsync(TKey id)
        {
            var entity = _repository.Delete<TEntity, TKey>(id);
            await SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync(int limit = int.MaxValue)
        {
            return _mapper.Map<IEnumerable<TDto>>(await _repository.GetAllAsync<TEntity>(take: limit));
        }

        public virtual async Task<TDto> GetByIdAsync(TKey id)
        {
            var entity = await _repository.GetEntityByIdAsync<TEntity, TKey>(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.ModifiedDate = DateTime.UtcNow;
            _repository.Update(entity);
            await SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }
    }
}

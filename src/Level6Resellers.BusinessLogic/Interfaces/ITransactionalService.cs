using Level6Resellers.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Level6Resellers.BusinessLogic.Interfaces
{
    /// <summary>
    /// Services that persists data with a transactional flow
    /// </summary>
    public interface ITransactionalService<TDto, TInputDto, TKey> : IServiceBase 
        where TDto : BaseDto<TKey>
        where TInputDto : InputDto
    {
        Task<TDto> CreateAsync(TInputDto dto);

        Task<TDto> DeleteAsync(TKey id);

        Task<TDto> UpdateAsync(TDto dto);

        Task<IEnumerable<TDto>> GetAllAsync(int limit = int.MaxValue);

        Task<TDto> GetByIdAsync(TKey id);

        void SaveChanges();

        Task SaveChangesAsync();
    }
}

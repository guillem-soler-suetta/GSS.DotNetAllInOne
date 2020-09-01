using GSS.DotNetAllInOne.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSS.DotNetAllInOne.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity, TKey>
        where TEntity : AggregateRoot<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> ListAsync();
        Task<IEnumerable<TEntity>> GetPagedReponseAsync(int pageNumber, int pageSize);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
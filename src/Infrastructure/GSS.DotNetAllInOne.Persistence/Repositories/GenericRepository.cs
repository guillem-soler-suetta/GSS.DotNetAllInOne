using GSS.DotNetAllInOne.Domain.Entities;
using GSS.DotNetAllInOne.Domain.Interfaces.Repositories;
using GSS.DotNetAllInOne.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSS.DotNetAllInOne.Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : AggregateRoot<TKey>
    {
        protected readonly ExamplesDbContext _dbContext;

        public GenericRepository(ExamplesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<TEntity>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await _dbContext
                 .Set<TEntity>()
                 .AsNoTracking()
                 .ToListAsync();
        }
    }

}

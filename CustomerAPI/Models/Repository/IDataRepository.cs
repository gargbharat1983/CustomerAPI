using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(long id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity dbEntity, TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}

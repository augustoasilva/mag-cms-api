using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CmsApi.Data;
using CmsApi.Models;

namespace CmsApi.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByCompositeIdAsync(int id1, int id2);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        public DataContext GetDataContext();
    }
}
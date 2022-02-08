using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CmsApi.Models;

namespace CmsApi.Repositories.Interfaces
{
    public interface IUserRepository<TUser> where TUser : User
    {
        Task<IEnumerable<TUser>> GetAsync(Expression<Func<TUser, bool>>? filter = null);
        Task<TUser> GetByIdAsync(int id);
        Task<bool> AddAsync(TUser entity);
        Task<bool> UpdateAsync(TUser entity);
    }
}
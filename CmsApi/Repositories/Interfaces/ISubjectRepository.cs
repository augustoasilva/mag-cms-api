using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CmsApi.Models;

namespace CmsApi.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAsync(Expression<Func<Subject, bool>>? filter = null);
        Task<Subject> GetByIdAsync(int id);
        Task<bool> AddAsync(Subject entity);
        Task<bool> UpdateAsync(Subject entity);
        Task<bool> DeleteAsync(Subject entity);
    }
}
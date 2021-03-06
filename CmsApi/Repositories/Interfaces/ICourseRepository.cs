using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CmsApi.Models;

namespace CmsApi.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAsync(Expression<Func<Course, bool>>? filter = null);
        Task<Course> GetByIdAsync(int id);
        Task<bool> AddAsync(Course entity);
        Task<bool> UpdateAsync(Course entity);
        Task<bool> DeleteAsync(Course entity);
    }
}
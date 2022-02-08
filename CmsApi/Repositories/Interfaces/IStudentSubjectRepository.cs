using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CmsApi.Models;

namespace CmsApi.Repositories.Interfaces
{
    public interface IStudentSubjectRepository
    {
        Task<IEnumerable<StudentSubject>> GetAsync(Expression<Func<StudentSubject, bool>>? filter = null);
        Task<StudentSubject> GetByIdAsync(int id1, int id2);
        Task<bool> AddAsync(StudentSubject entity);
        Task<bool> UpdateAsync(StudentSubject entity);
        Task<bool> DeleteAsync(StudentSubject entity);
    }
}
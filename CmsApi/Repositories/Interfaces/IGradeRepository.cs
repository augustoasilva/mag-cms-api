using System.Linq.Expressions;
using CmsApi.Models;

namespace CmsApi.Repositories.Interfaces;

public interface IGradeRepository
{
    Task<IEnumerable<Grade>> GetAsync(Expression<Func<Grade, bool>>? filter = null);
    Task<Grade> GetByIdAsync(int id);
    
    Task<IEnumerable<Grade>> GetGradeByStudentIdAndSubjectIdAsync(int id1, int id2);
    Task<bool> AddAsync(Grade entity);
    Task<bool> UpdateAsync(Grade entity);
    Task<bool> DeleteAsync(Grade entity);
}
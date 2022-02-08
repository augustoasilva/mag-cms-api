using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CmsApi.Models;
using CmsApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CmsApi.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly IRepository<Grade> _repository;

        public GradeRepository(IRepository<Grade> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Grade>> GetAsync(Expression<Func<Grade, bool>>? filter = null)
        {
            var dataContext = _repository.GetDataContext();
            var dbSet = dataContext.Set<Grade>();

            var query = dbSet.AsQueryable();

            if (filter != null)
            {
                query = query
                    .Where(filter)
                    .Include(g => g.Subject)
                    .ThenInclude(s => s.Course)
                    .Include(g => g.Student)
                    .AsNoTracking();
            }
            else
            {
                query = query
                    .Include(g => g.Subject)
                    .ThenInclude(s => s.Course)
                    .Include(g => g.Student)
                    .AsNoTracking();
            }


            return await query.ToListAsync();
        }

        public async Task<Grade> GetByIdAsync(int id)
        {
            var dataContext = _repository.GetDataContext();
            var dbSet = dataContext.Set<Grade>();

            var query = dbSet.AsQueryable();

            query = query
                .Where(g => g.Id == id)
                .Include(g => g.Subject)
                .ThenInclude(s => s.Course)
                .Include(g => g.Student)
                .AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Grade>> GetGradeByStudentIdAndSubjectIdAsync(int studentId, int subjectId)
        {
            var dataContext = _repository.GetDataContext();
            var dbSet = dataContext.Set<Grade>();

            var query = dbSet.AsQueryable();

            query = query
                .Where(g => g.StudentId == studentId)
                .Where(g => g.SubjectId == subjectId)
                .Include(g => g.Subject)
                .ThenInclude(s => s.Course)
                .Include(g => g.Student)
                .AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<bool> AddAsync(Grade subjectGrade)
        {
            try
            {
                await _repository.AddAsync(subjectGrade);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Grade subjectGrade)
        {
            try
            {
                await _repository.UpdateAsync(subjectGrade);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Grade subjectGrade)
        {
            try
            {
                await _repository.DeleteAsync(subjectGrade);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
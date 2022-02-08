using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CmsApi.Models;
using CmsApi.Repositories.Interfaces;

namespace CmsApi.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IRepository<Teacher> _repository;

        public TeacherRepository(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Teacher>> GetAsync(Expression<Func<Teacher, bool>>? filter = null)
        {
            var dataContext = _repository.GetDataContext();
            var dbSet = dataContext.Set<Teacher>();

            var query = dbSet.AsQueryable();

            if (filter != null)
            {
                query = query
                    .Where(filter)
                    .Include(t => t.Subjects)
                    .ThenInclude(s => s.Course)
                    .Include(t => t.Subjects)
                    .ThenInclude(s => s.Students)
                    .AsNoTracking();
            }
            else
            {
                query = query
                    .Include<Teacher, Subject>(t => t.Subjects)
                    .ThenInclude(s => s.Course)
                    .Include(t => t.Subjects)
                    .ThenInclude(s => s.Students)
                    .AsNoTracking();
            }


            return await query.ToListAsync();
    }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var dataContext = _repository.GetDataContext();
            var dbSet = dataContext.Set<Teacher>();

            var query = dbSet.AsQueryable();

            query = query
                .Where(t => t.Id == id)
                .Include(t => t.Subjects)
                .ThenInclude(s => s.Course)
                .Include(t => t.Subjects)
                .ThenInclude(s => s.Students)
                .AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> AddAsync(Teacher teacher)
        {
            try
            {
                await _repository.AddAsync(teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateAsync(Teacher teacher)
        {
            try
            {
                await _repository.UpdateAsync(teacher);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
    }
}
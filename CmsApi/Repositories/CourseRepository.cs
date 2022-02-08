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
    public class CourseRepository : ICourseRepository
    {
        private readonly IRepository<Course> _repository;

        public CourseRepository(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Course>> GetAsync(Expression<Func<Course, bool>>? filter = null)
        {
            var dataContext = _repository.GetDataContext();
            var dbSet = dataContext.Set<Course>();

            var query = dbSet.AsQueryable();

            if (filter != null)
            {
                query = query
                    .Where(filter)
                    .Include(c => c.Subjects)
                    .ThenInclude(s => s.Teacher)
                    .Include(c => c.Subjects)
                    .ThenInclude(s => s.Students)
                    .ThenInclude(ss => ss.Student)
                    .AsNoTracking();
            }
            else
            {
                query = query
                    .Include(c => c.Subjects)
                    .ThenInclude(s => s.Teacher)
                    .Include(c => c.Subjects)
                    .ThenInclude(s => s.Students)
                    .ThenInclude(ss => ss.Student)
                    .AsNoTracking();
            }


            return await query.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var dataContext = _repository.GetDataContext();
            var dbSet = dataContext.Set<Course>();

            var query = dbSet.AsQueryable();

            query = query
                .Where(c => c.Id == id)
                .Include(c => c.Subjects)
                .ThenInclude(s => s.Teacher)
                .Include(c => c.Subjects)
                .ThenInclude(s => s.Students)
                .ThenInclude(ss => ss.Student)
                .AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> AddAsync(Course course)
        {
            try
            {
                await _repository.AddAsync(course);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            try
            {
                await _repository.UpdateAsync(course);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Course course)
        {
            try
            {
                await _repository.DeleteAsync(course);
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
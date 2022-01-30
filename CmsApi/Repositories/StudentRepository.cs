using System.Linq.Expressions;
using CmsApi.Models;
using CmsApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CmsApi.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IRepository<Student> _repository;

    public StudentRepository(IRepository<Student> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Student>> GetAsync(Expression<Func<Student, bool>>? filter = null)
    {
        var dataContext = _repository.GetDataContext();
        var dbSet =  dataContext.Set<Student>();
        
        var query = dbSet.AsQueryable();

        if (filter != null)
        {
            query = query
                .Where(filter)
                .Include(s => s.Subjects)
                .ThenInclude(ss => ss.Subject)
                .ThenInclude(s => s.Teacher)
                .Include(s => s.Grades)
                .ThenInclude(sg => sg.Subject)
                .AsNoTracking();
        }
        else
        {
            query = query
                .Include(s => s.Subjects)
                .ThenInclude(ss => ss.Subject)
                .ThenInclude(s => s.Teacher)
                .Include(s => s.Grades)
                .ThenInclude(sg => sg.Subject)
                .AsNoTracking();
        }
            

        return await query.ToListAsync();
    }

    public async Task<Student> GetByIdAsync(int id)
    {
        var dataContext = _repository.GetDataContext();
        var dbSet =  dataContext.Set<Student>();
        
        var query = dbSet.AsQueryable();

        query = query
                .Where(s => s.Id == id)
                .Include(s => s.Subjects)
                .ThenInclude(ss => ss.Subject)
                .ThenInclude(s => s.Teacher)
                .Include(s => s.Grades)
                .ThenInclude(sg => sg.Subject)
                .AsNoTracking();

        return await query.FirstOrDefaultAsync();
    }

    public async Task<bool> AddAsync(Student student)
    {
        try
        {
            await _repository.AddAsync(student);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> UpdateAsync(Student student)
    {
        try
        {
            await _repository.UpdateAsync(student);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}
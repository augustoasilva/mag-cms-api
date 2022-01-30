using System.Linq.Expressions;
using CmsApi.Models;
using CmsApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CmsApi.Repositories;

public class SubjectRepository : ISubjectRepository
{
    private readonly IRepository<Subject> _repository;

    public SubjectRepository(IRepository<Subject> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Subject>> GetAsync(Expression<Func<Subject, bool>>? filter = null)
    {
        var dataContext = _repository.GetDataContext();
        var dbSet = dataContext.Set<Subject>();

        var query = dbSet.AsQueryable();

        if (filter != null)
        {
            query = query
                .Where(filter)
                .Include(s => s.Course)
                .Include(s => s.Teacher)
                .Include(s => s.Students)
                .ThenInclude(ss => ss.Student)
                .AsNoTracking();
        }
        else
        {
            query = query
                .Include(s => s.Course)
                .Include(s => s.Teacher)
                .Include(s => s.Students)
                .ThenInclude(ss => ss.Student)
                .AsNoTracking();
        }

        return await query.ToListAsync();
    }

    public async Task<Subject> GetByIdAsync(int id)
    {
        var dataContext = _repository.GetDataContext();
        var dbSet =  dataContext.Set<Subject>();
        
        var query = dbSet.AsQueryable();

        query = query
            .Where(s => s.Id == id)
            .Include(s => s.Course)
            .Include(s => s.Teacher)
            .Include(s => s.Students)
            .ThenInclude(ss => ss.Student)
            .AsNoTracking();

        return await query.FirstOrDefaultAsync();
    }

    public async Task<bool> AddAsync(Subject subject)
    {
        try
        {
            await _repository.AddAsync(subject);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> UpdateAsync(Subject subject)
    {
        try
        {
            await _repository.UpdateAsync(subject);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Subject subject)
    {
        try
        {
            await _repository.DeleteAsync(subject);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}
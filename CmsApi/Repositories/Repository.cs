using System.Linq.Expressions;
using CmsApi.Data;
using CmsApi.Models;
using CmsApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CmsApi.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    public readonly DbSet<TEntity> _DbSet;
    public readonly DataContext _DataContext;

    public Repository(DataContext dataContext)
    {
        _DbSet = dataContext.Set<TEntity>();
        _DataContext = dataContext;
    }

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        var query = _DbSet.AsQueryable();

        if (filter != null)
            query = query
                .Where(filter)
                .AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _DbSet.FindAsync(id);
    }
    
    public async Task<TEntity> GetByCompositeIdAsync(int id1, int id2)
    {
        return await _DbSet.FindAsync(id1, id2);
    }

    public async Task<bool> AddAsync(TEntity entity)
    {
        try
        {
            await _DbSet.AddAsync(entity);
            await _DataContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        try
        {
            _DbSet.Remove(entity);
            await _DataContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        try
        {
            _DbSet.Update(entity);
            await _DataContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public DataContext GetDataContext()
    {
        return _DataContext;
       // return dataContext;
    }
}
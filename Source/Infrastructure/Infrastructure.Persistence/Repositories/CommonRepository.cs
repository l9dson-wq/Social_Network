using System.Diagnostics;
using Core.Application;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class CommonRepository<Entity> : ICommonRepository<Entity> where Entity : class
{
  private readonly ApplicationContext _dbContext;

  public CommonRepository(ApplicationContext dbContext)
  {
    _dbContext = dbContext;
  }

  public virtual async Task<Entity> AddAsync(Entity entity)
  {
    await _dbContext.Set<Entity>().AddAsync(entity);
    await _dbContext.SaveChangesAsync();
    return entity;
  }

  public virtual async Task UpdateAsync(Entity entity, int id)
  {
    Entity? entry = await _dbContext.Set<Entity>().FindAsync(id);
    _dbContext.Entry(entry).CurrentValues.SetValues(entity);
    await _dbContext.SaveChangesAsync();
  }

  public virtual async Task DeleteAsync(Entity entity)
  {
    _dbContext.Set<Entity>().Remove(entity);
    await _dbContext.SaveChangesAsync();
  }

  public virtual async Task<List<Entity>> GetAllAsync() => await _dbContext.Set<Entity>().ToListAsync();

  public virtual async Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties)
  {
    try
    {
      IQueryable<Entity> query = _dbContext.Set<Entity>().AsQueryable();

      foreach (var property in properties)
      {
        query = query.Include(property);
      }

      return await query.ToListAsync();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error during GetAllWithIncludeAsync: {ex}");
      throw;
    }
  }

  public virtual async Task<Entity> GetByIdAsync(int id) => await _dbContext.Set<Entity>().FindAsync(id);
}

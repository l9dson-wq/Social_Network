namespace Core.Application;

public interface ICommonRepository<Entity> where Entity : class
{
  Task<Entity> AddAsync(Entity entity);
  Task UpdateAsync(Entity entity, int id);
  Task DeleteAsync(Entity entity);
  Task<List<Entity>> GetAllAsync();
  Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties);
  Task<Entity> GetByIdAsync(int id);
}

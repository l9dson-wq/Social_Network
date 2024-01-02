using Core.Application;
using Core.Domain;

namespace Infrastructure.Persistence;

public class SavedRepository : CommonRepository<Saved>, ISavesRepository
{
  private readonly ApplicationContext _dbContext;
  
  public SavedRepository(ApplicationContext dbContext) : base(dbContext)
  {
    _dbContext = dbContext;
  }
}
namespace Core.Application;

public interface ICommonService<SaveViewModel, ViewModel, Entity>
  where SaveViewModel : class
  where ViewModel : class
  where Entity : class
{
  Task<List<ViewModel>> GetAllViewModel();
}

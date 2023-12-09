namespace Core.Application;

public interface ICommonService<SaveViewModel, ViewModel, Entity>
  where SaveViewModel : class
  where ViewModel : class
  where Entity : class
{
  Task<SaveViewModel> AddAsync(SaveViewModel svm);
  Task Update(SaveViewModel svm, int id);
  Task<List<ViewModel>> GetAllViewModel();
  Task<SaveViewModel> GetSaveViewModel(int id);
}

using AutoMapper;

namespace Core.Application;

public class CommonService<SaveViewModel, ViewModel, Entity> : ICommonService<SaveViewModel, ViewModel, Entity>
  where SaveViewModel : class
  where ViewModel : class
  where Entity : class
{
  private readonly ICommonRepository<Entity> _commonRepository;
  private readonly IMapper _mapper;

  public CommonService(ICommonRepository<Entity> commonRepository, IMapper mapper)
  {
    _commonRepository = commonRepository;
    _mapper = mapper;
  }

  public virtual async Task<SaveViewModel> AddAsync(SaveViewModel svm)
  {
    Entity entity = _mapper.Map<Entity>(svm);

    entity = await _commonRepository.AddAsync(entity);

    SaveViewModel saveVm = _mapper.Map<SaveViewModel>(entity);

    return saveVm;
  }

  public virtual async Task Update(SaveViewModel svm, int id)
  {
    Entity entity = _mapper.Map<Entity>(svm);

    await _commonRepository.UpdateAsync(entity, id);
  }

  public virtual async Task Delete(int id)
  {
    Entity entity = await _commonRepository.GetByIdAsync(id);

    await _commonRepository.DeleteAsync(entity);
  }

  public virtual async Task<List<ViewModel>> GetAllViewModel()
  {
    List<Entity> entityList = await _commonRepository.GetAllAsync();

    return _mapper.Map<List<ViewModel>>(entityList);
  }

  public virtual async Task<SaveViewModel> GetSaveViewModel(int id)
  {
    Entity entity = await _commonRepository.GetByIdAsync(id);

    SaveViewModel svm = _mapper.Map<SaveViewModel>(entity);

    return svm;
  }
}

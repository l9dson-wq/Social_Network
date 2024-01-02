using AutoMapper;
using Core.Application.ViewModels.Saved;
using Core.Domain;

namespace Core.Application;

public class SavedService : CommonService<SaveSavedViewModel, SavedViewModel, Saved>, ISavedService
{
  private readonly ISavesRepository _iSavesRepository;
  private readonly IMapper _iMapper;
  private readonly ISavedService _iSavedService;

  public SavedService(
    ISavesRepository iSavesRepository,
    IMapper iMapper
  ) : base(iSavesRepository, iMapper)
  {
    _iSavesRepository = iSavesRepository;
    _iMapper = iMapper;
  }
}
using Core.Application.ViewModels.Saved;
using Core.Domain;

namespace Core.Application;

public interface ISavedService : ICommonService<SaveSavedViewModel, SavedViewModel, Saved>
{
}
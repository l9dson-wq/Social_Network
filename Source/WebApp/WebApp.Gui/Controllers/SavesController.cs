using Core.Application;
using Core.Application.ViewModels.Saved;
using Microsoft.AspNetCore.Mvc;
using WebApp.Gui.Middlewares;

namespace WebApp.Gui.Controllers;

public class SavesController : Controller
{
  private readonly IHttpContextAccessor _iHttpContextAccessor;
  private readonly UserProfileViewModel _userProfileViewModel;
  private readonly ISavedService _iSavedService;
  private readonly ValidateUserSession _validateUserSession;
  
  public SavesController(
    IHttpContextAccessor iHttpContextAccessor,
    ISavedService iSavedService,
    ValidateUserSession validateUserSession
    )
  {
    _iHttpContextAccessor = iHttpContextAccessor;
    _userProfileViewModel = _iHttpContextAccessor?.HttpContext?.Session.Get<UserProfileViewModel>("userProfile");
    _iSavedService = iSavedService;
    _validateUserSession = validateUserSession;
  }
  
  public async Task<IActionResult> SavePost(int postId)
  {
    if ( !_validateUserSession.HasUser() )
    {
      return RedirectToRoute(new { controller = "Login", action = "Index" });
    }
    
    SaveSavedViewModel savedViewModel = new SaveSavedViewModel();
    savedViewModel.PostId = postId;
    savedViewModel.Date = DateTime.Now;
    savedViewModel.UserId = _userProfileViewModel.Id;

    var saves = await _iSavedService.GetAllViewModel();

    if (saves != null)
    {
      foreach (var save in saves)
      {
        if (savedViewModel.UserId == save.UserId && savedViewModel.PostId == save.PostId)
        {
          await _iSavedService.Delete(save.Id);
          
          return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
      }
    }

    await _iSavedService.AddAsync(savedViewModel);
    return RedirectToRoute(new { controller = "Home", action = "Index" });
  }
}
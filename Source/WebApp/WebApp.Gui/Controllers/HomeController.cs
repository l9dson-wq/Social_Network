using System.Diagnostics;
using Core.Application;
using Core.Application.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using WebApp.Gui.Models;

namespace WebApp.Gui.Controllers;

public class HomeController : Controller
{
  private readonly IPostService _iPostService;
  private readonly IUserProfileService _iUserProfileService;
  private readonly ISavedService _iSavedService;

  public HomeController(
    IPostService iPostService, 
    IUserProfileService iUserProfileService,
    ISavedService iSavedService
    )
  {
    _iPostService = iPostService;
    _iUserProfileService = iUserProfileService;
    _iSavedService = iSavedService;
  }

  public async Task<IActionResult> Index()
  {
    var homeViewModel = new HomeViewModel
    {
      PostViewModels = await _iPostService.GetAllViewModelWithInclude(),
      UserProfileViewModels = await _iUserProfileService.GetAllViewModelWithInclude(),
      SavedViewModels = await _iSavedService.GetAllViewModel(),
    };

    return View(homeViewModel);
  }
}

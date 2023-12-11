using System.Diagnostics;
using Core.Application;
using Core.Application.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using WebApp.Gui.Models;

namespace WebApp.Gui.Controllers;

public class HomeController : Controller
{
  private readonly IUserService _iUserService;
  private readonly IPostService _iPostService;
  private readonly IUserProfileService _iUserProfileService;

  public HomeController(IUserService iUserService, IPostService iPostService, IUserProfileService iUserProfileService)
  {
    _iUserService = iUserService;
    _iPostService = iPostService;
    _iUserProfileService = iUserProfileService;
  }

  public async Task<IActionResult> Index()
  {
    HomeViewModel homeViewModel = new HomeViewModel();
    homeViewModel.PostViewModels = await _iPostService.GetAllViewModelWithInclude();
    homeViewModel.UserProfileViewModels = await _iUserProfileService.GetAllViewModelWithInclude();

    return View(homeViewModel);
  }
}

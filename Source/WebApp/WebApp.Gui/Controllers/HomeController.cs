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

  public HomeController(IUserService iUserService, IPostService iPostService)
  {
    _iUserService = iUserService;
    _iPostService = iPostService;
  }

  public async Task<IActionResult> Index()
  {
    HomeViewModel homeViewModel = new HomeViewModel();
    homeViewModel.PostViewModels = await _iPostService.GetAllViewModelWithInclude();

    return View(homeViewModel);
  }
}

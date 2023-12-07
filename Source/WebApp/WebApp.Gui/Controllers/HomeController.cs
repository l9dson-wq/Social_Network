using System.Diagnostics;
using Core.Application;
using Microsoft.AspNetCore.Mvc;
using WebApp.Gui.Models;

namespace WebApp.Gui.Controllers;

public class HomeController : Controller
{
  private readonly IUserService _iUserService;

  public HomeController(IUserService iUserService)
  {
    _iUserService = iUserService;
  }

  public async Task<IActionResult> Index()
  {
    return View(await _iUserService.GetAllViewModelWithInclude());
  }
}

using Core.Application.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using WebApp.Gui.Middlewares;

namespace WebApp.Gui.Controllers;

public class PostController : Controller
{
  private readonly ValidateUserSession _validateUserSession;

  // Constructor
  public PostController(ValidateUserSession validateUserSession)
  {
    _validateUserSession = validateUserSession;
  }

  // GET
  public IActionResult Index()
  {
    if (!_validateUserSession.HasUser())
    {
      return RedirectToRoute(new { controller = "Login", action = "Index"});
    }

    return View(new SavePostViewModel());
  }

  [HttpPost]
  public async Task<IActionResult> Send()
  {
    return null;
  }
}
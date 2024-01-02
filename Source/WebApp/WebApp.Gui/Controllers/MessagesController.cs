using Microsoft.AspNetCore.Mvc;

namespace WebApp.Gui.Controllers;

public class MessagesController : Controller
{
  // Show a message to the user that the registration has been done successfully.
  [HttpGet]
  public IActionResult RegisterSuccess()
  {
    return View();
  }
}
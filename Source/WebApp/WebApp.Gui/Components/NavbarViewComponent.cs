using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Gui.Components;

public class NavbarViewComponent : ViewComponent
{
  public NavbarViewComponent() {}

  public async Task<IViewComponentResult> InvokeAsync()
  {
    return View();
  }
}
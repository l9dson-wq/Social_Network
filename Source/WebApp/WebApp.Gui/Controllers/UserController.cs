using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.Gui.Controllers;

public class UserController : Controller
{
  private readonly IUserService _iUserService;
  private readonly IUserProfileService _iUserProfileService;
  private readonly IUserProfilePictureService _iUserProfilePictureService;

  public UserController(IUserService iUserService, IUserProfileService iUserProfileService, IUserProfilePictureService iUserProfilePictureService)
  {
    _iUserService = iUserService;
    _iUserProfileService = iUserProfileService;
    _iUserProfilePictureService = iUserProfilePictureService;
  }

  public IActionResult Index()
  {
    return View();
  }
}

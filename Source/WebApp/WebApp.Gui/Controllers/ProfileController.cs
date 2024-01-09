using Core.Application;
using Core.Application.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using WebApp.Gui.Middlewares;

namespace WebApp.Gui.Controllers;

public class ProfileController : Controller
{
  private readonly ValidateUserSession _validateUserSession;
  private readonly IPostService _iPostService;
  private readonly IUserProfileService _iUserProfileService;
  private readonly IHttpContextAccessor _iHttpContextAccessor;
  private readonly UserProfileViewModel _userProfileViewModel;
  
  public ProfileController(
    ValidateUserSession validateUserSession, 
    IPostService iPostService, 
    IUserProfileService iUserProfileService,
    IHttpContextAccessor iHttpContextAccessor)
  {
    _validateUserSession = validateUserSession;
    _iPostService = iPostService;
    _iUserProfileService = iUserProfileService;
    _iHttpContextAccessor = iHttpContextAccessor;
    _userProfileViewModel = _iHttpContextAccessor.HttpContext.Session.Get<UserProfileViewModel>("userProfile");
  }
  
  // GET
  public async Task<IActionResult> Index()
  {
    if (!_validateUserSession.HasUser())
      return RedirectToRoute(new {controller = "Login", action = "Index"});
    
    var homeViewModel = new HomeViewModel
    {
      UserProfileViewModel = _userProfileViewModel,
      PostViewModels = await _iPostService.GetAllViewModelWithInclude()
    };
      
    return View(homeViewModel);
  }

  [HttpGet]
  [Route("Profile/{userName}")]
  public async Task<IActionResult> ViewProfile(string username)
  {
    var userProfileVm = await _iUserProfileService.GetUserByUsername(username);
    
    var homeViewModel = new HomeViewModel()
    {
      UserProfileViewModel = await _iUserProfileService.GetViewModelWithInclude(userProfileVm.Id),
      PostViewModels = await _iPostService.GetAllPostByUserId(userProfileVm.UserId),
    };
    
    return View("ViewProfile", homeViewModel);
  }
}
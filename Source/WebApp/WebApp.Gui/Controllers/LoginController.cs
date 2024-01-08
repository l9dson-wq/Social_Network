using Core.Application;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using WebApp.Gui.Middlewares;

namespace MvcMovie.Controllers;

public class LoginController : Controller
{
  private readonly IUserService _iUserService;
  private readonly IUserProfileService _iUserProfileService;
  private readonly IUserProfilePictureService _iUserProfilePictureService;
  private readonly ValidateUserSession _validateUserSession;

  public LoginController(
    IUserService iUserService, 
    IUserProfileService iUserProfileService, 
    IUserProfilePictureService iUserProfilePictureService,
    ValidateUserSession validateUserSession
    )
  {
    _iUserService = iUserService;
    _iUserProfileService = iUserProfileService;
    _iUserProfilePictureService = iUserProfilePictureService;
    _validateUserSession = validateUserSession;
  }

  public IActionResult Index()
  {
    // Validate if the user has been logged so we are going to return him to the Home page/view.
    if (_validateUserSession.HasUser())
    {
      return RedirectToRoute(new { controller = "Home", action = "Index" });
    }
    
    return View(new LoginViewModel()); // pass a loginViewModel to the view
  }

  [HttpPost]
  public async Task<IActionResult> Login(LoginViewModel loginViewModel)
  {
    // Validate if the user has been logged so we are going to return him to the Home page/view.
    if (_validateUserSession.HasUser())
    {
      return RedirectToRoute(new { controller = "Home", action = "Index" });
    }
    
    // Validate if the Viewmodel has all the information that we must have.
    if (!ModelState.IsValid)
    {
      return View("Index", loginViewModel);
    }
    
    // almaceno la url de la vista en la que se encontraba el usuario antes de llegar aqui.
    var returnUrl = Request.Headers["Referer"].ToString();

    // Search the user in te database
    UserProfileViewModel userProfileViewModel = await _iUserProfileService.Login(loginViewModel);

    // If the user credentials were not found in the database we are going to return the user to the login again.
    if (userProfileViewModel == null)
    {
      ViewBag.NotFound = "The user was not found, please try again";
      return View("Index");
    }

    UserProfileViewModel userProfileVM = await _iUserProfileService.GetViewModelWithInclude(userProfileViewModel.UserId);
    HttpContext.Session.Set("userProfile", userProfileVM); // Register the userProfile to the session

    return Redirect(returnUrl);
  }

  public async Task<IActionResult> Register()
  {
    // Validate if the user has been logged so we are going to return him to the Home page/view.
    if (_validateUserSession.HasUser())
    {
      return RedirectToRoute(new { controller = "Home", action = "Index" });
    }
    
    return View("SignIn", new GeneralSignInViewModel());
  }

  [HttpPost]
  public async Task<IActionResult> Register(GeneralSignInViewModel generalSignInViewModel)
  {
    // Validate if the user has been logged so we are going to return him to the Home page/view.
    if (_validateUserSession.HasUser())
    {
      return RedirectToRoute(new { controller = "Home", action = "Index" });
    }
    
    if (!ModelState.IsValid)
    {
      return View("SignIn", generalSignInViewModel);
    }

    //Add the user first of all
    var user = await _iUserService.AddAsync(generalSignInViewModel.SaveUserViewModel);

    //Then we can use the user Id to submit our UserProfile with all the important that such as the previous user Id
    generalSignInViewModel.SaveUserProfileViewModel.UserId = user.Id;
    var userProfile = await _iUserProfileService.AddAsync(generalSignInViewModel.SaveUserProfileViewModel);

    //Here we are doing the exact thing using the UserProfileId in the UserProfilePicture
    generalSignInViewModel.SaveUserProfilePictureViewModel.UserProfileId = userProfile.Id;
    var userProfilePicture = await _iUserProfilePictureService.AddAsync(generalSignInViewModel.SaveUserProfilePictureViewModel);

    // Adding the image
    if (userProfilePicture != null && userProfilePicture.Id != 0)
    {
      userProfilePicture.ProfilePicturePath = UploadFile(generalSignInViewModel.SaveUserProfilePictureViewModel.PictureFile, userProfilePicture.Id, false);
      await _iUserProfilePictureService.Update(userProfilePicture, userProfilePicture.Id);
    }

    generalSignInViewModel.failed = false;

    return View("SignIn", generalSignInViewModel);
  }

  // So this action basically is going  to help us to log out the user from the session
  // We are going to add an option on the view and redirect the user to this action.
  public async Task<IActionResult> LogOut()
  {
    HttpContext.Session.Remove("userProfile");
    return RedirectToAction("Index");
  }

  private string UploadFile(IFormFile file, int id, bool editMode, string imageUrl = "")
  {
    if (editMode && file == null)
    {
      return imageUrl;
    }

    //Get current directory (project folder)
    string basePath = $"Images/Users/{id}";
    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{basePath}");

    //Create folder if not exist
    if (!Directory.Exists(path))
    {
      Directory.CreateDirectory(path);
    }

    // Get file path
    Guid guid = Guid.NewGuid();
    FileInfo fileInfo = new FileInfo(file.FileName);
    string fileName = guid + fileInfo.Extension;

    string fileNameWithPath = Path.Combine(path, fileName);

    using (FileStream stream = new FileStream(fileNameWithPath, FileMode.Create))
    {
      file.CopyTo(stream);
    }

    // delete the old image and only leave the new one
    if (editMode)
    {
      string[] oldImagePart = imageUrl.Split("/");
      string oldImageName = oldImagePart[^1];
      string completeImageOldPath = Path.Combine(path, oldImageName);

      if (System.IO.File.Exists(completeImageOldPath))
      {
        System.IO.File.Delete(completeImageOldPath);
      }
    }

    return $"{basePath}/{fileName}";
  }
}
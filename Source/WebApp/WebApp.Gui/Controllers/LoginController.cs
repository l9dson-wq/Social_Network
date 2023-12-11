using Core.Application;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class LoginController : Controller
{
  private readonly IUserService _iUserService;
  private readonly IUserProfileService _iUserProfileService;
  private readonly IUserProfilePictureService _iUserProfilePictureService;

  public LoginController(IUserService iUserService, IUserProfileService iUserProfileService, IUserProfilePictureService iUserProfilePictureService)
  {
    _iUserService = iUserService;
    _iUserProfileService = iUserProfileService;
    _iUserProfilePictureService = iUserProfilePictureService;
  }

  public IActionResult Index()
  {
    return View(new LoginViewModel()); // pass a loginViewModel to the view
  }

  [HttpPost]
  public async Task<IActionResult> Login(LoginViewModel loginViewModel)
  {
    if (!ModelState.IsValid)
    {
      return View("Index", loginViewModel);
    }
    
    UserProfileViewModel userProfileViewModel = await _iUserProfileService.Login(loginViewModel);
    
    // Get the user photos

    if (userProfileViewModel != null)
    {
      UserProfileViewModel userProfileVM = await _iUserProfileService.GetViewModelWithInclude(userProfileViewModel.Id);
      HttpContext.Session.Set("userProfile", userProfileVM); // Register the user to the session
      return RedirectToRoute(new { controller = "Home", action = "Index" });
    }
    
    return View("Index");
  }

  public async Task<IActionResult> Register()
  {
    return View("SignIn");
  }

  [HttpPost]
  public async Task<IActionResult> Register(GeneralSignInViewModel generalSignInViewModel)
  {
    if (!ModelState.IsValid)
    {
      return View("SignIn", generalSignInViewModel);
    }

    //Add the user
    var user = await _iUserService.AddAsync(generalSignInViewModel.SaveUserViewModel);

    //Add user profile
    var userProfile = await _iUserProfileService.AddAsync(generalSignInViewModel.SaveUserProfileViewModel);
    userProfile.UserId = user.Id;
    await _iUserProfileService.Update(userProfile, userProfile.Id);

    //Add user Profile Picture
    var userProfilePicture = await _iUserProfilePictureService.AddAsync(generalSignInViewModel.SaveUserProfilePictureViewModel);
    userProfilePicture.UserProfileId = userProfile.Id;
    await _iUserProfilePictureService.Update(userProfilePicture, userProfilePicture.Id);

    // Adding the image
    if (userProfilePicture != null && userProfilePicture.Id != 0)
    {
      userProfilePicture.ProfilePicturePath = UploadFile(generalSignInViewModel.SaveUserProfilePictureViewModel.PictureFile, userProfilePicture.Id, false);
      await _iUserProfilePictureService.Update(userProfilePicture, userProfilePicture.Id);
    }

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
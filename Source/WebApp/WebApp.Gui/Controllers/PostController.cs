using Core.Application;
using Core.Application.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using WebApp.Gui.Middlewares;

namespace WebApp.Gui.Controllers;

public class PostController : Controller
{
  private readonly ValidateUserSession _validateUserSession;
  private readonly IPostService _iPostService;

  // Constructor
  public PostController(ValidateUserSession validateUserSession, IPostService iPostService)
  {
    _validateUserSession = validateUserSession;
    _iPostService = iPostService;
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
  public async Task<IActionResult> Send(SavePostViewModel savePostViewModel)
  {
    // if the user choose an image
    if ( savePostViewModel.ImageFile != null )
    {
      // let's create a guid for the image folder
      Guid guidId = Guid.NewGuid();
      
      // We use the uplodFile function to get the correct imageUrl
      savePostViewModel.ImagePath = UploadFile( savePostViewModel.ImageFile, guidId, false );
      
      await _iPostService.AddAsync(savePostViewModel);
    }
    else
    {
      var post = await _iPostService.AddAsync(savePostViewModel);
    }
    
    return RedirectToRoute(new { controller = "Home", action = "Index" });
  }
  
  private string UploadFile(IFormFile file, Guid id, bool editMode, string imageUrl = "")
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
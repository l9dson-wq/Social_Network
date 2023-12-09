using Microsoft.AspNetCore.Http;

namespace Core.Application;

public class SaveUserProfilePictureViewModel
{
  public int Id { get; set; }
  public string? ProfilePicturePath { get; set; } = string.Empty;
  public string? BackgroundPicturePath { get; set; } = string.Empty;
  public IFormFile? PictureFile { get; set; }

  //RELATIONS
  public int? UserProfileId { get; set; }
}
namespace Core.Application;

public class UserProfilePictureViewModel
{
  public int Id { get; set; }
  public string ProfilePicturePath { get; set; } = string.Empty;
  public string BackgroundPicturePath { get; set; } = string.Empty;
}

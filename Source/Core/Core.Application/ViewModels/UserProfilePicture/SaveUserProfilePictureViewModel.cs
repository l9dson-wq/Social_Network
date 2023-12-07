namespace Core.Application;

public class SaveUserProfilePictureViewModel
{
  public int Id { get; set; }
  public string ProfilePicturePath { get; set; } = string.Empty;
  public string BackgroundPicturePath { get; set; } = string.Empty;

  //RELATIONS
  public int UserProfileId { get; set; }
}
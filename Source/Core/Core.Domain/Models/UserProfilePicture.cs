namespace Core.Domain;

public class UserProfilePicture
{
  public int Id { get; set; }
  public string ProfilePicturePath { get; set; } = string.Empty;
  public string BackgroundPicturePath { get; set; } = string.Empty;

  //RELATIONS
  public int UserProfileId { get; set; }
  public UserProfile UserProfile { get; set; } // 1:1
}

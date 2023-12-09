namespace Core.Domain;

public class UserProfilePicture
{
  public int Id { get; set; }
  public string? ProfilePicturePath { get; set; }
  public string? BackgroundPicturePath { get; set; }

  //RELATIONS
  public int? UserProfileId { get; set; }
  public UserProfile UserProfile { get; set; } // 1:1
}

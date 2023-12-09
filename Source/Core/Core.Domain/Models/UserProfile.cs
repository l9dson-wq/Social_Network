namespace Core.Domain;

public class UserProfile
{
  public int Id { get; set; }
  public string UserName { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public string About { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;

  //RELATIONS
  public int? UserId { get; set; }
  public User User { get; set; } // 1:1  

  public UserProfilePicture UserProfilePicture { get; set; } // 1:1
}

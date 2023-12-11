using Core.Domain;

namespace Core.Application;

public class UserProfileViewModel
{
  public int Id { get; set; }
  public string UserName { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public string About { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public int UserId { get; set; }

  //CUSTOM PROPERTIES
  public string ProfilePicturePath { get; set; }
  public string BackgroundPicturePath { get; set; }
}

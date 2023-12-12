namespace Core.Application;

public class GeneralSignInViewModel
{
  public SaveUserViewModel SaveUserViewModel { get; set; }
  public SaveUserProfileViewModel SaveUserProfileViewModel { get; set; }
  public SaveUserProfilePictureViewModel? SaveUserProfilePictureViewModel { get; set; }
  
  //Tracking process
  public bool? HasError { get; set; }
  public bool? failed { get; set; } = true;
  public string? Error { get; set; }
}

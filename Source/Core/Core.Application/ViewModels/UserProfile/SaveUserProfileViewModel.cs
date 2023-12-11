using System.ComponentModel.DataAnnotations;

namespace Core.Application;

public class SaveUserProfileViewModel
{
  public int Id { get; set; }

  [Required(ErrorMessage = "You must put a Username")]
  [DataType(DataType.Text)]
  public string UserName { get; set; } = string.Empty;

  [Required(ErrorMessage = "You must put a password")]
  [DataType(DataType.Password)]
  public string Password { get; set; } = string.Empty;

  [Compare(nameof(Password), ErrorMessage = "Passwords must match each other")]
  [Required(ErrorMessage = "You must put a password")]
  [DataType(DataType.Password)]
  public string ConfirmPassword { get; set; } = string.Empty;

  [Required(ErrorMessage = "You must put a description")]
  [DataType(DataType.Text)]
  public string About { get; set; } = string.Empty;

  [Required(ErrorMessage = "You must put an Email")]
  [DataType(DataType.Text)]
  public string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = "You must put a Phone")]
  [DataType(DataType.Text)]
  public string Phone { get; set; } = string.Empty;

  public int? UserId { get; set; }
}

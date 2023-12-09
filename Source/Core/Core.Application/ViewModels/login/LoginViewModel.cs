using System.ComponentModel.DataAnnotations;

namespace Core.Application;

public class LoginViewModel
{
  [Required(ErrorMessage = "You Must put a Username to continue")]
  [DataType(DataType.Text)]
  public string Username { get; set; } = string.Empty;

  [Required(ErrorMessage = "You must put a password to continue")]
  [DataType(DataType.Password)]
  public string Password { get; set; }
}

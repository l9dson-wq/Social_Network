using System.ComponentModel.DataAnnotations;

namespace Core.Application;

public class SaveUserViewModel
{
  public int Id { get; set; }

  [Required(ErrorMessage = "You must put a name")]
  [DataType(DataType.Text)]
  public string Name { get; set; } = string.Empty;

  [Required(ErrorMessage = "You must put a Last name")]
  [DataType(DataType.Text)]
  public string LastName { get; set; } = string.Empty;

  [Range(1, 100, ErrorMessage = "You can't have more than 100 years")]
  public int Age { get; set; }

  [Required(ErrorMessage = "You must put a gender")]
  [DataType(DataType.Text)]
  public string Gender { get; set; } = string.Empty;

  [Required(ErrorMessage = "You must put a country name")]
  [DataType(DataType.Text)]
  public string Country { get; set; } = string.Empty;

  [Required(ErrorMessage = "You must put a city name")]
  [DataType(DataType.Text)]
  public string City { get; set; } = string.Empty;
}

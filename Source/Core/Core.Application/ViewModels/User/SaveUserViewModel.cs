namespace Core.Application;

public class SaveUserViewModel
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public int Age { get; set; }
  public string Gender { get; set; } = string.Empty;
  public string Country { get; set; } = string.Empty;
  public string City { get; set; } = string.Empty;
}

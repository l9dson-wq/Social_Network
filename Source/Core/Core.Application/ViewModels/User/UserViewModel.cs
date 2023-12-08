﻿using Core.Domain;

namespace Core.Application;

public class UserViewModel
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public int Age { get; set; }
  public string Gender { get; set; } = string.Empty;
  public string Country { get; set; } = string.Empty;
  public string City { get; set; } = string.Empty;

  //CUSTOM INFORMATION
  public UserProfileViewModel UserProfile { get; set; }
  public ICollection<Post> Posts { get; set; }
}
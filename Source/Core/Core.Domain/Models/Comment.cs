﻿namespace Core.Domain;

public class Comment : AuditableBaseEntity
{
  public string Description { get; set; } = string.Empty;
  public string ImagePath { get; set; } = string.Empty;
  public int Reported { get; set; }

  //RELATIONS
  public int PostId { get; set; }
  public Post Post { get; set; }

  public ICollection<Like> Likes { get; set; }
}

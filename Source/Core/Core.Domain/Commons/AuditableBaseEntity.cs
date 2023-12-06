using System.Dynamic;
using System.Runtime.CompilerServices;

namespace Core.Domain;

public class AuditableBaseEntity
{
  public int Id { get; set; }
  public string CreatedBy { get; set; } = string.Empty;
  public DateTime Created { get; set; }
  public string LastModifiedBy { get; set; } = string.Empty;
  public DateTime LastModified { get; set; }
}

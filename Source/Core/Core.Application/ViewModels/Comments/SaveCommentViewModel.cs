using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Core.Application.ViewModels.Comments;

public class SaveCommentViewModel
{
  public int Id { get; set; }
  
  [DataType(DataType.Text)]
  public string Description { get; set; }
  
  [DataType(DataType.Upload)]
  public IFormFile ImageFile { get; set; }
  
  public int Reported { get; set; }
  
  public int UserId { get; set; }
  
  public int PostId { get; set; }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Core.Application.ViewModels.Post;

public class SavePostViewModel
{
    public int Id { get; set; }
    
    [DataType(DataType.Text)]
    public string? ImagePath { get; set; } = string.Empty;
    
    [DataType(DataType.Upload)]
    public IFormFile? ImageFile { get; set; }
    
    [Required(ErrorMessage = "You must put a title" )]
    [DataType(DataType.Text)]
    public string Title { get; set; } = string.Empty;
    
    [DataType(DataType.Text)]
    public string? Description { get; set; } = string.Empty;

    public int UserId { get; set; }
}
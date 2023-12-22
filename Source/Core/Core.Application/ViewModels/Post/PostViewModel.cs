using Core.Domain;

namespace Core.Application.ViewModels.Post;

public class PostViewModel
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Reported { get; set; }
    public int UserId { get; set; }

    public User User { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Like> Likes { get; set; }
}
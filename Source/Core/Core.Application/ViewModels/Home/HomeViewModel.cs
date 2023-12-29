using Core.Application.ViewModels.Post;

namespace Core.Application.ViewModels.Home;

public class HomeViewModel
{
    // singles
    public PostViewModel PostViewModel { get; set; }
    public UserProfileViewModel UserProfileViewModel { get; set; }
    
    // Lists
    public List<PostViewModel>? PostViewModels { get; set; }
    public List<UserProfileViewModel>? UserProfileViewModels { get; set; }
}
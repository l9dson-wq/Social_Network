using Core.Application.ViewModels.Post;
using Core.Application.ViewModels.Saved;

namespace Core.Application.ViewModels.Home;

public class HomeViewModel
{
    // singles
    public PostViewModel PostViewModel { get; set; }
    public UserProfileViewModel UserProfileViewModel { get; set; }
    
    // Lists
    public List<PostViewModel>? PostViewModels { get; set; }
    public List<UserProfileViewModel>? UserProfileViewModels { get; set; }
    public List<SavedViewModel>? SavedViewModels { get; set; }
}
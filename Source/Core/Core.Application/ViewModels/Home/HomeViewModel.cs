using Core.Application.ViewModels.Post;

namespace Core.Application.ViewModels.Home;

public class HomeViewModel
{
    public List<PostViewModel>? PostViewModels { get; set; }
    public List<UserProfileViewModel>? UserProfileViewModels { get; set; }
}
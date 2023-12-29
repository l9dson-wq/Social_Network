using AutoMapper;
using Core.Application.ViewModels.Post;
using Core.Domain;

namespace Core.Application;

public class PostService : CommonService<SavePostViewModel, PostViewModel, Post>, IPostService
{
  private readonly IMapper _mapper;
  private readonly IPostRepository _iPostRepository;

  public PostService(IMapper mapper, IPostRepository iPostRepository) : base(iPostRepository, mapper)
  {
    _mapper = mapper;
    _iPostRepository = iPostRepository;
  }

  public async Task<List<PostViewModel>> GetAllViewModelWithInclude()
  {
    var posts = await _iPostRepository.GetAllWithIncludeAsync(new List<string> { "User", "Comments", "Likes" });

    return posts.OrderByDescending(post => post.Created).Select(post => new PostViewModel()
    {
      Id = post.Id,
      ImagePath = post.ImagePath,
      Title = post.Title,
      Description = post.Description,
      Reported = post.Reported,
      UserId = post.UserId,
      User = post.User,
      Comments = post.Comments,
      Likes = post.Likes.Where(like => like.IsLike == true).ToList(),
    }).ToList();
  }
  
  public async Task<PostViewModel> GetViewModelWithIncludeById(int postId)
  {
    var posts = await _iPostRepository.GetAllWithIncludeAsync(new List<string> { "User", "Comments", "Likes" });

    foreach ( var post in posts )
    {
      if ( post.Id == postId )
      {
        PostViewModel postVm = new PostViewModel();
        postVm.Id = post.Id;
        postVm.ImagePath = post.ImagePath;
        postVm.Title = post.Title;
        postVm.Description = post.Description;
        postVm.Reported = post.Reported;
        postVm.UserId = post.UserId;
        postVm.User = post.User;
        postVm.Comments = post.Comments;
        postVm.Likes = post.Likes.Where(like => like.IsLike == true).ToList();

        return postVm;
      }
    }

    return new PostViewModel();
  }
}

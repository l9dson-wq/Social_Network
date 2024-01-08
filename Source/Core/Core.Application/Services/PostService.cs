using AutoMapper;
using Core.Application.ViewModels.Comments;
using Core.Application.ViewModels.Post;
using Core.Domain;

namespace Core.Application;

public class PostService : CommonService<SavePostViewModel, PostViewModel, Post>, IPostService
{
  private readonly IMapper _iMapper;
  private readonly IPostRepository _iPostRepository;

  public PostService(IMapper mapper, IPostRepository iPostRepository) : base(iPostRepository, mapper)
  {
    _iMapper = mapper;
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
      Comments = _iMapper.Map<List<CommentViewModel>>(post.Comments),
      Created = post.Created,
      LastModified = post.LastModified,
      RelativeDate = GetRelativeTime(post.Created),
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
        postVm.Comments = _iMapper.Map<List<CommentViewModel>>(post.Comments);
        postVm.Created = post.Created;
        postVm.LastModified = post.LastModified;
        postVm.RelativeDate = GetRelativeTime(post.Created);
        postVm.Likes = post.Likes.Where(like => like.IsLike == true).ToList();

        return postVm;
      }
    }

    return new PostViewModel();
  }
  
  private string GetRelativeTime(DateTime originalDateTime)
  {
    TimeSpan timeDifference = DateTime.Now - originalDateTime;

    if (timeDifference.TotalSeconds < 60)
    {
      return $"about {Math.Round(timeDifference.TotalSeconds)} {(Math.Round(timeDifference.TotalSeconds) == 1 ? "second" : "seconds")} ago";
    }
    else if (timeDifference.TotalMinutes < 60)
    {
      return $"about {Math.Round(timeDifference.TotalMinutes)} {(Math.Round(timeDifference.TotalMinutes) == 1 ? "minute" : "minutes")} ago";
    }
    else if (timeDifference.TotalHours < 24)
    {
      return $"about {Math.Round(timeDifference.TotalHours)} {(Math.Round(timeDifference.TotalHours) == 1 ? "hour" : "hours")} ago";
    }
    else if (timeDifference.TotalDays < 7)
    {
      return $"about {Math.Round(timeDifference.TotalDays)} {(Math.Round(timeDifference.TotalDays) == 1 ? "day" : "days")} ago";
    }
    else
    {
      return originalDateTime.ToString("MM/dd/yyyy"); // If more than a week has passed, show the original date
    }
  }
}

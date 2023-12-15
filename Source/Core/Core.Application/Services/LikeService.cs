using AutoMapper;
using Core.Domain;
using Microsoft.AspNetCore.Http;

namespace Core.Application;

public class LikeService : CommonService<SaveLikeViewModel, LikeViewModel, Like>, ILikeService
{
  private readonly IMapper _iMapper;
  private readonly ILikeRepository _iLikeRepository;
  private readonly UserProfileViewModel _userProfileViewModel;
  private readonly IHttpContextAccessor _iHttpContextAccessor;

  public LikeService(IMapper iMapper, ILikeRepository iLikeRepository, IHttpContextAccessor iHttpContextAccessor) : base(iLikeRepository, iMapper)
  {
    _iMapper = iMapper;
    _iLikeRepository = iLikeRepository;
    _iHttpContextAccessor = iHttpContextAccessor;
    _userProfileViewModel = iHttpContextAccessor.HttpContext.Session.Get<UserProfileViewModel>("userProfile");
  }

  public override async Task<SaveLikeViewModel> AddAsync(SaveLikeViewModel saveLikeViewModel)
  {
    // Check if the user already has a like to the same post
    var getUserLike = await _iLikeRepository.GetAllAsync();

    // Get the likes where the user Id and the post or comment Id are the same
    // So we know if the user already gave a like to the same post
    var alreadyLiked = getUserLike.Where(like => like.UserId == _userProfileViewModel.UserId && like.PostId == saveLikeViewModel.PostId).ToList();

    if (alreadyLiked.Count != 0)
    {
      return saveLikeViewModel;
    }

    saveLikeViewModel.UserId = _userProfileViewModel.UserId;

    return await base.AddAsync(saveLikeViewModel);
  }
}

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
    saveLikeViewModel.UserId = _userProfileViewModel.UserId;

    return await base.AddAsync(saveLikeViewModel);
  }
}

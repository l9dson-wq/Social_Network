using AutoMapper;
using Core.Application.ViewModels.Comments;
using Core.Application.ViewModels.Post;
using Core.Application.ViewModels.Saved;
using Core.Domain;

namespace Core.Application;

public class GeneralProfile : Profile
{
  public GeneralProfile()
  {
    #region User
    CreateMap<User, UserViewModel>()
      .ReverseMap()
      .ForMember(dest => dest.Created, opt => opt.Ignore())
      .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
      .ForMember(dest => dest.LastModified, opt => opt.Ignore())
      .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
      .ForMember(dest => dest.UserProfile, opt => opt.Ignore())
      .ForMember(dest => dest.Likes, opt => opt.Ignore())
      .ForMember(dest => dest.Posts, opt => opt.Ignore())
      .ForMember(dest => dest.Saveds, opt => opt.Ignore())
      .ForMember(dest => dest.Comments, opt => opt.Ignore())
      .ForMember(dest => dest.FriendShips, opt => opt.Ignore())
      .ForMember(dest => dest.IAmFriend, opt => opt.Ignore());

    CreateMap<User, SaveUserViewModel>()
      .ReverseMap()
      .ForMember(dest => dest.Created, opt => opt.Ignore())
      .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
      .ForMember(dest => dest.LastModified, opt => opt.Ignore())
      .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
      .ForMember(dest => dest.UserProfile, opt => opt.Ignore())
      .ForMember(dest => dest.Likes, opt => opt.Ignore())
      .ForMember(dest => dest.Posts, opt => opt.Ignore())
      .ForMember(dest => dest.Saveds, opt => opt.Ignore())
      .ForMember(dest => dest.Comments, opt => opt.Ignore())
      .ForMember(dest => dest.FriendShips, opt => opt.Ignore())
      .ForMember(dest => dest.IAmFriend, opt => opt.Ignore());
    #endregion

    #region UserProfile
    CreateMap<UserProfile, SaveUserProfileViewModel>()
      .ReverseMap()
      .ForMember(dest => dest.User, opt => opt.Ignore())
      .ForMember(dest => dest.UserProfilePicture, opt => opt.Ignore());

    CreateMap<UserProfile, UserProfileViewModel>()
      .ForMember(dest => dest.ProfilePicturePath, opt => opt.Ignore())
      .ForMember(dest => dest.BackgroundPicturePath, opt => opt.Ignore())
      .ReverseMap()
      .ForMember(dest => dest.User, opt => opt.Ignore())
      .ForMember(dest => dest.UserProfilePicture, opt => opt.Ignore());
    #endregion

    #region UserProfilePicture
    CreateMap<UserProfilePicture, SaveUserProfilePictureViewModel>()
      .ForMember(dest => dest.PictureFile, opt => opt.Ignore())
      .ReverseMap()
      .ForMember(dest => dest.UserProfile, opt => opt.Ignore());

    CreateMap<UserProfilePicture, UserProfilePictureViewModel>()
      .ReverseMap()
      .ForMember(dest => dest.UserProfile, opt => opt.Ignore())
      .ForMember(dest => dest.UserProfileId, opt => opt.Ignore());
    #endregion

    #region Post

    CreateMap<Post, PostViewModel>()
      .ReverseMap()
      .ForMember(dest => dest.Created, opt => opt.Ignore())
      .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
      .ForMember(dest => dest.LastModified, opt => opt.Ignore())
      .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

    CreateMap<Post, SavePostViewModel>()
      .ForMember(dest => dest.ImageFile, opt => opt.Ignore())
      .ReverseMap()
      .ForMember(dest => dest.Created, opt => opt.Ignore())
      .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
      .ForMember(dest => dest.LastModified, opt => opt.Ignore())
      .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
      .ForMember(dest => dest.Reported, opt => opt.Ignore())
      .ForMember(dest => dest.User, opt => opt.Ignore())
      .ForMember(dest => dest.Comments, opt => opt.Ignore())
      .ForMember(dest => dest.Likes, opt => opt.Ignore());

    #endregion

    #region Likes
    CreateMap<Like, LikeViewModel>()
      .ReverseMap()
      .ForMember(dest => dest.UserId, opt => opt.Ignore())
      .ForMember(dest => dest.User, opt => opt.Ignore())
      .ForMember(dest => dest.PostId, opt => opt.Ignore())
      .ForMember(dest => dest.Post, opt => opt.Ignore())
      .ForMember(dest => dest.CommentId, opt => opt.Ignore())
      .ForMember(dest => dest.Comment, opt => opt.Ignore());

    CreateMap<Like, SaveLikeViewModel>()
      .ReverseMap()
      .ForMember(dest => dest.User, opt => opt.Ignore())
      .ForMember(dest => dest.Post, opt => opt.Ignore())
      .ForMember(dest => dest.Comment, opt => opt.Ignore());
    #endregion
    
    #region Saved
    CreateMap<Saved, SavedViewModel>()
      .ForMember(dest => dest.User, opt => opt.Ignore())
      .ForMember(dest => dest.Post, opt => opt.Ignore())
      .ReverseMap()
      .ForMember(dest => dest.User, opt => opt.Ignore())
      .ForMember(dest => dest.Post, opt => opt.Ignore())
      .ForMember(dest => dest.Comment, opt => opt.Ignore());
    
    CreateMap<Saved, SaveSavedViewModel>()
      .ReverseMap()
      .ForMember(dest => dest.User, opt => opt.Ignore())
      .ForMember(dest => dest.Post, opt => opt.Ignore())
      .ForMember(dest => dest.Comment, opt => opt.Ignore());
    #endregion
    
    #region Comment
    CreateMap<Comment, CommentViewModel>()
      .ForMember(dest => dest.User, opt => opt.Ignore())
      .ForMember(dest => dest.Post, opt => opt.Ignore())
      .ForMember(dest => dest.Likes, opt => opt.Ignore())
      .ForMember(dest => dest.UserProfile, opt => opt.Ignore())
      .ForMember(dest => dest.ParentCommentUsername, opt => opt.Ignore())
      .ForMember(dest => dest.Replies, opt => opt.Ignore())
      .ForMember(dest => dest.LiteralDate, opt => opt.Ignore())
      .ReverseMap()
      .ForMember(dest => dest.Created, opt => opt.Ignore())
      .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
      .ForMember(dest => dest.LastModified, opt => opt.Ignore())
      .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
      .ForMember(dest => dest.User, opt => opt.Ignore())
      .ForMember(dest => dest.Post, opt => opt.Ignore())
      .ForMember(dest => dest.Likes, opt => opt.Ignore())
      .ForMember(dest => dest.Replies, opt => opt.Ignore());
    
    CreateMap<Comment, SaveCommentViewModel>()
      .ReverseMap()
      .ForMember(dest => dest.Created, opt => opt.Ignore())
      .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
      .ForMember(dest => dest.LastModified, opt => opt.Ignore())
      .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
      .ForMember(dest => dest.User, opt => opt.Ignore())
      .ForMember(dest => dest.Post, opt => opt.Ignore())
      .ForMember(dest => dest.Likes, opt => opt.Ignore())
      .ForMember(dest => dest.Replies, opt => opt.Ignore())
      .ForMember(dest => dest.ParentComment, opt => opt.Ignore());
    #endregion
  }
}
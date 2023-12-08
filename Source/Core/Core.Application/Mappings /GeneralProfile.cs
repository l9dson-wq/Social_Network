using AutoMapper;
using Core.Domain;

namespace Core.Application;

public class GeneralProfile : Profile
{
  public GeneralProfile()
  {
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
  }
}
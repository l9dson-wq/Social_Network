using AutoMapper;
using Core.Domain;

namespace Core.Application;

public class GeneralProfile : Profile
{
  public GeneralProfile()
  {
    CreateMap<User, UserViewModel>()
      .ForMember(dest => dest.UserName, opt => opt.Ignore())
      .ForMember(dest => dest.About, opt => opt.Ignore())
      .ReverseMap()
      .ForMember(dest => dest.Created, opt => opt.Ignore())
      .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
      .ForMember(dest => dest.LastModified, opt => opt.Ignore())
      .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
  }
}

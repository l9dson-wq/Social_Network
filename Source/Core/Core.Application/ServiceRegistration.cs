using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application;

public static class ServiceRegistration
{
  public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
  {
    // Injecting Automapper
    services.AddAutoMapper(Assembly.GetExecutingAssembly());

    // Injecting services
    services.AddTransient<IUserService, UserService>();
    services.AddTransient<IUserProfileService, UserProfileService>();
    services.AddTransient<IUserProfilePictureService, UserProfilePictureService>();
    services.AddTransient<IPostService, PostService>();
  }
}

using Core.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class ServiceRegistration
{
  public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    // Contexts

    if (configuration.GetValue<bool>("UseInMemoryDatabase"))
    {
      services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
    }
    else
    {
      services.AddDbContext<ApplicationContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
              m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
    }

    // Repositories
    services.AddTransient(typeof(ICommonRepository<>), typeof(CommonRepository<>));
    services.AddTransient<IUserRepository, UserRepository>();
    services.AddTransient<IUserProfileRepository, UserProfileRepository>();
  }
}

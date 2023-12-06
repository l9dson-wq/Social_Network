using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationContext : DbContext
{
  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

  //sets
  public DbSet<User> Users { get; set; }
  public DbSet<UserProfile> UserProfiles { get; set; }
  public DbSet<UserProfilePicture> UserProfilePictures { get; set; }
  public DbSet<Post> Posts { get; set; }
  public DbSet<Comment> Comments { get; set; }
  public DbSet<Saved> Saveds { get; set; }
  public DbSet<RequestConnect> RequestConnects { get; set; }
  public DbSet<Like> LikeBaseEntities { get; set; }
  public DbSet<FriendShip> FriendShips { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    //FLUENT API

    //User
    modelBuilder.Entity<User>(user =>
    {
      user.ToTable("Users");
      user.HasKey(u => u.Id);
    });

    //Userprofile
    modelBuilder.Entity<UserProfile>(userProfile =>
    {
      userProfile.ToTable("UserProfiles");
      userProfile.HasKey(up => up.Id);
    });
  }
}

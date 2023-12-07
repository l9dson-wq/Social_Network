﻿using Core.Domain;
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
  public DbSet<Like> LikeBaseEntities { get; set; }
  public DbSet<FriendShip> FriendShips { get; set; }

  //Modifying savechanges method
  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
  {
    foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
    {
      switch (entry.State)
      {
        case EntityState.Added:
          entry.Entity.Created = DateTime.Now;
          entry.Entity.CreatedBy = "DefaultAppUser";
          break;
        case EntityState.Modified:
          entry.Entity.LastModified = DateTime.Now;
          entry.Entity.LastModifiedBy = "DefaultAppUser";
          break;
      }
    }

    return base.SaveChangesAsync(cancellationToken);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    //FLUENT API

    //User
    modelBuilder.Entity<User>(user =>
    {
      user.ToTable("Users");

      user.HasKey(u => u.Id);

      user.HasOne(u => u.UserProfile).WithOne(up => up.User).HasForeignKey<UserProfile>(up => up.UserId).OnDelete(DeleteBehavior.Cascade);
      user.HasMany(u => u.Likes).WithOne(l => l.User).HasForeignKey(l => l.UserId).OnDelete(DeleteBehavior.NoAction);
      user.HasMany(u => u.Posts).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
      user.HasMany(u => u.Saveds).WithOne(s => s.User).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Cascade);
      user.HasMany(u => u.FriendShips).WithOne(f => f.User).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.NoAction);
      user.HasMany(u => u.IAmFriend).WithOne(f => f.Friend).HasForeignKey(f => f.FriendId).OnDelete(DeleteBehavior.NoAction);
      user.HasMany(u => u.Comments).WithOne(c => c.User).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);

      user.Property(u => u.Name).HasMaxLength(100);
      user.Property(u => u.LastName).HasMaxLength(100);
    });

    //Userprofile
    modelBuilder.Entity<UserProfile>(userProfile =>
    {
      userProfile.ToTable("UserProfiles");

      userProfile.HasKey(up => up.Id);

      userProfile.HasOne(up => up.UserProfilePicture).WithOne(upp => upp.UserProfile).HasForeignKey<UserProfilePicture>(upp => upp.UserProfileId).OnDelete(DeleteBehavior.Cascade);

      userProfile.Property(up => up.UserName).HasMaxLength(100);
    });

    //Post
    modelBuilder.Entity<Post>(post =>
    {
      post.ToTable("Posts");

      post.HasKey(p => p.Id);

      post.HasMany(p => p.Comments).WithOne(c => c.Post).HasForeignKey(c => c.PostId).OnDelete(DeleteBehavior.Cascade);
      post.HasMany(p => p.Likes).WithOne(l => l.Post).HasForeignKey(l => l.PostId).OnDelete(DeleteBehavior.NoAction);
    });

    //Comment
    modelBuilder.Entity<Comment>(comment =>
    {
      comment.ToTable("Comments");

      comment.HasKey(c => c.Id);

      comment.HasMany(c => c.Likes).WithOne(l => l.Comment).HasForeignKey(l => l.CommentId).OnDelete(DeleteBehavior.Cascade);
    });

  }
}

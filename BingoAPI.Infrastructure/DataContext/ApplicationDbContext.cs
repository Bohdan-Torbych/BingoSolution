using BingoAPI.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BingoAPI.Infrastructure.DataContext;

/// <summary>
/// Represents the application-specific database context for Identity using Entity Framework.
/// </summary>
public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    /// <summary>
    /// Gets or sets the DbSet for the 'Friendships' table.
    /// </summary>
    public DbSet<Friendship> Friendships { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
    /// </summary>
    /// <param name="options">The options for configuring the context.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Configures the model and relationships between entities.
    /// </summary>
    /// <param name="builder">The model builder.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var users = GetUserSeedData("usersSeed.json");

        builder.Entity<ApplicationUser>().HasData(users);

        builder.Entity<Friendship>()
            .HasKey(f => new { f.UserId, f.FriendId });

        builder.Entity<Friendship>()
            .HasOne(f => f.User)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Friendship>()
            .HasOne(f => f.Friend)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
    }

    /// <summary>
    /// Deserializes application users from file
    /// </summary>
    /// <param name="fileName">File name with users data</param>
    /// <returns>List of ApplicationUser object</returns>
    private static List<ApplicationUser> GetUserSeedData(string fileName)
    {
        List<ApplicationUser>? usersList;

        using (StreamReader reader = new(fileName))
        {
            string json = reader.ReadToEnd();
            usersList = JsonSerializer.Deserialize<List<ApplicationUser>>(json);
        }

        var passwordHasher = new PasswordHasher<ApplicationUser>();

        if (usersList is null)
            return new List<ApplicationUser>();

        foreach (var user in usersList)
        {
            user.NormalizedUserName = user.UserName?.ToUpper();
            user.NormalizedEmail = user.Email?.ToUpper();
            user.SecurityStamp = Guid.NewGuid().ToString("D");
            user.PasswordHash = passwordHasher.HashPassword(user, user.PasswordHash);
        }

        return usersList;
    }
}


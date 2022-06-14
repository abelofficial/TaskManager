
using Microsoft.EntityFrameworkCore;
using Users.Api.Models;

namespace Users.Api.Data;

public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> opt) : base(opt)
    { }

    public DbSet<Profile> Profile { get; set; }
    public DbSet<Account> Account { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { }
}
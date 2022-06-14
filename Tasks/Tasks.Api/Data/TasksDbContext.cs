
using Microsoft.EntityFrameworkCore;
using Tasks.Api.Models;

namespace Tasks.Api.Data;

public class TasksDbContext : DbContext
{
    public TasksDbContext(DbContextOptions<TasksDbContext> opt) : base(opt)
    { }

    public DbSet<Tasks.Api.Models.Assignment> Assignment { get; set; }
    public DbSet<Tasks.Api.Models.User> Users { get; set; }
}
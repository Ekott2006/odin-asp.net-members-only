using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace WebApp.Data;

public class DataContext(DbContextOptions options): IdentityDbContext(options)
{
    public DbSet<Post> Posts { get; set; } = default!;
}

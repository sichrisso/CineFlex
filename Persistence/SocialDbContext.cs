using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class SocialDbContext: DbContext
{
    public SocialDbContext(DbContextOptions<SocialDbContext> options) : base(options)
    {
    }
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Cinema> Cinemas => Set<Cinema>();
}
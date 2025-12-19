using Microsoft.EntityFrameworkCore;
using LearnApiTraining2025_1.Server.Models;

namespace LearnApiTraining2025_1.Server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<MealLog> MealLogs => Set<MealLog>();
}

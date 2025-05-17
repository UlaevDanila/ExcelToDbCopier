using Microsoft.EntityFrameworkCore;

namespace TestTask.Models;

public class UserDbContext : DbContext
{
    public DbSet<User.User> Users => Set<User.User>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True; " +
                                    "User ID = admin; Password = 11111111; TrustServerCertificate=True");
    }
}

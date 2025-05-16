using Microsoft.EntityFrameworkCore;
using TestTask.DataDeserialzator;
using TestTask.User;


public class UserDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True; " +
                                    "User ID = admin; Password = 11111111; TrustServerCertificate=True");
    }
}

class Program
{
    static void Main()
    {
        var data = new DataDeserializator();
        using (var db = new UserDbContext())
        {
            db.Database.EnsureCreated();

            foreach (var user in data.GetAllUsers())
            {
                db.Users.Add(user);
            }
            db.SaveChanges();
        }
    }
}

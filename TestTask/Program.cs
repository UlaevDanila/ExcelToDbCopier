using TestTask.DataDeserialzator;
using TestTask.Models;

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

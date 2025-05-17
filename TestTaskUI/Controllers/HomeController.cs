using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.User;


namespace TestTaskUI.Controllers;

public class HomeController(UserDbContext userDb) : Controller
{
    private UserDbContext _usersDb = userDb;

    [HttpGet]
    public IActionResult Index()
    {
        var users = _usersDb.Users.ToList();
        return View(users);
    }

    [HttpGet("/home/edit/{id}")]
    public IActionResult Edit(int id)
    {
        var user = _usersDb.Users.FirstOrDefault(user => user.PK_Id == id);
        return View(user);
    }

    [HttpPost]
    public IActionResult Edit(User user)
    {
        _usersDb.Users.Update(user);
        return RedirectToAction($"Index");
    }
}
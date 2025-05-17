using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.User;


namespace TestTaskUI.Controllers;

public class HomeController(UserDbContext userDb) : Controller
{
    private UserDbContext _usersDb = userDb;

    [HttpGet("/home/index/{countDownValue}")]
    public IActionResult Index(int countDownValue)
    {
        var upperIndexBound = countDownValue * 100;
        var lowerIndexBound = (countDownValue - 1) * 100;
        var users = _usersDb.Users.Where(users => users.PK_Id > lowerIndexBound &&
                                                  users.PK_Id < upperIndexBound);
        return View(users);
    }

    [HttpGet("/home/edit/{id}")]
    public IActionResult Edit(int id)
    {
        var user = _usersDb.Users.FirstOrDefault(user => user.PK_Id == id);
        _usersDb.Users.Remove(user);
        return View(user);
    }

    [HttpPost]
    public IActionResult Edit(User user)
    {
        _usersDb.Users.Update(user);
        _usersDb.SaveChanges();
        if (user.PK_Id < 100)
            return RedirectToAction($"Index", new { id = 1 });
        return RedirectToAction($"Index", new { id =  user.PK_Id / 100});
    }
}
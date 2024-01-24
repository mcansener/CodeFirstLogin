using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CodeFirstLogin.Context;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Validate login credentials against the database
        var user = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            // Successful login, redirect to a dashboard or home page
            return RedirectToAction("Index", "Home");
        }
        else
        {
            // Failed login, return to the login page with an error message
            ViewBag.Error = "Invalid username or password";
            return View();
        }
    }
}